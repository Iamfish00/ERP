using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace ERP_BanHang
{
    public partial class QlyGiaoHang : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ERP_Connection"]?.ConnectionString
            ?? ConfigurationManager.ConnectionStrings["ERP_BanHang"]?.ConnectionString;

        private DataTable dtGiaoHang;

        // Khai báo Timer để Auto Load dữ liệu
        private Timer autoLoadTimer;

        public QlyGiaoHang()
        {
            InitializeComponent();
            KhoiTaoAutoLoadTimer(); // Khởi tạo bộ đếm thời gian
        }

        // ==========================================
        // CẤU HÌNH AUTO LOAD TIMER
        // ==========================================
        private void KhoiTaoAutoLoadTimer()
        {
            autoLoadTimer = new Timer();
            autoLoadTimer.Interval = 5000; // Tự động làm mới dữ liệu mỗi 5000 ms (5 giây)
            autoLoadTimer.Tick += AutoLoadTimer_Tick;
        }

        private void AutoLoadTimer_Tick(object sender, EventArgs e)
        {
            // Tự động tải lại dữ liệu ngầm từ CSDL PostgreSQL
            LoadDataGiaoHang();
        }

        private void QlyGiaoHang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            if (cboFilterStatus.Items.Count > 0)
                cboFilterStatus.SelectedIndex = 0;

            KhoiTaoCotBang();
            LoadDataGiaoHang();

            // Bắt đầu chạy Auto Load
            autoLoadTimer.Start();
        }

        // Khi người dùng chuyển tab hoặc đóng form thì tạm dừng Timer để tiết kiệm tài nguyên
        private void QlyGiaoHang_Activated(object sender, EventArgs e)
        {
            LoadDataGiaoHang();
            if (autoLoadTimer != null && !autoLoadTimer.Enabled)
            {
                autoLoadTimer.Start();
            }
        }

        private void QlyGiaoHang_Deactivate(object sender, EventArgs e)
        {
            if (autoLoadTimer != null)
            {
                autoLoadTimer.Stop();
            }
        }

        private void QlyGiaoHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (autoLoadTimer != null)
            {
                autoLoadTimer.Stop();
                autoLoadTimer.Dispose();
            }
        }

        private void KhoiTaoCotBang()
        {
            dgvGiaoHang.Columns.Clear();
            dgvGiaoHang.AutoGenerateColumns = false;

            // 1. Mã đơn hàng
            DataGridViewTextBoxColumn colIDDH = new DataGridViewTextBoxColumn();
            colIDDH.Name = "colIDDH";
            colIDDH.HeaderText = "MÃ ĐƠN HÀNG";
            colIDDH.DataPropertyName = "ID_DH";
            colIDDH.FillWeight = 10;
            colIDDH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIDDH.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colIDDH.DefaultCellStyle.ForeColor = Color.FromArgb(13, 110, 253);
            dgvGiaoHang.Columns.Add(colIDDH);

            // 2. Doanh nghiệp / Khách hàng nhận
            DataGridViewTextBoxColumn colKH = new DataGridViewTextBoxColumn();
            colKH.Name = "colTenKhachHang";
            colKH.HeaderText = "KHÁCH HÀNG NHẬN";
            colKH.DataPropertyName = "TenDoanhNghiep";
            colKH.FillWeight = 20;
            dgvGiaoHang.Columns.Add(colKH);

            // 3. Người nhận thực tế
            DataGridViewTextBoxColumn colNguoiNhan = new DataGridViewTextBoxColumn();
            colNguoiNhan.Name = "colNguoiNhan";
            colNguoiNhan.HeaderText = "NGƯỜI NHẬN";
            colNguoiNhan.DataPropertyName = "NguoiNhan";
            colNguoiNhan.FillWeight = 15;
            dgvGiaoHang.Columns.Add(colNguoiNhan);

            // 4. Địa chỉ giao
            DataGridViewTextBoxColumn colDiaChi = new DataGridViewTextBoxColumn();
            colDiaChi.Name = "colDiaChi";
            colDiaChi.HeaderText = "ĐỊA CHỈ GIAO HÀNG";
            colDiaChi.DataPropertyName = "DiaChiGiaoHang";
            colDiaChi.FillWeight = 25;
            dgvGiaoHang.Columns.Add(colDiaChi);

            // 5. Số điện thoại nhận
            DataGridViewTextBoxColumn colSDT = new DataGridViewTextBoxColumn();
            colSDT.Name = "colSDT";
            colSDT.HeaderText = "SĐT LIÊN HỆ";
            colSDT.DataPropertyName = "SDTNguoiNhan";
            colSDT.FillWeight = 12;
            colSDT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoHang.Columns.Add(colSDT);

            // 6. Trạng thái giao hàng
            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn();
            colTrangThai.Name = "colTrangThaiGiao";
            colTrangThai.HeaderText = "TRẠNG THÁI GIAO";
            colTrangThai.DataPropertyName = "TrangThaiGiaoHang";
            colTrangThai.FillWeight = 13;
            colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoHang.Columns.Add(colTrangThai);

            dgvGiaoHang.AllowUserToResizeColumns = true;
            dgvGiaoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ==========================================
        // TẢI DỮ LIỆU TỪ POSTGRESQL (AUTO REFRESH)
        // ==========================================
        private void LoadDataGiaoHang()
        {
            // Lưu lại vị trí dòng người dùng đang chọn để không bị giật/mất vị trí khi auto reload
            int currentRowIndex = -1;
            if (dgvGiaoHang.CurrentRow != null)
            {
                currentRowIndex = dgvGiaoHang.CurrentRow.Index;
            }

            string query = @"
                SELECT 
                    GH.ID_GH,
                    DH.ID_DH,
                    KH.TenDoanhNghiep,
                    COALESCE(GH.NguoiNhan, KH.NguoiDaiDien) AS NguoiNhan,
                    COALESCE(GH.DiaChiGiaoHang, KH.DiaChi) AS DiaChiGiaoHang,
                    COALESCE(GH.SDTNguoiNhan, KH.SDT) AS SDTNguoiNhan,
                    COALESCE(GH.TrangThaiGiaoHang, N'Chưa giao') AS TrangThaiGiaoHang
                FROM DonHang DH
                INNER JOIN KhachHang KH ON DH.ID_KH = KH.ID_KH
                LEFT JOIN GiaoHang GH ON DH.ID_DH = GH.ID_DH
                ORDER BY DH.NgayTao DESC";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dtTemp = new DataTable();
                    da.Fill(dtTemp);

                    dtGiaoHang = dtTemp;
                    LocDuLieu();

                    // Khôi phục vị trí dòng được chọn trước khi làm mới
                    if (currentRowIndex >= 0 && currentRowIndex < dgvGiaoHang.Rows.Count)
                    {
                        dgvGiaoHang.Rows[currentRowIndex].Selected = true;
                    }
                }
                catch
                {
                    // Tùy chọn bỏ qua thông báo lỗi popup để tránh gián đoạn người dùng khi mất mạng thoáng qua
                }
            }
        }

        private void dgvGiaoHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGiaoHang.Columns[e.ColumnIndex].Name == "colTrangThaiGiao" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Đã giao")
                {
                    e.CellStyle.BackColor = Color.FromArgb(212, 237, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "Đang giao")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                    e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "Chờ giao" || status == "Chưa giao")
                {
                    e.CellStyle.BackColor = Color.FromArgb(248, 215, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            if (dtGiaoHang == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            if (keyword == "Tìm mã đơn, địa chỉ, người nhận, NV giao...") keyword = "";

            string statusFilter = cboFilterStatus.SelectedItem?.ToString();

            DataView dv = dtGiaoHang.DefaultView;
            string filter = "1=1";

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $" AND (ID_DH LIKE '%{keyword}%' OR TenDoanhNghiep LIKE '%{keyword}%' OR NguoiNhan LIKE '%{keyword}%' OR DiaChiGiaoHang LIKE '%{keyword}%' OR SDTNguoiNhan LIKE '%{keyword}%')";
            }

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Tất cả trạng thái")
            {
                filter += $" AND TrangThaiGiaoHang = '{statusFilter}'";
            }

            dv.RowFilter = filter;
            dgvGiaoHang.DataSource = dv;
        }

        // ==========================================
        // XỬ LÝ PHÂN CÔNG & ĐỒNG BỘ SANG LOGISTICS
        // ==========================================
        private void btnPhanCongNV_Click(object sender, EventArgs e)
        {
            if (dgvGiaoHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng trong danh sách để phân công vận chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idDH = dgvGiaoHang.CurrentRow.Cells["colIDDH"].Value?.ToString();
            string tenKhach = dgvGiaoHang.CurrentRow.Cells["colTenKhachHang"].Value?.ToString();
            string trangThaiHienTai = dgvGiaoHang.CurrentRow.Cells["colTrangThaiGiao"].Value?.ToString();

            if (trangThaiHienTai == "Đang giao" || trangThaiHienTai == "Đã giao")
            {
                MessageBox.Show($"Đơn hàng [{idDH}] đang ở trạng thái '{trangThaiHienTai}'.\nKhông thể phân công lại cho đơn đã hoặc đang vận chuyển!",
                                "Không thể phân công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận chuyển thông tin vận chuyển đơn hàng [{idDH}] ({tenKhach}) sang Phân hệ Vận Chuyển?",
                "Thông báo phân công",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                CapNhatTrangThaiGiaoCSDL(idDH, "Đang giao");

                MessageBox.Show($"Đã phát yêu cầu điều phối vận chuyển cho đơn hàng [{idDH}] thành công!\nThông tin đơn đã được chuyển sang bộ phận vận chuyển.",
                                "Phân công thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadDataGiaoHang();
            }
        }

        private void CapNhatTrangThaiGiaoCSDL(string idDH, string trangThaiMoi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string sqlGiaoHang = @"
                            INSERT INTO GiaoHang (ID_DH, TrangThaiGiaoHang)
                            VALUES (@ID_DH, @TrangThai)
                            ON CONFLICT (ID_DH) 
                            DO UPDATE SET TrangThaiGiaoHang = EXCLUDED.TrangThaiGiaoHang;";

                        using (NpgsqlCommand cmd1 = new NpgsqlCommand(sqlGiaoHang, conn, transaction))
                        {
                            cmd1.Parameters.AddWithValue("@ID_DH", idDH);
                            cmd1.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                            cmd1.ExecuteNonQuery();
                        }

                        if (trangThaiMoi == "Đã giao")
                        {
                            string sqlHoaDon = "UPDATE HoaDon SET TrangThai = N'Đã thanh toán' WHERE ID_DH = @ID_DH;";
                            using (NpgsqlCommand cmd2 = new NpgsqlCommand(sqlHoaDon, conn, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@ID_DH", idDH);
                                cmd2.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật CSDL: " + ex.Message, "Lỗi PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // KHU VỰC ĐIỀU HƯỚNG SIDEBAR
        // ==========================================
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            QlySanPham qlySanPhamForm = new QlySanPham();
            qlySanPhamForm.ShowDialog();
            this.Close();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            QlyDonHang qlyDonHangForm = new QlyDonHang();
            qlyDonHangForm.ShowDialog();
            this.Close();
        }

        private void btnNhaPhanPhoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            QlyKhachHang qlyKhachHangForm = new QlyKhachHang();
            qlyKhachHangForm.ShowDialog();
            this.Close();
        }

        private void btnHangTraLoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            XulyHangLoi xulyHangLoiForm = new XulyHangLoi();
            xulyHangLoiForm.ShowDialog();
            this.Close();
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            QlyGiaoHang qlyGiaoHangForm = new QlyGiaoHang();
            qlyGiaoHangForm.ShowDialog();
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCaoThongKe baoCaoThongKeForm = new BaoCaoThongKe();
            baoCaoThongKeForm.ShowDialog();
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn ĐĂNG XUẤT và quay lại màn hình đăng nhập?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string tempPath = System.IO.Path.Combine(Application.StartupPath, "session.txt");
                    if (System.IO.File.Exists(tempPath))
                    {
                        System.IO.File.Delete(tempPath);
                    }

                    string baseDir = Application.StartupPath;
                    string targetExe = "ERP_Khach.exe";
                    string pathExeDangNhap = "";

                    string[] possiblePaths = new string[]
                    {
                        System.IO.Path.Combine(baseDir, targetExe),
                        System.IO.Path.Combine(baseDir, "..", targetExe),
                        System.IO.Path.Combine(baseDir, "..", "ERP_Khach", targetExe),
                        System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"..\..\..\..\ERP_Khach\bin\Debug\ERP_Khach.exe")),
                        System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"..\..\..\..\ERP_Khach\bin\Release\ERP_Khach.exe"))
                    };

                    foreach (string p in possiblePaths)
                    {
                        if (System.IO.File.Exists(p))
                        {
                            pathExeDangNhap = p;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(pathExeDangNhap))
                    {
                        System.Diagnostics.Process.Start(pathExeDangNhap);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy file ứng dụng Đăng nhập (ERP_Khach.exe)!\nVui lòng kiểm tra lại thư mục chứa file.",
                                        "Lỗi khởi chạy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đăng xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
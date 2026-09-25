using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql; // Kết nối PostgreSQL

namespace ERP_BanHang
{
    public partial class XulyHangLoi : Form
    {
        // Chuỗi kết nối PostgreSQL
        private string connectionString = ConfigurationManager.ConnectionStrings["ERP_Connection"]?.ConnectionString
            ?? ConfigurationManager.ConnectionStrings["ERP_BanHang"]?.ConnectionString;

        private DataTable dtYeuCau;

        // Trạng thái tab hiện tại: true = Cần xử lý (Chờ xử lý, Đang xử lý), false = Đã xử lý
        private bool isTabCanXuLy = true;

        // Khai báo Timer để Auto Load dữ liệu ngầm
        private Timer autoLoadTimer;

        public XulyHangLoi()
        {
            InitializeComponent();
            KhoiTaoAutoLoadTimer(); // Khởi tạo bộ đếm Auto Load
        }

        // ==========================================
        // CẤU HÌNH AUTO LOAD TIMER (5 GIÂY / LẦN)
        // ==========================================
        private void KhoiTaoAutoLoadTimer()
        {
            autoLoadTimer = new Timer();
            autoLoadTimer.Interval = 5000; // Tải lại dữ liệu mỗi 5000ms (5 giây)
            autoLoadTimer.Tick += AutoLoadTimer_Tick;
        }

        private void AutoLoadTimer_Tick(object sender, EventArgs e)
        {
            // Tự động reload danh sách yêu cầu hàng lỗi từ CSDL PostgreSQL
            LoadDataYeuCauSauBanHang();
        }

        private void XulyHangLoi_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            KhoiTaoCotBang();
            LoadDataLoaiYeuCau();
            LoadDataYeuCauSauBanHang();

            // Đăng ký sự kiện vòng đời Form để quản lý Timer
            this.Activated += XulyHangLoi_Activated;
            this.Deactivate += XulyHangLoi_Deactivate;
            this.FormClosing += XulyHangLoi_FormClosing;

            // Bắt đầu Auto Load
            autoLoadTimer.Start();
        }

        // Tự động bật/tắt Timer khi chuyển Tab hoặc đóng Form để tối ưu bộ nhớ
        private void XulyHangLoi_Activated(object sender, EventArgs e)
        {
            LoadDataYeuCauSauBanHang();
            if (autoLoadTimer != null && !autoLoadTimer.Enabled)
            {
                autoLoadTimer.Start();
            }
        }

        private void XulyHangLoi_Deactivate(object sender, EventArgs e)
        {
            if (autoLoadTimer != null)
            {
                autoLoadTimer.Stop();
            }
        }

        private void XulyHangLoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (autoLoadTimer != null)
            {
                autoLoadTimer.Stop();
                autoLoadTimer.Dispose();
            }
        }

        private void KhoiTaoCotBang()
        {
            BangYeuCau.Columns.Clear();
            BangYeuCau.AutoGenerateColumns = false;

            // 1. Mã Yêu Cầu
            DataGridViewTextBoxColumn colIDYC = new DataGridViewTextBoxColumn();
            colIDYC.Name = "colIDYC";
            colIDYC.HeaderText = "MÃ YC";
            colIDYC.DataPropertyName = "ID_YC";
            colIDYC.FillWeight = 8;
            colIDYC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIDYC.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colIDYC.DefaultCellStyle.ForeColor = Color.FromArgb(13, 110, 253);
            BangYeuCau.Columns.Add(colIDYC);

            // 2. Mã Đơn Hàng
            DataGridViewTextBoxColumn colIDDH = new DataGridViewTextBoxColumn();
            colIDDH.Name = "colIDDH";
            colIDDH.HeaderText = "MÃ ĐƠN";
            colIDDH.DataPropertyName = "ID_DH";
            colIDDH.FillWeight = 8;
            colIDDH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BangYeuCau.Columns.Add(colIDDH);

            // 3. Tên Khách Hàng / Doanh Nghiệp
            DataGridViewTextBoxColumn colTenKH = new DataGridViewTextBoxColumn();
            colTenKH.Name = "colTenKhachHang";
            colTenKH.HeaderText = "KHÁCH HÀNG / DOANH NGHIỆP";
            colTenKH.DataPropertyName = "TenDoanhNghiep";
            colTenKH.FillWeight = 18;
            BangYeuCau.Columns.Add(colTenKH);

            // 4. Sản Phẩm Lỗi/Trả
            DataGridViewTextBoxColumn colTenHang = new DataGridViewTextBoxColumn();
            colTenHang.Name = "colTenHang";
            colTenHang.HeaderText = "SẢN PHẨM LỖI/TRẢ";
            colTenHang.DataPropertyName = "TenHang";
            colTenHang.FillWeight = 16;
            BangYeuCau.Columns.Add(colTenHang);

            // 5. Số Lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "colSoLuong";
            colSoLuong.HeaderText = "SL LỖI";
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.FillWeight = 6;
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoLuong.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BangYeuCau.Columns.Add(colSoLuong);

            // 6. Loại Yêu Cầu
            DataGridViewTextBoxColumn colLoaiYC = new DataGridViewTextBoxColumn();
            colLoaiYC.Name = "colLoaiYeuCau";
            colLoaiYC.HeaderText = "LOẠI YÊU CẦU";
            colLoaiYC.DataPropertyName = "LoaiYeuCau";
            colLoaiYC.FillWeight = 10;
            BangYeuCau.Columns.Add(colLoaiYC);

            // 7. Tình Trạng / Mô Tả
            DataGridViewTextBoxColumn colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.Name = "colTinhTrang";
            colTinhTrang.HeaderText = "CHI TIẾT TÌNH TRẠNG LỖI";
            colTinhTrang.DataPropertyName = "TinhTrangLoi";
            colTinhTrang.FillWeight = 16;
            BangYeuCau.Columns.Add(colTinhTrang);

            // 8. Nhân Viên Phụ Trách
            DataGridViewTextBoxColumn colNV = new DataGridViewTextBoxColumn();
            colNV.Name = "colTenNV";
            colNV.HeaderText = "NV XỬ LÝ";
            colNV.DataPropertyName = "TenNV";
            colNV.FillWeight = 11;
            BangYeuCau.Columns.Add(colNV);

            // 9. Trạng Thái Xử Lý
            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn();
            colTrangThai.Name = "colTrangThai";
            colTrangThai.HeaderText = "TRẠNG THÁI";
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.FillWeight = 10;
            colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BangYeuCau.Columns.Add(colTrangThai);

            // 10. CỘT NÚT BẤM "THAO TÁC"
            DataGridViewButtonColumn colThaoTac = new DataGridViewButtonColumn();
            colThaoTac.Name = "colThaoTac";
            colThaoTac.HeaderText = "THAO TÁC";
            colThaoTac.Text = "🔍 Chi tiết";
            colThaoTac.UseColumnTextForButtonValue = true;
            colThaoTac.FlatStyle = FlatStyle.Flat;
            colThaoTac.FillWeight = 9;
            colThaoTac.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BangYeuCau.Columns.Add(colThaoTac);

            BangYeuCau.AllowUserToResizeColumns = true;
            BangYeuCau.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDataLoaiYeuCau()
        {
            string query = "SELECT DISTINCT LoaiYeuCau FROM YeuCauSauBanHang WHERE LoaiYeuCau IS NOT NULL";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            cboFilterType.Items.Clear();
                            cboFilterType.Items.Add("Tất cả loại yêu cầu");

                            while (reader.Read())
                            {
                                cboFilterType.Items.Add(reader["LoaiYeuCau"].ToString());
                            }

                            cboFilterType.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải loại yêu cầu: " + ex.Message, "Lỗi PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // TẢI DỮ LIỆU TỪ POSTGRESQL (AUTO REFRESH)
        // ==========================================
        private void LoadDataYeuCauSauBanHang()
        {
            // Lưu lại vị trí dòng người dùng đang chọn để không bị giật con trỏ chuột khi auto reload
            int currentRowIndex = -1;
            if (BangYeuCau.CurrentRow != null)
            {
                currentRowIndex = BangYeuCau.CurrentRow.Index;
            }

            string query = @"
                SELECT 
                    YC.ID_YC,
                    YC.ID_DH,
                    KH.TenDoanhNghiep,
                    HH.TenHang,
                    CTYC.SoLuong,
                    YC.LoaiYeuCau,
                    COALESCE(CTYC.TinhTrang, YC.MoTa) AS TinhTrangLoi,
                    COALESCE(NV.TenNV, N'Chưa phân công') AS TenNV,
                    YC.TrangThai,
                    YC.NgayYeuCau
                FROM YeuCauSauBanHang YC
                INNER JOIN KhachHang KH ON YC.ID_KH = KH.ID_KH
                LEFT JOIN NhanVien NV ON YC.ID_NV = NV.ID_NV
                LEFT JOIN ChiTietYeuCau CTYC ON YC.ID_YC = CTYC.ID_YC
                LEFT JOIN SanPham SP ON CTYC.ID_SP = SP.ID_SP
                LEFT JOIN HangHoa HH ON SP.MaHang = HH.MaHang
                ORDER BY YC.NgayYeuCau DESC";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dtTemp = new DataTable();
                    da.Fill(dtTemp);

                    dtYeuCau = dtTemp;
                    LocDuLieu();

                    // Khôi phục vị trí dòng được chọn trước khi reload
                    if (currentRowIndex >= 0 && currentRowIndex < BangYeuCau.Rows.Count)
                    {
                        BangYeuCau.Rows[currentRowIndex].Selected = true;
                    }
                }
                catch
                {
                    // Bỏ qua popup báo lỗi trong timer để không ngắt quãng trải nghiệm người dùng
                }
            }
        }

        private void BangYeuCau_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (BangYeuCau.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Đã xử lý")
                {
                    e.CellStyle.BackColor = Color.FromArgb(212, 237, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "Đang xử lý")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                    e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "Chờ xử lý")
                {
                    e.CellStyle.BackColor = Color.FromArgb(248, 215, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        // ==========================================
        // SỰ KIỆN CHUYỂN ĐỔI TAB BẢNG XỬ LÝ
        // ==========================================
        private void btnTabCanXuLy_Click(object sender, EventArgs e)
        {
            isTabCanXuLy = true;
            CapNhatGiaoDienTab();
            LocDuLieu();
        }

        private void btnTabDaXuLy_Click(object sender, EventArgs e)
        {
            isTabCanXuLy = false;
            CapNhatGiaoDienTab();
            LocDuLieu();
        }

        private void CapNhatGiaoDienTab()
        {
            if (isTabCanXuLy)
            {
                btnTabCanXuLy.BackColor = Color.FromArgb(13, 110, 253);
                btnTabCanXuLy.ForeColor = Color.White;

                btnTabDaXuLy.BackColor = Color.LightGray;
                btnTabDaXuLy.ForeColor = Color.Black;
            }
            else
            {
                btnTabDaXuLy.BackColor = Color.FromArgb(25, 135, 84);
                btnTabDaXuLy.ForeColor = Color.White;

                btnTabCanXuLy.BackColor = Color.LightGray;
                btnTabCanXuLy.ForeColor = Color.Black;
            }
        }

        // ==========================================
        // LỌC DỮ LIỆU THEO TRẠNG THÁI TAB VÀ TÌM KIẾM
        // ==========================================
        private void LocDuLieu()
        {
            if (dtYeuCau == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            if (keyword == "Tìm mã YC, mã đơn, khách hàng, sản phẩm...") keyword = "";

            string typeFilter = cboFilterType.SelectedItem?.ToString();

            DataView dv = dtYeuCau.DefaultView;
            string filter = "1=1";

            // Lọc theo Tab được chọn
            if (isTabCanXuLy)
            {
                filter += " AND (TrangThai = 'Chờ xử lý' OR TrangThai = 'Đang xử lý')";
            }
            else
            {
                filter += " AND TrangThai = 'Đã xử lý'";
            }

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $" AND (ID_YC LIKE '%{keyword}%' OR ID_DH LIKE '%{keyword}%' OR TenDoanhNghiep LIKE '%{keyword}%' OR TenHang LIKE '%{keyword}%' OR TinhTrangLoi LIKE '%{keyword}%')";
            }

            // Lọc theo Loại Yêu Cầu
            if (!string.IsNullOrEmpty(typeFilter) && typeFilter != "Tất cả loại yêu cầu")
            {
                filter += $" AND LoaiYeuCau = '{typeFilter}'";
            }

            dv.RowFilter = filter;
            BangYeuCau.DataSource = dv;
        }

        // ==========================================
        // MỞ FORM ChiTietYeuCauTraHang
        // ==========================================
        private void BangYeuCau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && BangYeuCau.Columns[e.ColumnIndex].Name == "colThaoTac")
            {
                string idYC = BangYeuCau.Rows[e.RowIndex].Cells["colIDYC"].Value?.ToString();

                if (!string.IsNullOrEmpty(idYC))
                {
                    ChiTietYeuCauTraHang frmChiTiet = new ChiTietYeuCauTraHang(idYC);

                    // Nếu đang ở Tab "Đã xử lý", ẩn nút xác nhận lỗi trong Form chi tiết
                    if (!isTabCanXuLy)
                    {
                        Control[] controls = frmChiTiet.Controls.Find("btnXacNhanChuyenVC", true);
                        if (controls.Length > 0 && controls[0] is Button btnXacNhan)
                        {
                            btnXacNhan.Enabled = false;
                            btnXacNhan.Visible = false;
                        }
                    }

                    frmChiTiet.ShowDialog();

                    // Tải lại dữ liệu sau khi đóng Form chi tiết
                    LoadDataYeuCauSauBanHang();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
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
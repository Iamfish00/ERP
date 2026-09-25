using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace ERP_BanHang
{
    public partial class QlyKhachHang : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ERP_Connection"]?.ConnectionString
            ?? ConfigurationManager.ConnectionStrings["ERP_BanHang"]?.ConnectionString;

        private DataTable dtKhachHang;

        // Biến xử lý tính năng Nhấn giữ chuột lâu để Xóa (Long-press)
        private Timer longPressTimer;
        private int selectedRowIndexForDelete = -1;
        private const int LONG_PRESS_DURATION = 1000; // Thời gian giữ chuột: 1000ms (1 giây)

        // Khai báo Timer cho tính năng Auto Load dữ liệu ngầm
        private Timer autoLoadTimer;

        public QlyKhachHang()
        {
            InitializeComponent();
            KhoiTaoLongPressTimer();
            KhoiTaoAutoLoadTimer(); // Khởi tạo bộ đếm thời gian
        }

        private void KhoiTaoLongPressTimer()
        {
            longPressTimer = new Timer();
            longPressTimer.Interval = LONG_PRESS_DURATION;
            longPressTimer.Tick += LongPressTimer_Tick;
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
            // Gọi hàm cập nhật dữ liệu tự động từ PostgreSQL
            LoadDataKhachHang();
        }

        private void QlyKhachHang_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            KhoiTaoCotBang();
            LoadDataKhachHang();

            // Đăng ký sự kiện nhấn/nhả chuột & double-click cho DataGridView
            BangKhachHang.MouseDown += BangKhachHang_MouseDown;
            BangKhachHang.MouseUp += BangKhachHang_MouseUp;
            BangKhachHang.CellDoubleClick += BangKhachHang_CellDoubleClick;

            // Đăng ký sự kiện vòng đời Form để quản lý Timer tiết kiệm tài nguyên
            this.Activated += QlyKhachHang_Activated;
            this.Deactivate += QlyKhachHang_Deactivate;
            this.FormClosing += QlyKhachHang_FormClosing;

            // Bắt đầu Auto Load
            autoLoadTimer.Start();
        }

        // Tự động Bật/Tắt Timer khi người dùng chuyển Tab/Ứng dụng khác
        private void QlyKhachHang_Activated(object sender, EventArgs e)
        {
            LoadDataKhachHang();
            if (autoLoadTimer != null && !autoLoadTimer.Enabled)
            {
                autoLoadTimer.Start();
            }
        }

        private void QlyKhachHang_Deactivate(object sender, EventArgs e)
        {
            if (autoLoadTimer != null)
            {
                autoLoadTimer.Stop();
            }
        }

        private void QlyKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (autoLoadTimer != null)
            {
                autoLoadTimer.Stop();
                autoLoadTimer.Dispose();
            }
        }

        private void KhoiTaoCotBang()
        {
            BangKhachHang.Columns.Clear();
            BangKhachHang.AutoGenerateColumns = false;

            // 1. Mã khách hàng
            DataGridViewTextBoxColumn colMaKH = new DataGridViewTextBoxColumn();
            colMaKH.Name = "colMaKH";
            colMaKH.HeaderText = "MÃ KHÁCH HÀNG";
            colMaKH.DataPropertyName = "ID_KH";
            colMaKH.FillWeight = 12;
            colMaKH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaKH.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaKH.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colMaKH.DefaultCellStyle.ForeColor = Color.FromArgb(13, 110, 253);
            BangKhachHang.Columns.Add(colMaKH);

            // 2. Tên doanh nghiệp / Đại lý
            DataGridViewTextBoxColumn colTenDoanhNghiep = new DataGridViewTextBoxColumn();
            colTenDoanhNghiep.Name = "colTenDoanhNghiep";
            colTenDoanhNghiep.HeaderText = "TÊN DOANH NGHIỆP / ĐẠI LÝ";
            colTenDoanhNghiep.DataPropertyName = "TenDoanhNghiep";
            colTenDoanhNghiep.FillWeight = 25;
            BangKhachHang.Columns.Add(colTenDoanhNghiep);

            // 3. Người đại diện
            DataGridViewTextBoxColumn colNguoiDaiDien = new DataGridViewTextBoxColumn();
            colNguoiDaiDien.Name = "colNguoiDaiDien";
            colNguoiDaiDien.HeaderText = "NGƯỜI ĐẠI DIỆN";
            colNguoiDaiDien.DataPropertyName = "NguoiDaiDien";
            colNguoiDaiDien.FillWeight = 18;
            BangKhachHang.Columns.Add(colNguoiDaiDien);

            // 4. Số điện thoại
            DataGridViewTextBoxColumn colSDT = new DataGridViewTextBoxColumn();
            colSDT.Name = "colSDT";
            colSDT.HeaderText = "SỐ ĐIỆN THOẠI";
            colSDT.DataPropertyName = "SDT";
            colSDT.FillWeight = 13;
            colSDT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSDT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BangKhachHang.Columns.Add(colSDT);

            // 5. Địa chỉ
            DataGridViewTextBoxColumn colDiaChi = new DataGridViewTextBoxColumn();
            colDiaChi.Name = "colDiaChi";
            colDiaChi.HeaderText = "ĐỊA CHỈ";
            colDiaChi.DataPropertyName = "DiaChi";
            colDiaChi.FillWeight = 22;
            BangKhachHang.Columns.Add(colDiaChi);

            // 6. Mã số thuế
            DataGridViewTextBoxColumn colMST = new DataGridViewTextBoxColumn();
            colMST.Name = "colMST";
            colMST.HeaderText = "MÃ SỐ THUẾ";
            colMST.DataPropertyName = "MST";
            colMST.FillWeight = 10;
            colMST.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMST.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BangKhachHang.Columns.Add(colMST);

            BangKhachHang.AllowUserToResizeColumns = true;
            BangKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ==========================================
        // TẢI DỮ LIỆU TỪ CSDL (GIỮ VỊ TRÍ CHỌN)
        // ==========================================
        private void LoadDataKhachHang()
        {
            // Lưu lại vị trí dòng người dùng đang chọn để không bị nhảy con trỏ chuột khi tự động refresh
            int currentRowIndex = -1;
            if (BangKhachHang.CurrentRow != null)
            {
                currentRowIndex = BangKhachHang.CurrentRow.Index;
            }

            string query = @"
                SELECT 
                    ID_KH,
                    TenDoanhNghiep,
                    COALESCE(NguoiDaiDien, N'Chưa rõ') AS NguoiDaiDien,
                    SDT,
                    DiaChi,
                    MaSoThue AS MST
                FROM KhachHang
                ORDER BY ID_KH ASC";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dtTemp = new DataTable();
                    da.Fill(dtTemp);

                    dtKhachHang = dtTemp;
                    LocDuLieu();

                    // Khôi phục vị trí dòng được chọn trước khi làm mới
                    if (currentRowIndex >= 0 && currentRowIndex < BangKhachHang.Rows.Count)
                    {
                        BangKhachHang.Rows[currentRowIndex].Selected = true;
                    }
                }
                catch
                {
                    // Giữ im lặng khi bị ngắt kết nối mạng thoáng qua trong quá trình timer chạy ngầm
                }
            }
        }

        // ==========================================
        // KHU VỰC HÀNH ĐỘNG (THÊM, SỬA, XÓA, LỌC TÌM KIẾM)
        // ==========================================

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            ThemKhachHang themKhachHangForm = new ThemKhachHang();
            if (themKhachHangForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataKhachHang();
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            MoFormSuaKhachHang();
        }

        private void BangKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cho phép nhấp đúp vào dòng bất kỳ để sửa trực tiếp
            if (e.RowIndex >= 0)
            {
                MoFormSuaKhachHang();
            }
        }

        private void MoFormSuaKhachHang()
        {
            if (BangKhachHang.CurrentRow == null || BangKhachHang.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng trong danh sách để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = BangKhachHang.CurrentRow.Cells["colMaKH"].Value?.ToString();

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SuaKhachHang suaForm = new SuaKhachHang(maKH);
            if (suaForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataKhachHang();
            }
        }

        // ==========================================
        // THAO TÁC LONG-PRESS ĐỂ XÓA
        // ==========================================

        private void BangKhachHang_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = BangKhachHang.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    selectedRowIndexForDelete = hit.RowIndex;
                    longPressTimer.Start();
                }
            }
        }

        private void BangKhachHang_MouseUp(object sender, MouseEventArgs e)
        {
            longPressTimer.Stop();
        }

        private void LongPressTimer_Tick(object sender, EventArgs e)
        {
            longPressTimer.Stop();

            if (selectedRowIndexForDelete >= 0 && selectedRowIndexForDelete < BangKhachHang.Rows.Count)
            {
                string maKH = BangKhachHang.Rows[selectedRowIndexForDelete].Cells["colMaKH"].Value?.ToString();
                string tenDN = BangKhachHang.Rows[selectedRowIndexForDelete].Cells["colTenDoanhNghiep"].Value?.ToString();

                if (string.IsNullOrEmpty(maKH)) return;

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn XÓA khách hàng [{tenDN}] (Mã: {maKH}) khỏi hệ thống?\n\nLưu ý: Toàn bộ các đơn hàng và hóa đơn liên quan đến khách hàng này cũng sẽ bị xóa!",
                    "Xác nhận xóa khách hàng",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    XoaKhachHangCSDL(maKH);
                }
            }
        }

        private void XoaKhachHangCSDL(string maKH)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Xóa các ChiTietYeuCau & YeuCauSauBanHang của khách hàng
                        using (NpgsqlCommand cmd1 = new NpgsqlCommand(@"
                            DELETE FROM ChiTietYeuCau 
                            WHERE ID_YC IN (SELECT ID_YC FROM YeuCauSauBanHang WHERE ID_KH = @ID_KH)", conn, transaction))
                        {
                            cmd1.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd1.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmd2 = new NpgsqlCommand("DELETE FROM YeuCauSauBanHang WHERE ID_KH = @ID_KH", conn, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd2.ExecuteNonQuery();
                        }

                        // 2. Xóa các ChiTietGiaoHang/GiaoHang thuộc đơn hàng của khách hàng
                        using (NpgsqlCommand cmd3 = new NpgsqlCommand(@"
                            DELETE FROM GiaoHang 
                            WHERE ID_DH IN (SELECT ID_DH FROM DonHang WHERE ID_KH = @ID_KH)", conn, transaction))
                        {
                            cmd3.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd3.ExecuteNonQuery();
                        }

                        // 3. Xóa các ChiTietHoaDon & HoaDon liên quan
                        using (NpgsqlCommand cmd4 = new NpgsqlCommand(@"
                            DELETE FROM ChiTietHoaDon 
                            WHERE ID_HD IN (SELECT ID_HD FROM HoaDon WHERE ID_DH IN (SELECT ID_DH FROM DonHang WHERE ID_KH = @ID_KH))", conn, transaction))
                        {
                            cmd4.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd4.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmd5 = new NpgsqlCommand(@"
                            DELETE FROM HoaDon 
                            WHERE ID_DH IN (SELECT ID_DH FROM DonHang WHERE ID_KH = @ID_KH)", conn, transaction))
                        {
                            cmd5.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd5.ExecuteNonQuery();
                        }

                        // 4. Xóa các ChiTietDonHang & DonHang
                        using (NpgsqlCommand cmd6 = new NpgsqlCommand(@"
                            DELETE FROM ChiTietDonHang 
                            WHERE ID_DH IN (SELECT ID_DH FROM DonHang WHERE ID_KH = @ID_KH)", conn, transaction))
                        {
                            cmd6.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd6.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmd7 = new NpgsqlCommand("DELETE FROM DonHang WHERE ID_KH = @ID_KH", conn, transaction))
                        {
                            cmd7.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd7.ExecuteNonQuery();
                        }

                        // 5. Cuối cùng mới xóa trong bảng KhachHang
                        using (NpgsqlCommand cmd8 = new NpgsqlCommand("DELETE FROM KhachHang WHERE ID_KH = @ID_KH", conn, transaction))
                        {
                            cmd8.Parameters.AddWithValue("@ID_KH", maKH);
                            cmd8.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show($"Đã xóa thành công khách hàng [{maKH}]!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataKhachHang();
                    }
                    catch (Exception exInner)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa dữ liệu liên quan: " + exInner.Message, "Lỗi PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // KHU VỰC TÌM KIẾM DỮ LIỆU
        // ==========================================

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            if (dtKhachHang == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            if (keyword == "Tìm mã KH, tên doanh nghiệp, người đại diện, SĐT...") keyword = "";

            DataView dv = dtKhachHang.DefaultView;
            string filter = "1=1";

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $" AND (ID_KH LIKE '%{keyword}%' OR TenDoanhNghiep LIKE '%{keyword}%' OR NguoiDaiDien LIKE '%{keyword}%' OR SDT LIKE '%{keyword}%' OR MST LIKE '%{keyword}%')";
            }

            dv.RowFilter = filter;
            BangKhachHang.DataSource = dv;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm mã KH, tên doanh nghiệp, người đại diện, SĐT...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm mã KH, tên doanh nghiệp, người đại diện, SĐT...";
                txtSearch.ForeColor = Color.Gray;
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
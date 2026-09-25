using System;
using System.Configuration;
using System.Data;
using Npgsql; // Thay thế cho System.Data.SqlClient
using System.Drawing;
using System.Windows.Forms;

namespace ERP_BanHang
{
    public partial class QlySanPham : Form
    {
        // Chuỗi kết nối PostgreSQL CSDL ERP_BanHang
        private string connectionString = ConfigurationManager.ConnectionStrings["ERP_Connection"].ConnectionString;
        private DataTable dtSanPham;
        private bool isInitializing = true;

        public QlySanPham()
        {
            InitializeComponent();
        }

        private void QlySanPham_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            isInitializing = true;

            KhoiTaoCotBang();
            LoadDanhMucIntoComboBox(); // Load danh mục LoaiSP từ CSDL PostgreSQL

            isInitializing = false;
            LoadDataSanPham();          // Load danh sách sản phẩm kết hợp HangHoa ngay lập tức khi mở form
        }

        private void KhoiTaoCotBang()
        {
            BangSanPham.Columns.Clear();
            BangSanPham.AutoGenerateColumns = false;

            // 1. Mã SP
            DataGridViewTextBoxColumn colIDSP = new DataGridViewTextBoxColumn();
            colIDSP.Name = "colIDSP";
            colIDSP.HeaderText = "MÃ SẢN PHẨM";
            colIDSP.DataPropertyName = "ID_SP";
            colIDSP.FillWeight = 10;
            colIDSP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIDSP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIDSP.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colIDSP.DefaultCellStyle.ForeColor = Color.FromArgb(13, 110, 253);
            BangSanPham.Columns.Add(colIDSP);

            // 2. Tên Sản Phẩm
            DataGridViewTextBoxColumn colTenHang = new DataGridViewTextBoxColumn();
            colTenHang.Name = "colTenHang";
            colTenHang.HeaderText = "TÊN SẢN PHẨM";
            colTenHang.DataPropertyName = "TenHang";
            colTenHang.FillWeight = 25;
            colTenHang.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            BangSanPham.Columns.Add(colTenHang);

            // 3. Loại SP
            DataGridViewTextBoxColumn colLoaiSP = new DataGridViewTextBoxColumn();
            colLoaiSP.Name = "colLoaiSP";
            colLoaiSP.HeaderText = "LOẠI SẢN PHẨM";
            colLoaiSP.DataPropertyName = "LoaiSP";
            colLoaiSP.FillWeight = 15;
            colLoaiSP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            BangSanPham.Columns.Add(colLoaiSP);

            // 4. Thương Hiệu
            DataGridViewTextBoxColumn colThuongHieu = new DataGridViewTextBoxColumn();
            colThuongHieu.Name = "colThuongHieu";
            colThuongHieu.HeaderText = "THƯƠNG HIỆU";
            colThuongHieu.DataPropertyName = "ThuongHieu";
            colThuongHieu.FillWeight = 14;
            colThuongHieu.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            BangSanPham.Columns.Add(colThuongHieu);

            // 5. Đơn Vi Tinh (MỚI BỔ SUNG)
            DataGridViewTextBoxColumn colDonViTinh = new DataGridViewTextBoxColumn();
            colDonViTinh.Name = "colDonViTinh";
            colDonViTinh.HeaderText = "ĐƠN VỊ TÍNH";
            colDonViTinh.DataPropertyName = "DonViTinh";
            colDonViTinh.FillWeight = 10;
            colDonViTinh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDonViTinh.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BangSanPham.Columns.Add(colDonViTinh);

            // 6. Đơn Giá 
            DataGridViewTextBoxColumn colGiaSP = new DataGridViewTextBoxColumn();
            colGiaSP.Name = "colGiaSP";
            colGiaSP.HeaderText = "ĐƠN GIÁ";
            colGiaSP.DataPropertyName = "GiaSP";
            colGiaSP.FillWeight = 13;
            colGiaSP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGiaSP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colGiaSP.DefaultCellStyle.Format = "N0";
            BangSanPham.Columns.Add(colGiaSP);

            // 7. Tồn Kho / Số Lượng Hàng Hoá
            DataGridViewTextBoxColumn colTonKho = new DataGridViewTextBoxColumn();
            colTonKho.Name = "colTonKho";
            colTonKho.HeaderText = "SỐ LƯỢNG TỒN";
            colTonKho.DataPropertyName = "TonKho";
            colTonKho.FillWeight = 13;
            colTonKho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTonKho.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTonKho.DefaultCellStyle.Format = "N0";
            BangSanPham.Columns.Add(colTonKho);

            BangSanPham.AllowUserToResizeColumns = true;
            BangSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDataSanPham()
        {
            // JOIN giữa SanPham và HangHoa, lấy thêm cột DonViTinh
            string query = @"
                SELECT 
                    SP.ID_SP,
                    HH.TenHang,
                    SP.LoaiSP,
                    SP.ThuongHieu,
                    HH.DonViTinh,
                    SP.GiaSP,
                    HH.TonKho
                FROM SanPham SP
                INNER JOIN HangHoa HH ON SP.MaHang = HH.MaHang
                ORDER BY SP.ID_SP ASC";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    dtSanPham = new DataTable();
                    da.Fill(dtSanPham);

                    BangSanPham.DataSource = dtSanPham;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL khi tải sản phẩm: " + ex.Message, "Lỗi PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDanhMucIntoComboBox()
        {
            string query = "SELECT DISTINCT LoaiSP FROM SanPham WHERE LoaiSP IS NOT NULL";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dtLoai = new DataTable();
                    da.Fill(dtLoai);

                    DataRow dr = dtLoai.NewRow();
                    dr["LoaiSP"] = "Tất cả loại sản phẩm";
                    dtLoai.Rows.InsertAt(dr, 0);

                    cboFilterCategory.DataSource = dtLoai;
                    cboFilterCategory.DisplayMember = "LoaiSP";
                    cboFilterCategory.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh mục sản phẩm: " + ex.Message, "Lỗi PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BangSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (BangSanPham.Columns[e.ColumnIndex].Name == "colTonKho" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int tonKho))
                {
                    if (tonKho == 0)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(248, 215, 218);
                        e.CellStyle.ForeColor = Color.FromArgb(114, 28, 36);
                        e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    else if (tonKho < 2500)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                        e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            if (dtSanPham == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''");
            if (keyword == "Tìm mã SP, tên sản phẩm...") keyword = "";

            string selectedCategory = cboFilterCategory.Text;

            DataView dv = dtSanPham.DefaultView;
            string filter = "1=1";

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $" AND (ID_SP LIKE '%{keyword}%' OR TenHang LIKE '%{keyword}%' OR ThuongHieu LIKE '%{keyword}%')";
            }

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Tất cả loại sản phẩm")
            {
                filter += $" AND LoaiSP = '{selectedCategory}'";
            }

            dv.RowFilter = filter;
            BangSanPham.DataSource = dv;
        }

        // Navigation Handlers ...
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
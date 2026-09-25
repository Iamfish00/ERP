namespace ERP_BanHang
{
    partial class BaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.pnlUserBottom = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnHangTraLoi = new System.Windows.Forms.Button();
            this.btnGiaoHang = new System.Windows.Forms.Button();
            this.btnNhaPhanPhoi = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.picBrandLogo = new System.Windows.Forms.PictureBox();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblTopUser = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlKPIContainer = new System.Windows.Forms.Panel();
            this.pnlKPI3 = new System.Windows.Forms.Panel();
            this.lblKPI3Value = new System.Windows.Forms.Label();
            this.lblKPI3Title = new System.Windows.Forms.Label();
            this.pnlKPI2 = new System.Windows.Forms.Panel();
            this.lblKPI2Value = new System.Windows.Forms.Label();
            this.lblKPI2Title = new System.Windows.Forms.Label();
            this.pnlKPI1 = new System.Windows.Forms.Panel();
            this.lblKPI1Value = new System.Windows.Forms.Label();
            this.lblKPI1Title = new System.Windows.Forms.Label();
            this.pnlFilterTool = new System.Windows.Forms.Panel();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).BeginInit();
            this.pnlTopHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlKPIContainer.SuspendLayout();
            this.pnlKPI3.SuspendLayout();
            this.pnlKPI2.SuspendLayout();
            this.pnlKPI1.SuspendLayout();
            this.pnlFilterTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.Crimson;
            this.pnlSidebar.Controls.Add(this.btnDangNhap);
            this.pnlSidebar.Controls.Add(this.pnlUserBottom);
            this.pnlSidebar.Controls.Add(this.btnThongKe);
            this.pnlSidebar.Controls.Add(this.btnHangTraLoi);
            this.pnlSidebar.Controls.Add(this.btnGiaoHang);
            this.pnlSidebar.Controls.Add(this.btnNhaPhanPhoi);
            this.pnlSidebar.Controls.Add(this.btnDonHang);
            this.pnlSidebar.Controls.Add(this.btnSanPham);
            this.pnlSidebar.Controls.Add(this.picBrandLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.ForeColor = System.Drawing.Color.White;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 750);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDangNhap.Location = new System.Drawing.Point(0, 650);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(220, 40);
            this.btnDangNhap.TabIndex = 8;
            this.btnDangNhap.Text = "Đăng xuất";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // pnlUserBottom
            // 
            this.pnlUserBottom.Controls.Add(this.lblRole);
            this.pnlUserBottom.Controls.Add(this.lblUserName);
            this.pnlUserBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserBottom.Location = new System.Drawing.Point(0, 690);
            this.pnlUserBottom.Name = "pnlUserBottom";
            this.pnlUserBottom.Size = new System.Drawing.Size(220, 60);
            this.pnlUserBottom.TabIndex = 9;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(12, 30);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(89, 19);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Quản trị viên";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(12, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(56, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Admin";
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(10, 330);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(200, 42);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Báo cáo thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = false;
            // 
            // btnHangTraLoi
            // 
            this.btnHangTraLoi.FlatAppearance.BorderSize = 0;
            this.btnHangTraLoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHangTraLoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHangTraLoi.ForeColor = System.Drawing.Color.White;
            this.btnHangTraLoi.Location = new System.Drawing.Point(0, 283);
            this.btnHangTraLoi.Name = "btnHangTraLoi";
            this.btnHangTraLoi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHangTraLoi.Size = new System.Drawing.Size(220, 42);
            this.btnHangTraLoi.TabIndex = 6;
            this.btnHangTraLoi.Text = "Xử lý hàng trả";
            this.btnHangTraLoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHangTraLoi.UseVisualStyleBackColor = true;
            this.btnHangTraLoi.Click += new System.EventHandler(this.btnHangTraLoi_Click);
            // 
            // btnGiaoHang
            // 
            this.btnGiaoHang.FlatAppearance.BorderSize = 0;
            this.btnGiaoHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaoHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGiaoHang.ForeColor = System.Drawing.Color.White;
            this.btnGiaoHang.Location = new System.Drawing.Point(0, 236);
            this.btnGiaoHang.Name = "btnGiaoHang";
            this.btnGiaoHang.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnGiaoHang.Size = new System.Drawing.Size(220, 42);
            this.btnGiaoHang.TabIndex = 5;
            this.btnGiaoHang.Text = "Quản lý giao hàng";
            this.btnGiaoHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaoHang.UseVisualStyleBackColor = true;
            this.btnGiaoHang.Click += new System.EventHandler(this.btnGiaoHang_Click);
            // 
            // btnNhaPhanPhoi
            // 
            this.btnNhaPhanPhoi.FlatAppearance.BorderSize = 0;
            this.btnNhaPhanPhoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaPhanPhoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNhaPhanPhoi.ForeColor = System.Drawing.Color.White;
            this.btnNhaPhanPhoi.Location = new System.Drawing.Point(0, 189);
            this.btnNhaPhanPhoi.Name = "btnNhaPhanPhoi";
            this.btnNhaPhanPhoi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNhaPhanPhoi.Size = new System.Drawing.Size(220, 42);
            this.btnNhaPhanPhoi.TabIndex = 4;
            this.btnNhaPhanPhoi.Text = "Quản lý khách hàng";
            this.btnNhaPhanPhoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhaPhanPhoi.UseVisualStyleBackColor = true;
            this.btnNhaPhanPhoi.Click += new System.EventHandler(this.btnNhaPhanPhoi_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.FlatAppearance.BorderSize = 0;
            this.btnDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDonHang.ForeColor = System.Drawing.Color.White;
            this.btnDonHang.Location = new System.Drawing.Point(0, 142);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDonHang.Size = new System.Drawing.Size(220, 42);
            this.btnDonHang.TabIndex = 3;
            this.btnDonHang.Text = "Quản lý đơn hàng";
            this.btnDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDonHang.UseVisualStyleBackColor = true;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSanPham.ForeColor = System.Drawing.Color.White;
            this.btnSanPham.Location = new System.Drawing.Point(0, 95);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSanPham.Size = new System.Drawing.Size(220, 42);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "Quản lý sản phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // picBrandLogo
            // 
            this.picBrandLogo.Image = global::ERP_BanHang.Properties.Resources.acecook;
            this.picBrandLogo.Location = new System.Drawing.Point(15, 12);
            this.picBrandLogo.Name = "picBrandLogo";
            this.picBrandLogo.Size = new System.Drawing.Size(190, 60);
            this.picBrandLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBrandLogo.TabIndex = 0;
            this.picBrandLogo.TabStop = false;
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.White;
            this.pnlTopHeader.Controls.Add(this.lblTopUser);
            this.pnlTopHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1060, 50);
            this.pnlTopHeader.TabIndex = 1;
            // 
            // lblTopUser
            // 
            this.lblTopUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopUser.AutoSize = true;
            this.lblTopUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTopUser.Location = new System.Drawing.Point(861, 15);
            this.lblTopUser.Name = "lblTopUser";
            this.lblTopUser.Size = new System.Drawing.Size(62, 23);
            this.lblTopUser.TabIndex = 1;
            this.lblTopUser.Text = "Admin";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(373, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Phân hệ Bán hàng - Báo cáo Thống kê & Phản hồi";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.dgvData);
            this.pnlMainContent.Controls.Add(this.pnlKPIContainer);
            this.pnlMainContent.Controls.Add(this.pnlFilterTool);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 50);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainContent.Size = new System.Drawing.Size(1060, 700);
            this.pnlMainContent.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.Gray;
            this.dgvData.Location = new System.Drawing.Point(20, 205);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 45;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1020, 475);
            this.dgvData.TabIndex = 2;
            // 
            // pnlKPIContainer
            // 
            this.pnlKPIContainer.Controls.Add(this.pnlKPI3);
            this.pnlKPIContainer.Controls.Add(this.pnlKPI2);
            this.pnlKPIContainer.Controls.Add(this.pnlKPI1);
            this.pnlKPIContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKPIContainer.Location = new System.Drawing.Point(20, 105);
            this.pnlKPIContainer.Name = "pnlKPIContainer";
            this.pnlKPIContainer.Size = new System.Drawing.Size(1020, 100);
            this.pnlKPIContainer.TabIndex = 1;
            // 
            // pnlKPI3
            // 
            this.pnlKPI3.BackColor = System.Drawing.Color.White;
            this.pnlKPI3.Controls.Add(this.lblKPI3Value);
            this.pnlKPI3.Controls.Add(this.lblKPI3Title);
            this.pnlKPI3.Location = new System.Drawing.Point(690, 10);
            this.pnlKPI3.Name = "pnlKPI3";
            this.pnlKPI3.Size = new System.Drawing.Size(320, 80);
            this.pnlKPI3.TabIndex = 2;
            // 
            // lblKPI3Value
            // 
            this.lblKPI3Value.AutoSize = true;
            this.lblKPI3Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKPI3Value.ForeColor = System.Drawing.Color.Crimson;
            this.lblKPI3Value.Location = new System.Drawing.Point(15, 35);
            this.lblKPI3Value.Name = "lblKPI3Value";
            this.lblKPI3Value.Size = new System.Drawing.Size(33, 37);
            this.lblKPI3Value.TabIndex = 1;
            this.lblKPI3Value.Text = "0";
            // 
            // lblKPI3Title
            // 
            this.lblKPI3Title.AutoSize = true;
            this.lblKPI3Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPI3Title.ForeColor = System.Drawing.Color.Gray;
            this.lblKPI3Title.Location = new System.Drawing.Point(15, 10);
            this.lblKPI3Title.Name = "lblKPI3Title";
            this.lblKPI3Title.Size = new System.Drawing.Size(192, 20);
            this.lblKPI3Title.TabIndex = 0;
            this.lblKPI3Title.Text = "PHẢN HỒI / HÀNG TRẢ LỖI";
            // 
            // pnlKPI2
            // 
            this.pnlKPI2.BackColor = System.Drawing.Color.White;
            this.pnlKPI2.Controls.Add(this.lblKPI2Value);
            this.pnlKPI2.Controls.Add(this.lblKPI2Title);
            this.pnlKPI2.Location = new System.Drawing.Point(345, 10);
            this.pnlKPI2.Name = "pnlKPI2";
            this.pnlKPI2.Size = new System.Drawing.Size(320, 80);
            this.pnlKPI2.TabIndex = 1;
            // 
            // lblKPI2Value
            // 
            this.lblKPI2Value.AutoSize = true;
            this.lblKPI2Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKPI2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblKPI2Value.Location = new System.Drawing.Point(15, 35);
            this.lblKPI2Value.Name = "lblKPI2Value";
            this.lblKPI2Value.Size = new System.Drawing.Size(33, 37);
            this.lblKPI2Value.TabIndex = 1;
            this.lblKPI2Value.Text = "0";
            // 
            // lblKPI2Title
            // 
            this.lblKPI2Title.AutoSize = true;
            this.lblKPI2Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPI2Title.ForeColor = System.Drawing.Color.Gray;
            this.lblKPI2Title.Location = new System.Drawing.Point(15, 10);
            this.lblKPI2Title.Name = "lblKPI2Title";
            this.lblKPI2Title.Size = new System.Drawing.Size(211, 20);
            this.lblKPI2Title.TabIndex = 0;
            this.lblKPI2Title.Text = "TỔNG SỐ ĐƠN HOÀN THÀNH";
            // 
            // pnlKPI1
            // 
            this.pnlKPI1.BackColor = System.Drawing.Color.White;
            this.pnlKPI1.Controls.Add(this.lblKPI1Value);
            this.pnlKPI1.Controls.Add(this.lblKPI1Title);
            this.pnlKPI1.Location = new System.Drawing.Point(0, 10);
            this.pnlKPI1.Name = "pnlKPI1";
            this.pnlKPI1.Size = new System.Drawing.Size(320, 80);
            this.pnlKPI1.TabIndex = 0;
            // 
            // lblKPI1Value
            // 
            this.lblKPI1Value.AutoSize = true;
            this.lblKPI1Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKPI1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblKPI1Value.Location = new System.Drawing.Point(15, 35);
            this.lblKPI1Value.Name = "lblKPI1Value";
            this.lblKPI1Value.Size = new System.Drawing.Size(99, 37);
            this.lblKPI1Value.TabIndex = 1;
            this.lblKPI1Value.Text = "0 VNĐ";
            // 
            // lblKPI1Title
            // 
            this.lblKPI1Title.AutoSize = true;
            this.lblKPI1Title.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKPI1Title.ForeColor = System.Drawing.Color.Gray;
            this.lblKPI1Title.Location = new System.Drawing.Point(15, 10);
            this.lblKPI1Title.Name = "lblKPI1Title";
            this.lblKPI1Title.Size = new System.Drawing.Size(179, 20);
            this.lblKPI1Title.TabIndex = 0;
            this.lblKPI1Title.Text = "DOANH THU ĐƠN HÀNG";
            // 
            // pnlFilterTool
            // 
            this.pnlFilterTool.Controls.Add(this.cboReportType);
            this.pnlFilterTool.Controls.Add(this.lblReportType);
            this.pnlFilterTool.Controls.Add(this.btnExportExcel);
            this.pnlFilterTool.Controls.Add(this.btnFilter);
            this.pnlFilterTool.Controls.Add(this.dtpToDate);
            this.pnlFilterTool.Controls.Add(this.lblToDate);
            this.pnlFilterTool.Controls.Add(this.dtpFromDate);
            this.pnlFilterTool.Controls.Add(this.lblFromDate);
            this.pnlFilterTool.Controls.Add(this.lblTitle);
            this.pnlFilterTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterTool.Location = new System.Drawing.Point(20, 20);
            this.pnlFilterTool.Name = "pnlFilterTool";
            this.pnlFilterTool.Size = new System.Drawing.Size(1020, 85);
            this.pnlFilterTool.TabIndex = 0;
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Doanh thu theo đơn hàng",
            "Phản hồi & Hàng trả lỗi"});
            this.cboReportType.Location = new System.Drawing.Point(480, 44);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(210, 29);
            this.cboReportType.TabIndex = 8;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReportType.Location = new System.Drawing.Point(410, 48);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(62, 20);
            this.lblReportType.TabIndex = 7;
            this.lblReportType.Text = "Loại BC:";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(900, 42);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 32);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "📊 Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(700, 42);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(90, 32);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "🔍 Thống kê";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(265, 44);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(130, 29);
            this.dtpToDate.TabIndex = 4;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToDate.Location = new System.Drawing.Point(200, 48);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(75, 20);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(65, 44);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(130, 29);
            this.dtpFromDate.TabIndex = 2;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFromDate.Location = new System.Drawing.Point(0, 48);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(65, 20);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(518, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo Doanh thu & Phản hồi Sản phẩm";
            // 
            // BaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1280, 750);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "BaoCaoThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP Bán Hàng - Báo Cáo Thống Kê & Phản Hồi";
            this.Load += new System.EventHandler(this.BaoCaoThongKe_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserBottom.ResumeLayout(false);
            this.pnlUserBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).EndInit();
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlKPIContainer.ResumeLayout(false);
            this.pnlKPI3.ResumeLayout(false);
            this.pnlKPI3.PerformLayout();
            this.pnlKPI2.ResumeLayout(false);
            this.pnlKPI2.PerformLayout();
            this.pnlKPI1.ResumeLayout(false);
            this.pnlKPI1.PerformLayout();
            this.pnlFilterTool.ResumeLayout(false);
            this.pnlFilterTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox picBrandLogo;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnNhaPhanPhoi;
        private System.Windows.Forms.Button btnGiaoHang;
        private System.Windows.Forms.Button btnHangTraLoi;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Panel pnlUserBottom;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblTopUser;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlFilterTool;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Panel pnlKPIContainer;
        private System.Windows.Forms.Panel pnlKPI1;
        private System.Windows.Forms.Label lblKPI1Title;
        private System.Windows.Forms.Label lblKPI1Value;
        private System.Windows.Forms.Panel pnlKPI2;
        private System.Windows.Forms.Label lblKPI2Title;
        private System.Windows.Forms.Label lblKPI2Value;
        private System.Windows.Forms.Panel pnlKPI3;
        private System.Windows.Forms.Label lblKPI3Title;
        private System.Windows.Forms.Label lblKPI3Value;
        private System.Windows.Forms.DataGridView dgvData;
    }
}
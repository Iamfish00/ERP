namespace ERP_BanHang
{
    partial class XulyHangLoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            this.BangYeuCau = new System.Windows.Forms.DataGridView();
            this.pnlActionTool = new System.Windows.Forms.Panel();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabCanXuLy = new System.Windows.Forms.Button();
            this.btnTabDaXuLy = new System.Windows.Forms.Button();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).BeginInit();
            this.pnlTopHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BangYeuCau)).BeginInit();
            this.pnlActionTool.SuspendLayout();
            this.pnlTabs.SuspendLayout();
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
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(0, 330);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(220, 42);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Báo cáo thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnHangTraLoi
            // 
            this.btnHangTraLoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnHangTraLoi.FlatAppearance.BorderSize = 0;
            this.btnHangTraLoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHangTraLoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHangTraLoi.ForeColor = System.Drawing.Color.White;
            this.btnHangTraLoi.Location = new System.Drawing.Point(10, 283);
            this.btnHangTraLoi.Name = "btnHangTraLoi";
            this.btnHangTraLoi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHangTraLoi.Size = new System.Drawing.Size(200, 42);
            this.btnHangTraLoi.TabIndex = 6;
            this.btnHangTraLoi.Text = "Xử lý hàng trả";
            this.btnHangTraLoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHangTraLoi.UseVisualStyleBackColor = false;
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
            this.btnNhaPhanPhoi.Text = "Quản lý khách hàng ";
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
            this.lblTopUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(186, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Xử lý hàng trả hoặc lỗi ";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.BangYeuCau);
            this.pnlMainContent.Controls.Add(this.pnlActionTool);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 50);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainContent.Size = new System.Drawing.Size(1060, 700);
            this.pnlMainContent.TabIndex = 2;
            // 
            // BangYeuCau
            // 
            this.BangYeuCau.AllowUserToAddRows = false;
            this.BangYeuCau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BangYeuCau.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.BangYeuCau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BangYeuCau.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.BangYeuCau.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BangYeuCau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BangYeuCau.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BangYeuCau.DefaultCellStyle = dataGridViewCellStyle2;
            this.BangYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BangYeuCau.EnableHeadersVisualStyles = false;
            this.BangYeuCau.GridColor = System.Drawing.Color.Gray;
            this.BangYeuCau.Location = new System.Drawing.Point(20, 160);
            this.BangYeuCau.Name = "BangYeuCau";
            this.BangYeuCau.ReadOnly = true;
            this.BangYeuCau.RowHeadersVisible = false;
            this.BangYeuCau.RowHeadersWidth = 51;
            this.BangYeuCau.RowTemplate.Height = 45;
            this.BangYeuCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BangYeuCau.Size = new System.Drawing.Size(1020, 520);
            this.BangYeuCau.TabIndex = 1;
            this.BangYeuCau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BangYeuCau_CellContentClick);
            this.BangYeuCau.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BangYeuCau_CellFormatting);
            // 
            // pnlActionTool
            // 
            this.pnlActionTool.Controls.Add(this.pnlTabs);
            this.pnlActionTool.Controls.Add(this.cboFilterType);
            this.pnlActionTool.Controls.Add(this.txtSearch);
            this.pnlActionTool.Controls.Add(this.lblTitle);
            this.pnlActionTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionTool.Location = new System.Drawing.Point(20, 20);
            this.pnlActionTool.Name = "pnlActionTool";
            this.pnlActionTool.Size = new System.Drawing.Size(1020, 140);
            this.pnlActionTool.TabIndex = 0;
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnTabCanXuLy);
            this.pnlTabs.Controls.Add(this.btnTabDaXuLy);
            this.pnlTabs.Location = new System.Drawing.Point(0, 50);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(360, 40);
            this.pnlTabs.TabIndex = 5;
            // 
            // btnTabCanXuLy
            // 
            this.btnTabCanXuLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnTabCanXuLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabCanXuLy.FlatAppearance.BorderSize = 0;
            this.btnTabCanXuLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabCanXuLy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabCanXuLy.ForeColor = System.Drawing.Color.White;
            this.btnTabCanXuLy.Location = new System.Drawing.Point(0, 0);
            this.btnTabCanXuLy.Name = "btnTabCanXuLy";
            this.btnTabCanXuLy.Size = new System.Drawing.Size(175, 36);
            this.btnTabCanXuLy.TabIndex = 0;
            this.btnTabCanXuLy.Text = "Chờ xử lý";
            this.btnTabCanXuLy.UseVisualStyleBackColor = false;
            this.btnTabCanXuLy.Click += new System.EventHandler(this.btnTabCanXuLy_Click);
            // 
            // btnTabDaXuLy
            // 
            this.btnTabDaXuLy.BackColor = System.Drawing.Color.LightGray;
            this.btnTabDaXuLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabDaXuLy.FlatAppearance.BorderSize = 0;
            this.btnTabDaXuLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDaXuLy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabDaXuLy.ForeColor = System.Drawing.Color.Black;
            this.btnTabDaXuLy.Location = new System.Drawing.Point(180, 0);
            this.btnTabDaXuLy.Name = "btnTabDaXuLy";
            this.btnTabDaXuLy.Size = new System.Drawing.Size(175, 36);
            this.btnTabDaXuLy.TabIndex = 1;
            this.btnTabDaXuLy.Text = "Đã xử lý";
            this.btnTabDaXuLy.UseVisualStyleBackColor = false;
            this.btnTabDaXuLy.Click += new System.EventHandler(this.btnTabDaXuLy_Click);
            // 
            // cboFilterType
            // 
            this.cboFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Location = new System.Drawing.Point(820, 98);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(200, 29);
            this.cboFilterType.TabIndex = 4;
            this.cboFilterType.SelectedIndexChanged += new System.EventHandler(this.cboFilterType_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(0, 98);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(800, 29);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(502, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý yêu cầu đổi trả hoặc khiếu nại";
            // 
            // XulyHangLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1280, 750);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "XulyHangLoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP Bán Hàng - Xử Lý Hàng Trả & Lỗi";
            this.Load += new System.EventHandler(this.XulyHangLoi_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserBottom.ResumeLayout(false);
            this.pnlUserBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrandLogo)).EndInit();
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BangYeuCau)).EndInit();
            this.pnlActionTool.ResumeLayout(false);
            this.pnlActionTool.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlActionTool;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.DataGridView BangYeuCau;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabCanXuLy;
        private System.Windows.Forms.Button btnTabDaXuLy;
    }
}
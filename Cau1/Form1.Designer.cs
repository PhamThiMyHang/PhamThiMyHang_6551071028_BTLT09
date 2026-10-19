namespace Cau1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtGhiChu = new TextBox();
            txtNoiDung = new TextBox();
            label6 = new Label();
            label4 = new Label();
            nudSoTien = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            lblNgayChi = new Label();
            cboLoaiChi = new ComboBox();
            dtpNgayChi = new DateTimePicker();
            btnTimKiem = new Button();
            dgvChiTieu = new DataGridView();
            groupBox2 = new GroupBox();
            cboLocLoaiChi = new ComboBox();
            txtTimKiem = new TextBox();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTongChi = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(txtNoiDung);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(nudSoTien);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblNgayChi);
            groupBox1.Controls.Add(cboLoaiChi);
            groupBox1.Controls.Add(dtpNgayChi);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(476, 182);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khoản chi";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(72, 134);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(398, 27);
            txtGhiChu.TabIndex = 13;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(88, 60);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(151, 27);
            txtNoiDung.TabIndex = 12;
            txtNoiDung.Text = "Cà phê với bạn";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(259, 63);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 6;
            label6.Text = "Số tiền";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 141);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 4;
            label4.Text = "Ghi chú";
            // 
            // nudSoTien
            // 
            nudSoTien.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudSoTien.Location = new Point(320, 61);
            nudSoTien.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudSoTien.Name = "nudSoTien";
            nudSoTien.Size = new Size(150, 27);
            nudSoTien.TabIndex = 5;
            nudSoTien.TextAlign = HorizontalAlignment.Center;
            nudSoTien.ThousandsSeparator = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 103);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 3;
            label3.Text = "Loại chi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 63);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 2;
            label2.Text = "Nội dung";
            // 
            // lblNgayChi
            // 
            lblNgayChi.AutoSize = true;
            lblNgayChi.Location = new Point(16, 33);
            lblNgayChi.Name = "lblNgayChi";
            lblNgayChi.Size = new Size(67, 20);
            lblNgayChi.TabIndex = 1;
            lblNgayChi.Text = "Ngày chi";
            // 
            // cboLoaiChi
            // 
            cboLoaiChi.FormattingEnabled = true;
            cboLoaiChi.Items.AddRange(new object[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            cboLoaiChi.Location = new Point(89, 98);
            cboLoaiChi.Name = "cboLoaiChi";
            cboLoaiChi.Size = new Size(151, 28);
            cboLoaiChi.TabIndex = 4;
            cboLoaiChi.Text = "Ăn uống";
            // 
            // dtpNgayChi
            // 
            dtpNgayChi.Format = DateTimePickerFormat.Short;
            dtpNgayChi.Location = new Point(89, 28);
            dtpNgayChi.Name = "dtpNgayChi";
            dtpNgayChi.Size = new Size(148, 27);
            dtpNgayChi.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(213, 134);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(64, 35);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dgvChiTieu
            // 
            dgvChiTieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTieu.Location = new Point(12, 250);
            dgvChiTieu.Name = "dgvChiTieu";
            dgvChiTieu.RowHeadersWidth = 51;
            dgvChiTieu.Size = new Size(791, 188);
            dgvChiTieu.TabIndex = 7;
            dgvChiTieu.CellClick += dgvChiTieu_CellClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cboLocLoaiChi);
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(dtpDenNgay);
            groupBox2.Controls.Add(dtpTuNgay);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(511, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(292, 182);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // cboLocLoaiChi
            // 
            cboLocLoaiChi.FormattingEnabled = true;
            cboLocLoaiChi.Location = new Point(76, 65);
            cboLocLoaiChi.Name = "cboLocLoaiChi";
            cboLocLoaiChi.Size = new Size(201, 28);
            cboLocLoaiChi.TabIndex = 14;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(96, 26);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(181, 27);
            txtTimKiem.TabIndex = 12;
            txtTimKiem.Text = ".....";
            txtTimKiem.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(75, 136);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(126, 27);
            dtpDenNgay.TabIndex = 11;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(75, 96);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(126, 27);
            dtpTuNgay.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(0, 141);
            label10.Name = "label10";
            label10.Size = new Size(72, 20);
            label10.TabIndex = 10;
            label10.Text = "Đến ngày";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 98);
            label9.Name = "label9";
            label9.Size = new Size(62, 20);
            label9.TabIndex = 9;
            label9.Text = "Từ ngày";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 68);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 8;
            label8.Text = "Loại chi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 33);
            label7.Name = "label7";
            label7.Size = new Size(71, 20);
            label7.TabIndex = 7;
            label7.Text = "Nội dung";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(87, 200);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(64, 35);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(187, 200);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(64, 35);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(296, 200);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(64, 35);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(401, 200);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(101, 35);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblTongChi
            // 
            lblTongChi.AutoSize = true;
            lblTongChi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongChi.ForeColor = Color.Red;
            lblTongChi.Location = new Point(642, 459);
            lblTongChi.Name = "lblTongChi";
            lblTongChi.Size = new Size(161, 20);
            lblTongChi.TabIndex = 14;
            lblTongChi.Text = "Tổng chi: 1.250.000 đ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 488);
            Controls.Add(lblTongChi);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox2);
            Controls.Add(dgvChiTieu);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTieu).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label lblNgayChi;
        private DateTimePicker dtpNgayChi;
        private ComboBox cboLoaiChi;
        private NumericUpDown nudSoTien;
        private Button btnTimKiem;
        private DataGridView dgvChiTieu;
        private GroupBox groupBox2;
        private TextBox txtGhiChu;
        private TextBox txtNoiDung;
        private Label label6;
        private Label label4;
        private ComboBox cboLocLoaiChi;
        private TextBox txtTimKiem;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTongChi;
    }
}

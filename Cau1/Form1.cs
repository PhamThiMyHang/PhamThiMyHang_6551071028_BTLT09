using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SoChiTieu.Models;
using Serilog;
namespace Cau1
{
    public partial class Form1 : Form
    {

        private readonly DbContextOptions<QL_ChiTieuContext> _options;
        private int? _maCTDangChon;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(DbContextOptions<QL_ChiTieuContext> options)
        {
            InitializeComponent();

            _options = options;

            // Đăng ký sự kiện cho các nút
            Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvChiTieu.CellClick += dgvChiTieu_CellClick;

            // Thiết lập giao diện
            Text = "Sổ chi tiêu cá nhân";
            StartPosition = FormStartPosition.CenterScreen;

            dtpNgayChi.MaxDate = DateTime.Today;
            dtpTuNgay.MaxDate = DateTime.Today;
            dtpDenNgay.MaxDate = DateTime.Today;

            nudSoTien.Minimum = 0;
            nudSoTien.Maximum = 1000000000;
            nudSoTien.Increment = 1000;
            nudSoTien.ThousandsSeparator = true;

            txtGhiChu.Multiline = true;
            txtGhiChu.MaxLength = 200;
            txtNoiDung.MaxLength = 100;

            cboLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;

            cboLoaiChi.Items.Clear();
            cboLoaiChi.Items.AddRange(new object[]
            {
                "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác"
            });

            cboLocLoaiChi.Items.Clear();
            cboLocLoaiChi.Items.Add("Tất cả");
            cboLocLoaiChi.Items.AddRange(new object[]
            {
                "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác"
            });

            cboLoaiChi.SelectedIndex = 0;
            cboLocLoaiChi.SelectedIndex = 0;

            txtTimKiem.Clear();

            // Cấu hình DataGridView
            dgvChiTieu.AutoGenerateColumns = true;
            dgvChiTieu.ReadOnly = true;
            dgvChiTieu.AllowUserToAddRows = false;
            dgvChiTieu.AllowUserToDeleteRows = false;
            dgvChiTieu.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvChiTieu.MultiSelect = false;
            dgvChiTieu.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LamMoiNhapLieu();
            LoadChiTieu();
        }

        private void LoadChiTieu()
        {
            try
            {
                using var db = new QL_ChiTieuContext(_options);

                var query = db.ChiTieu
                    .AsNoTracking()
                    .AsQueryable();

                string tuKhoa = txtTimKiem.Text.Trim();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(ct =>
                        ct.NoiDung.Contains(tuKhoa));
                }

                if (cboLocLoaiChi.SelectedIndex > 0)
                {
                    string loaiChi = cboLocLoaiChi.Text;
                    query = query.Where(ct =>
                        ct.LoaiChi == loaiChi);
                }

                DateOnly tuNgay =
                    DateOnly.FromDateTime(dtpTuNgay.Value.Date);

                DateOnly denNgay =
                    DateOnly.FromDateTime(dtpDenNgay.Value.Date);

                query = query.Where(ct =>
                    ct.NgayChi >= tuNgay &&
                    ct.NgayChi <= denNgay);

                if (tuNgay > denNgay)
                {
                    MessageBox.Show(
                        "Từ ngày không được lớn hơn đến ngày.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var danhSach = query
                    .OrderByDescending(ct => ct.NgayChi)
                    .ThenByDescending(ct => ct.MaCT)
                    .ToList();

                dgvChiTieu.DataSource = danhSach;

                // Đặt tên cột hiển thị
                if (dgvChiTieu.Columns["MaCT"] != null)
                    dgvChiTieu.Columns["MaCT"].HeaderText = "Mã chi";

                if (dgvChiTieu.Columns["NgayChi"] != null)
                    dgvChiTieu.Columns["NgayChi"].HeaderText = "Ngày chi";

                if (dgvChiTieu.Columns["NoiDung"] != null)
                    dgvChiTieu.Columns["NoiDung"].HeaderText = "Nội dung";

                if (dgvChiTieu.Columns["LoaiChi"] != null)
                    dgvChiTieu.Columns["LoaiChi"].HeaderText = "Loại chi";

                if (dgvChiTieu.Columns["SoTien"] != null)
                {
                    dgvChiTieu.Columns["SoTien"].HeaderText = "Số tiền";
                    dgvChiTieu.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                }

                if (dgvChiTieu.Columns["GhiChu"] != null)
                    dgvChiTieu.Columns["GhiChu"].HeaderText = "Ghi chú";

                decimal tongChi = danhSach.Sum(ct => ct.SoTien);

                lblTongChi.Text = $"Tổng chi: {tongChi:N0} đ";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải danh sách chi tiêu.");

                MessageBox.Show(
                    "Không thể tải danh sách chi tiêu. Vui lòng kiểm tra kết nối cơ sở dữ liệu.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Lấy dữ liệu trên form và kiểm tra hợp lệ
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung chi.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNoiDung.Focus();
                return false;
            }

            if (txtNoiDung.Text.Trim().Length > 100)
            {
                MessageBox.Show("Nội dung không được quá 100 ký tự.");
                return false;
            }

            if (cboLoaiChi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại chi.");
                return false;
            }

            if (nudSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0.");
                nudSoTien.Focus();
                return false;
            }

            if (dtpNgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn hôm nay.");
                return false;
            }

            if (txtGhiChu.Text.Length > 200)
            {
                MessageBox.Show("Ghi chú không được quá 200 ký tự.");
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                using var db = new QL_ChiTieuContext(_options);

                var chiTieu = new ChiTieu
                {
                    NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date),
                    NoiDung = txtNoiDung.Text.Trim(),
                    LoaiChi = cboLoaiChi.Text,
                    SoTien = nudSoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text)
                        ? null
                        : txtGhiChu.Text.Trim()
                };

                db.ChiTieu.Add(chiTieu);
                db.SaveChanges();

                Log.Information(
                    "Đã thêm khoản chi MaCT={MaCT}, số tiền={SoTien}",
                    chiTieu.MaCT, chiTieu.SoTien);

                MessageBox.Show("Thêm khoản chi thành công.");

                LamMoiNhapLieu();
                LoadChiTieu();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khoản chi.");

                MessageBox.Show(
                    "Không thể thêm khoản chi. Vui lòng thử lại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvChiTieu.Rows[e.RowIndex];

            if (row.Cells["MaCT"].Value == null)
                return;

            _maCTDangChon = Convert.ToInt32(row.Cells["MaCT"].Value);

            dtpNgayChi.Value = Convert.ToDateTime(
                row.Cells["NgayChi"].Value);

            txtNoiDung.Text =
                row.Cells["NoiDung"].Value?.ToString() ?? "";

            cboLoaiChi.SelectedItem =
                row.Cells["LoaiChi"].Value?.ToString();

            nudSoTien.Value = Convert.ToDecimal(
                row.Cells["SoTien"].Value);

            txtGhiChu.Text =
                row.Cells["GhiChu"].Value?.ToString() ?? "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maCTDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khoản chi cần sửa.");
                return;
            }

            if (!KiemTraDuLieu())
                return;

            try
            {
                using var db = new QL_ChiTieuContext(_options);

                var chiTieu = db.ChiTieu.Find(_maCTDangChon.Value);

                if (chiTieu == null)
                {
                    MessageBox.Show("Khoản chi không còn tồn tại.");
                    LoadChiTieu();
                    return;
                }

                chiTieu.NgayChi =
                    DateOnly.FromDateTime(dtpNgayChi.Value.Date);

                chiTieu.NoiDung = txtNoiDung.Text.Trim();
                chiTieu.LoaiChi = cboLoaiChi.Text;
                chiTieu.SoTien = nudSoTien.Value;
                chiTieu.GhiChu =
                    string.IsNullOrWhiteSpace(txtGhiChu.Text)
                        ? null
                        : txtGhiChu.Text.Trim();

                db.SaveChanges();

                Log.Information(
                    "Đã sửa khoản chi MaCT={MaCT}, số tiền={SoTien}",
                    chiTieu.MaCT, chiTieu.SoTien);

                MessageBox.Show("Sửa khoản chi thành công.");

                LamMoiNhapLieu();
                LoadChiTieu();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi sửa khoản chi MaCT={MaCT}",
                    _maCTDangChon);

                MessageBox.Show(
                    "Không thể sửa khoản chi. Vui lòng thử lại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maCTDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khoản chi cần xóa.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khoản chi này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                using var db = new QL_ChiTieuContext(_options);

                var chiTieu = db.ChiTieu.Find(_maCTDangChon.Value);

                if (chiTieu == null)
                {
                    MessageBox.Show("Khoản chi không còn tồn tại.");
                    LoadChiTieu();
                    return;
                }

                int maCT = chiTieu.MaCT;

                db.ChiTieu.Remove(chiTieu);
                db.SaveChanges();

                Log.Information("Đã xóa khoản chi MaCT={MaCT}", maCT);

                MessageBox.Show("Xóa khoản chi thành công.");

                LamMoiNhapLieu();
                LoadChiTieu();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khoản chi MaCT={MaCT}",
                    _maCTDangChon);

                MessageBox.Show(
                    "Không thể xóa khoản chi. Vui lòng thử lại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LamMoiNhapLieu()
        {
            _maCTDangChon = null;

            dtpNgayChi.Value = DateTime.Today;
            txtNoiDung.Clear();
            cboLoaiChi.SelectedIndex = 0;
            nudSoTien.Value = 0;
            txtGhiChu.Clear();

            dgvChiTieu.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            cboLocLoaiChi.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Today;

            LamMoiNhapLieu();
            LoadChiTieu();
        }
    }
}

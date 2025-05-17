using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace HotelManagementProject
{
    public partial class frmDevice : Form
    {
        ThietBiBLL tbbll;
        private BindingList<thietbi> datathietbi = new BindingList<thietbi>();
        private Timer opacityTimer = new Timer();

        public frmDevice()
        {
            InitializeComponent();
            tbbll = new ThietBiBLL();
            this.Opacity = 0;
            opacityTimer.Interval = 5;
            opacityTimer.Tick += new EventHandler(OnTimerTick);
            opacityTimer.Start();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            cboFind.SelectedIndex = 0;
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.1;
            else
                opacityTimer.Stop();
        }

        private void frmDevice_Load(object sender, EventArgs e)
        {
            LoadTableThietBi();
        }

        public void LoadTableThietBi()
        {
            List<thietbi> dataFromDatabase = tbbll.GetThietBiList();
            tblThietBi.DataSource = dataFromDatabase;
            tblThietBi.Columns[0].HeaderText = "Mã Thiết Bị";
            tblThietBi.Columns[1].HeaderText = "Tên Thiết Bị";
            tblThietBi.Columns[2].HeaderText = "Giá";

            tblThietBi.AllowUserToResizeRows = false;
            
        }

        private void tblThietBi_Click(object sender, EventArgs e)
        {
            if (tblThietBi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tblThietBi.SelectedRows[0];
                txtTenThietBi.Text = selectedRow.Cells[1].Value.ToString();
                txtGiaThietBi.Text = selectedRow.Cells[2].Value.ToString();
            }
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTenThietBi.Enabled = true;
            txtGiaThietBi.Enabled=true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenThietBi.Enabled = true; txtGiaThietBi.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtGiaThietBi.Text = string.Empty; txtTenThietBi.Text = string.Empty;
            txtTenThietBi.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int i = tblThietBi.CurrentRow.Index;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    tbbll.XoaThietBi(tblThietBi.Rows[i].Cells[0].Value.ToString().Trim());
                    LoadTableThietBi();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thiết bị " + txtTenThietBi.Text + " đã được sử dụng, Không được xóa","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật lại thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = tblThietBi.CurrentRow.Index;
            if (result == DialogResult.Yes)
            {
                tbbll.CapNhatThietBi(tblThietBi.Rows[i].Cells[0].Value.ToString().Trim(), txtTenThietBi.Text.Trim(), int.Parse(txtGiaThietBi.Text.Trim()));
                LoadTableThietBi();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tbbll.ThemThietBi(txtTenThietBi.Text.Trim(), int.Parse(txtGiaThietBi.Text.Trim()));
                LoadTableThietBi();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.deviceForm = new frmDevice();
            Program.deviceForm.Show();
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.mainForm = new FrmMain();
            Program.mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboFind.Text == "Mã Thiết Bị")
                tblThietBi.DataSource = tbbll.GetHoaDonList_MaHoaDon(txtFind.Text.Trim());
            if (cboFind.Text == "Tên Thiết Bị")
                tblThietBi.DataSource = tbbll.GetHoaDonList_TenHoaDon(txtFind.Text.Trim());
            if (txtFind.Text.Equals(string.Empty))
                LoadTableThietBi();
            
        }
    }
}

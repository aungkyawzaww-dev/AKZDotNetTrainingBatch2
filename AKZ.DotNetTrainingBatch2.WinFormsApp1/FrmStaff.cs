using AKZ.DotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AKZ.DotNetTrainingBatch2.WinFormsApp1
{
    public partial class FrmStaff : Form
    {

        private readonly AppDbContext _db;
        private int _editId;
        public FrmStaff()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns = false;
        }

        private void BindData()
        {
            try
            {
                dgvData.DataSource = _db.TblStaffRegisters.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //AppDbContext db = new AppDbContext();
                _db.TblStaffRegisters.Add(new TblStaffRegister
                {
                    Staffcode = txtCode.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Position = cboPosition.Text.Trim(),
                    DeleteFlag = false
                });
                int result = _db.SaveChanges();
                string messsage = result > 0 ? "Saving Successful." : "Saving Failed";
                MessageBox.Show(messsage, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCode.Clear();
                txtName.Clear();
                txtEmail.Clear();
                txtPassword.Clear();
                cboPosition.Text = "";

                txtCode.Focus();
                BindData();

            }
            catch (Exception)
            {

                throw;
            }
        }

        

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                var item = _db.TblStaffRegisters.FirstOrDefault(x => x.Staffid == id);
                if (item is null) return;

                txtCode.Text = item.Staffcode;
                txtName.Text = item.Name;
                txtEmail.Text = item.Email;
                txtPassword.Text = item.Password;
                cboPosition.Text = item.Position;
                _editId = id;

            }else if (e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
                var comfirm = MessageBox.Show("Are you sure want to delete?" , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (comfirm == DialogResult.No) return;

                // Delete Process
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffRegisters.FirstOrDefault(x => x.Staffid == id);
                if(item is null) return;
                _db.TblStaffRegisters.Remove(item);
                int result = _db.SaveChanges();
                string messsage = result > 0 ? "Deleting Successful." : "Deleting Failed";
                MessageBox.Show(messsage, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int id = _editId;
            if (id is 0) return;

            var item = _db.TblStaffRegisters
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.Staffid == id);

            if (item == null) return;

            item.Staffcode = txtCode.Text.Trim();
            item.Name = txtName.Text.Trim();
            item.Email = txtEmail.Text.Trim();
            item.Password = txtPassword.Text.Trim();
            item.Position = cboPosition.Text.Trim();
            item.DeleteFlag = false;
            int result = _db.SaveChanges();

            string messsage = result > 0 ? "Updating Successful." : "Updating Failed";
            MessageBox.Show(messsage, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCode.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cboPosition.Text = "";

            txtCode.Focus();
            BindData();

        }
    }
}

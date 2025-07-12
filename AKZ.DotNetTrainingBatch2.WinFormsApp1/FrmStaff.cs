using AKZ.DotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
using MimeKit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using MailKit.Net.Smtp;

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
                txtPassword.Text = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
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
                string messsageStr = result > 0 ? "Saving Successful." : "Saving Failed";
                MessageBox.Show(messsageStr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

             // from mailkit
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Aung Kyaw Zaww", "aungkyawzaww7889@gmail.com"));
                message.To.Add(new MailboxAddress(txtCode.Text.Trim(), txtEmail.Text.Trim()));
                message.Subject = "Mini POS - User Creation";

                message.Body = new TextPart("plain")
                {
                    Text = $@"Your staff code is {txtCode.Text.Trim()}
Your password is {txtPassword.Text }"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("aungkyawzaww7889@gmail.com", "cgow ndmy tzzu oise"); // email & password  https://myaccount.google.com/apppasswords?pli=1&rapt=AEjHL4Mfut7en43s2BB7A9_a0DG-Ktg7GzcEB0_ZrwbyqGuC8KPZ7fzpEkaEV31bg5ywU5PvTfkHm5G-f2HuqqzexL9kKBjb5JOp1H6ubnfml21GUNsmN5c

                    client.Send(message);
                    client.Disconnect(true);
                }
            

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

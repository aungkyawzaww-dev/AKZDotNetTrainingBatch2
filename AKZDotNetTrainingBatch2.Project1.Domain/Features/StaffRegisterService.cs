using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;

namespace AKZDotNetTrainingBatch2.Project1.Domain.Features
{
    public class StaffRegisterService
    {
        public int CreateStaffReg(string staffcode, string name, string email, string password, string position)
        {
            TblStaffRegister staffReg = new TblStaffRegister()
            {
                Staffcode = staffcode,
                Name = name,
                Email = email,
                Password = password,
                Position = position
            };

            AppDbContext db = new AppDbContext();
            db.TblStaffRegisters.Add(staffReg);
            int result = db.SaveChanges();
            return result;
        }

        public TblStaffRegister? FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblStaffRegisters
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.Staffid == id);
            return item;
        }

        public int UpdateStaffReg(int id,string staffcode, string name, string email, string password, string position)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblStaffRegisters
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.Staffid == id);
            if (item == null) return -1;

            item.Staffcode = staffcode;
            item.Name = name;
            item.Email = email;
            item.Password = password;
            item.Position = position;

            int result = db.SaveChanges();
            return result;
        }

        public int DeleteStaff(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblStaffRegisters.FirstOrDefault(x => x.Staffid == id);
            if (item == null) return -1;
            item.DeleteFlag = true;

            int result = db.SaveChanges();
            return result;

        }
    }
}

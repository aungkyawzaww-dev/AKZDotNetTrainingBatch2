using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using AKZDotNetTrainingBatch2.Project1.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class StaffRegisterUI
    {

        public void GetStaff()
        {
        FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            StaffRegisterService staffRegisterService = new StaffRegisterService();
            var item = staffRegisterService.FindProduct(id);

            if (item == null)
            {
                Console.WriteLine("You Invalid Id!");
                goto FirstPage;
            }

            Console.WriteLine("StaffID : " + item.Staffid);
            Console.WriteLine("Staff Code : " + item.Staffcode);
            Console.WriteLine("Staff Name : " + item.Name);
            Console.WriteLine("Staff Email : " + item.Email);
            Console.WriteLine("Staff Password : " + item.Password);
            Console.WriteLine("Staff Position : " + item.Position);

        }

        public void Create()
        {

            Console.Write("Enter Staff Code eg:1001 : ");
            string StaffCode = Console.ReadLine()!;

            Console.Write("Enter Staff Name : ");
            string Name = Console.ReadLine()!;

            Console.Write("Enter Email : ");
            string Email = Console.ReadLine()!;

            Console.Write("Enter Password : ");
            string Password = Console.ReadLine()!;

            Console.Write("Enter Position : ");
            string Position = Console.ReadLine()!;

            StaffRegisterService staffRegisterService = new StaffRegisterService();
            var result = staffRegisterService.CreateStaffReg(StaffCode, Name, Email, Password, Position);
            Console.WriteLine(result > 0 ? "Creating successful." : "Creating failed.");

        }

        public void Update()
        {
        FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            bool isExit = IsExitStaff(id);
            if (!isExit)
            {
                Console.WriteLine("Invalid Id!");
                goto FirstPage;
            }

            Console.Write("Enter Staff Code eg:1001 : ");
            string StaffCode = Console.ReadLine()!;

            Console.Write("Enter Staff Name : ");
            string Name = Console.ReadLine()!;

            Console.Write("Enter Email : ");
            string Email = Console.ReadLine()!;

            Console.Write("Enter Password : ");
            string Password = Console.ReadLine()!;

            Console.Write("Enter Position : ");
            string Position = Console.ReadLine()!;

            StaffRegisterService staffRegisterService = new StaffRegisterService();
            var result = staffRegisterService.UpdateStaffReg(id,StaffCode, Name, Email, Password, Position);
            if (result == -1)
            {
                Console.WriteLine("No Data Found");
                goto FirstPage;
            }
            Console.WriteLine(result > 0 ? "Updating successful." : "Updating failed.");
        }

        public void Delete()
        {
        FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            bool isExit = IsExitStaff(id);
            if (!isExit)
            {
                Console.WriteLine("Invalid Id!");
                goto FirstPage;
            }
            StaffRegisterService staffRegisterService = new StaffRegisterService();
            var result = staffRegisterService.DeleteStaff(id);
            if (result == -1)
            {
                Console.WriteLine("No Data Found");
                goto FirstPage;
            }
            Console.WriteLine(result > 0 ? "Deleting successful." : "Deleting failed.");
        }


        public bool IsExitStaff(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            return item != null;
        }







    }
        
        
 }

using AKZDotNetTrainingBatch2.MiniPosDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SaleService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<TblSaleSummary> lst = db.TblSaleSummaries
                .OrderByDescending(x => x.SaleId)
                .ToList();
                
            foreach(var item in lst)
            {
                Console.WriteLine("SaleId : " + item.SaleId);
                Console.WriteLine("Sale Date : " + item.SaleDate);
                Console.WriteLine("VoucherNo : " + item.VoucherNo);
                Console.WriteLine("Total Amount : " + item.TotalAmount);
            }

        }

        public void Edit()
        {
        FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            AppDbContext db = new AppDbContext();
            var item = db.TblSaleSummaries
                .FirstOrDefault(x => x.SaleId == id);
            if (item == null)
            {
                Console.WriteLine("You Invalid Id!");
                goto FirstPage;
            }

            Console.WriteLine("SaleId : " + item.SaleId);
            Console.WriteLine("Sale Date : " + item.SaleDate);
            Console.WriteLine("VoucherNo : " + item.VoucherNo);
            Console.WriteLine("Total Amount : " + item.TotalAmount);

        }

        public void Create()
        {
            Console.Write("Enter Date : ");
            string SaleDate = Console.ReadLine()!;

            Console.Write("Voucher No : ");
            string VoucherNo = Console.ReadLine()!;

            Console.Write("Total Amount : ");
            string TotalAmount = Console.ReadLine()!;

            TblSaleSummary saleSummary = new TblSaleSummary()
            {
                SaleDate = SaleDate,
                VoucherNo = VoucherNo,
                TotalAmount = TotalAmount
            };

            AppDbContext db = new AppDbContext();
            db.TblSaleSummaries.Add(saleSummary);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Creating successful." : "Creating failed.");

        }
    }
}

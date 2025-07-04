using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SaleDetailService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<TblSaleDetail> lst = db.TblSaleDetails
                .OrderByDescending(x => x.SaleDetailId)
                .ToList();

            foreach (var item in lst)
            {
                Console.WriteLine("SaleDetail Id : " + item.SaleDetailId);
                Console.WriteLine("SaleId : " + item.SaleId);
                Console.WriteLine("Product Id : " + item.ProductId);
                Console.WriteLine("Quantity : " + item.Quantity);
                Console.WriteLine("Price : " + item.Price);
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
            var item = db.TblSaleDetails
                .FirstOrDefault(x => x.SaleDetailId == id);
            if (item == null)
            {
                Console.WriteLine("You Invalid Id!");
                goto FirstPage;
            }

            Console.WriteLine("SaleDetail Id : " + item.SaleDetailId);
            Console.WriteLine("SaleId : " + item.SaleId);
            Console.WriteLine("Product Id : " + item.ProductId);
            Console.WriteLine("Quantity : " + item.Quantity);
            Console.WriteLine("Price : " + item.Price);

        }

        //public bool inputId(string inputId)
        //{
        //    return int.TryParse(inputId, out int outputId);
        //}

        public void Create()
        {

            Console.Write("Enter Sale Id : ");
            int SaleId = Convert.ToInt32(Console.ReadLine())!;

            Console.Write("Enter Product Id : ");
            int ProductId = Convert.ToInt32(Console.ReadLine())!;

            Console.Write("Quantity : ");
            int Quantity = Convert.ToInt32(Console.ReadLine())!;

            Console.Write("Price : ");
            int Price = Convert.ToInt32(Console.ReadLine())!;

            TblSaleDetail saleDetail = new TblSaleDetail()
            {
                SaleId = SaleId,
                ProductId = ProductId,
                Quantity = Quantity,
                Price = Price
            };

            AppDbContext db = new AppDbContext();
            db.TblSaleDetails.Add(saleDetail);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Creating successful." : "Creating failed.");

        }
    }
}

using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SaleFeatureService
    {
        public void Execute()
        {
            AppDbContext db = new AppDbContext();
            List<TblSaleDetail> products = new List<TblSaleDetail>();

        FirstPage:
            Console.Write("Please enter product Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);

            Console.WriteLine($"Product Name : {item.Name}");
            Console.WriteLine($"Product Price : {item.Price}");
            Console.Write("Please enter product Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine())!;

            products.Add(new TblSaleDetail
            {
                Price = item.Price,
                ProductId = item.Price,
                Quantity = quantity,

            });

            Console.WriteLine("Are you sure want to add more? Y/N");
            string result = Console.ReadLine()!;
            if(result == "Y")  goto FirstPage;

            //Sale 
            TblSaleSummary sale = new TblSaleSummary()
            {
                DeleteFlag = false,
                SaleDate = DateTime.Now,
                TotalAmount = products.Sum(x => (x.Price * x.Quantity)),
                VoucherNo = Guid.NewGuid().ToString(),
            };

            db.TblSaleSummaries.Add(sale);
            db.SaveChanges();

            // add for save details
            foreach (var product in products)
            {
                product.SaleId = sale.SaleId;
            }

            db.TblSaleDetails.AddRange(products);
            db.SaveChanges();


        }



    }
}

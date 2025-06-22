using AKZDotNetTrainingBatch2.MiniPosDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class ProductService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<TblProduct> lst = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .OrderByDescending(x => x.ProductId)
                .ToList();

            foreach (var item in lst)
            {
                Console.WriteLine("ProductId : " + item.ProductId);
                Console.WriteLine("Product Name : " + item.Name);
                Console.WriteLine("Product Price : " + item.Price);
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
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            if (item == null)
            {
                Console.WriteLine("You Invalid Id!");
                goto FirstPage;
            }

            Console.WriteLine("ProductId : " + item.ProductId);
            Console.WriteLine("Product Name : " + item.Name);
            Console.WriteLine("Product Price : " + item.Price);

        }

        public void Create()
        {
            Console.Write("Enter Product Name : ");
            string ProductName = Console.ReadLine()!;

            Console.Write("Enter Product Price : ");
            string ProductPrice = Console.ReadLine()!;

            TblProduct product = new TblProduct()
            {
                Name = ProductName,
                Price = ProductPrice
            };

            AppDbContext db = new AppDbContext();
            db.TblProducts.Add(product);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Creating successful." : "Creating failed.");

        }

        public void Update()
        {
          FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            bool isExit = IsExitProduct(id);
            if (!isExit)
            {
                Console.WriteLine("Invalid Id!");
                goto FirstPage;
            }

            Console.Write("Enter Product Name : ");
            string ProductName = Console.ReadLine()!;

            Console.Write("Enter Product Price : ");
            string ProductPrice = Console.ReadLine()!;

            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);

            item.Name = ProductName;
            item.Price = ProductPrice;

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating successful." : "Updating failed.");

        }

        public void Delete()
        {
           FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            bool isExit = IsExitProduct(id);
            if (!isExit)
            {
                Console.WriteLine("Invalid Id!");
                goto FirstPage;
            }

            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            item.DeleteFlag = true;

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting successful." : "Deleting failed.");
        }

        public bool IsExitProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            return item != null;
        }

    }
}

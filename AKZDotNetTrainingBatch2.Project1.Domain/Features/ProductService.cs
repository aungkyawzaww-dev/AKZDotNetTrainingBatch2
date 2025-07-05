using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.Project1.Domain.Features
{
    public class ProductService
    {
        public List<TblProduct> GetProducts()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .OrderByDescending(x => x.ProductId)
                .ToList();
            return lst;

        }

        public TblProduct? FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            return item;
        }

        public int CreateProduct(string ProductName,int ProductPrice)
        {
            TblProduct product = new TblProduct()
            {
                Name = ProductName,
                Price = ProductPrice
            };

            AppDbContext db = new AppDbContext();
            db.TblProducts.Add(product);
            int result = db.SaveChanges();
            return result;
        }

        public int UpdateProduct(int id,string ProductName, int ProductPrice)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.ProductId == id);
            if (item == null) return -1;

            item.Name = ProductName;
            item.Price = ProductPrice;

            int result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            item.DeleteFlag = true;

            int result = db.SaveChanges();
            return result;

        }
    }
}

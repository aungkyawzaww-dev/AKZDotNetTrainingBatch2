using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.Project1.Domain.Features
{
    public class SaleService
    {
        public TblProduct FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            return item;

        }

        public int Sale(List<TblSaleDetail> products)
        {
            #region db connect
            AppDbContext db = new AppDbContext();
            //List<TblSaleDetail> products = new List<TblSaleDetail>();
            #endregion

            #region generate sale summary and create sale summary
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

            #endregion

            #region modifiy sale detail and create sale details

            foreach (var product in products)
            {
                product.SaleId = sale.SaleId;
            }

            db.TblSaleDetails.AddRange(products);
            var result = db.SaveChanges();

            #endregion 
            return result;

        }

        public TblSaleSummary? FindId(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblSaleSummaries
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.SaleId == id);
            return item;
        }

        public List<TblSaleSummary> GetSales()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblSaleSummaries
                .Where(x => x.DeleteFlag == false)
                .OrderByDescending(x => x.SaleId)
                .ToList();
            return lst;
        }
    }
}

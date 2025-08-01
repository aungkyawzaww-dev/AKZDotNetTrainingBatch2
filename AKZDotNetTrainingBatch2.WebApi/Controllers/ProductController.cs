using AKZDotNetTrainingBatch2.WebApi.Database.AppDbContextModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AKZDotNetTrainingBatch2.WebApi.Controllers
{
    // https://localhost:7120/api/product => api url, endpoint, resource , route
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        protected readonly AppDbContext _db;

        public ProductController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var lst = _db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateProduct(TblProduct product)
        {
            _db.TblProducts.Add(product);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")] // မရှိရင် insert လုပ်မယ် ရှိရင် update လုပ်မယ်
        public IActionResult UpsetProduct(int id, TblProduct product)
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if(item is null)
            {
                _db.TblProducts.Add(product);
                _db.SaveChanges();
            }
            else
            {
                item.Name = product.Name;
                item.Price = product.Price;
                _db.SaveChanges();
            }
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, TblProduct product)
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
            {
                return NotFound();
            }

            item.Name = product.Name;
            item.Price = product.Price;
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if(item is null)
            {
                return NotFound();
            }
            item.DeleteFlag = true;
            _db.SaveChanges();
            return Ok();
        }

    }
}

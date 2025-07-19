using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AKZDotNetTrainingBatch2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //process
            //data
            return Ok("Get product");
        }

        [HttpPost]
        public IActionResult Create()
        {
            //process
            //data
            return Ok("Create product");
        }

        [HttpPut]
        public IActionResult Upset()
        {
            //process
            //data
            return Ok("Upsert product");
        }

        [HttpPatch]
        public IActionResult Update()
        {
            //process
            //data
            return Ok("Update product");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            //process
            //data
            return Ok("Delete product");
        }

    }
}

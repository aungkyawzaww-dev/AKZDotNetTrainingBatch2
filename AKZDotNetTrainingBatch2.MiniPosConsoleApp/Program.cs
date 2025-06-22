
using AKZDotNetTrainingBatch2.MiniPosConsoleApp;

Console.WriteLine("Welcome Mini POS");


ProductService productService = new ProductService();
//productService.Read();
//productService.Edit();
//productService.Create();
//productService.Update();
//productService.Delete();

SaleService saleService = new SaleService();
//saleService.Read();
//saleService.Edit();
//saleService.Create();

SaleDetailService saleDetailService = new SaleDetailService();
//saleDetailService.Read();
//saleDetailService.Edit();
saleDetailService.Create();

Console.ReadKey();
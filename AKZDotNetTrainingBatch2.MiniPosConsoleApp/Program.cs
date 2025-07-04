
using AKZDotNetTrainingBatch2.MiniPosConsoleApp;

//Console.WriteLine("Welcome Mini POS");


//Result:
//Console.WriteLine("Menu");
//Console.WriteLine("-----------------------");
//Console.WriteLine("1. Product Menu");
//Console.WriteLine("2. Sale");
//Console.WriteLine("3. Sale Detail");
//Console.WriteLine("4. Exit");
//Console.WriteLine("-----------------------");

//Console.Write("Choose Menu : ");
//string result = Console.ReadLine()!;
//bool isInt = int.TryParse(result, out int no);
//if (!isInt)
//{
//    Console.WriteLine("Invalid Menu. Please choose 1 to 4");
//    goto Result;
//}

//Console.WriteLine("-----------------------");

//EnumMenu menu = (EnumMenu)no;
//switch (menu)
//{
//    case EnumMenu.ProductMenu:
//        Console.WriteLine("This is Product Menu");
//        ProductService productService = new ProductService();
//        productService.Execute();
//        goto Result;

//    case EnumMenu.Sale:
//        Console.WriteLine("This is Sale Menu");
//        SaleService saleService = new SaleService();
//        //saleService.Execute();
//        goto Result;

//    case EnumMenu.SaleDetail:
//        Console.WriteLine("This is Sale Detail Menu");
//        SaleDetailService saleDetailService = new SaleDetailService();
//        //saleDetailService.Execute();
//        goto Result;

//    case EnumMenu.Exit:
//        Console.WriteLine("Thank you.");
//        goto End;

//    case EnumMenu.None:
//    default:
//        break;

//}

//End:
//    Console.WriteLine("Existing Menu POS...");


SaleFeatureService saleFeatureService = new SaleFeatureService();
saleFeatureService.Execute();



//SaleService saleService = new SaleService();
//saleService.Read();
//saleService.Edit();
//saleService.Create();

//SaleDetailService saleDetailService = new SaleDetailService();
//saleDetailService.Read();
//saleDetailService.Edit();
//saleDetailService.Create();

Console.ReadKey();
using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using AKZDotNetTrainingBatch2.Project1.Domain.Features;


namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class ProductUI
    {
        public void Read()
        {
            //AppDbContext db = new AppDbContext();
            //List<TblProduct> lst = db.TblProducts
            //    .Where(x => x.DeleteFlag == false)
            //    .OrderByDescending(x => x.ProductId)
            //    .ToList();  
            ProductService productService = new ProductService();
            var lst = productService.GetProducts();

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

            ProductService productService = new ProductService();
            var item = productService.FindProduct(id);

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
            int ProductPrice = Convert.ToInt32(Console.ReadLine())!;

            ProductService productService = new ProductService();
            var result = productService.CreateProduct(ProductName, ProductPrice);
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
            int ProductPrice = Convert.ToInt32(Console.ReadLine())!;

            ProductService productService = new ProductService();
            var result = productService.UpdateProduct(id, ProductName, ProductPrice);
            if(result == -1)
            {
                Console.WriteLine("No Data Found");
                goto FirstPage;
            }
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
            ProductService productService = new ProductService();
            var result = productService.DeleteProduct(id);
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

        public void Execute()
        {
           Result:
            Console.WriteLine("Product Menu");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. New Product");
            Console.WriteLine("2. Show All Product");
            Console.WriteLine("3. Product List");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("-----------------------");

            Console.Write("Choose Product Menu : ");
            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Product Menu. Please choose 1 to 6");
                goto Result;
            }

            Console.WriteLine("-----------------------");

            EnumProductMenu menu = (EnumProductMenu)no;
            switch (menu)
            {
                case EnumProductMenu.NewProduct:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is New Product");
                    Create();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumProductMenu.ShowAllProduct:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is Show All Product");
                    Read();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumProductMenu.ProductList:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is Product List ");
                    Edit();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumProductMenu.UpdateProduct:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is Update Product");
                    Update();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumProductMenu.DeleteProduct:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is Delete Product");
                    Delete();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumProductMenu.Exit:
                    Console.WriteLine("This is Exit Product");
                    goto End;
                case EnumProductMenu.None:
                default:
                    break;
            }
            Console.WriteLine("-----------------------");

            End:
                Console.WriteLine("Existing Product Menu");
        }

    }

    public enum EnumProductMenu
    {
        None,
        NewProduct,
        ShowAllProduct,
        ProductList,
        UpdateProduct,
        DeleteProduct,
        Exit
    }

    public enum EnumMenu
    {
        None,
        ProductMenu,
        Sale,
        SaleDetail,
        Exit
    }
}



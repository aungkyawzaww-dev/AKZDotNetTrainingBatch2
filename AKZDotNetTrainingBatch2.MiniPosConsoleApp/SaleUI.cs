using AKZDotNetTrainingBatch2.MininPosDatabase.AppDbContextModels;
using AKZDotNetTrainingBatch2.Project1.Domain.Features;

namespace AKZDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SaleUI
    {

        public void Execute()
        {
        Result:
            Console.WriteLine("Sale Menu");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. New Sale");
            Console.WriteLine("2. Sale List");
            Console.WriteLine("3. Sale Detail");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------");

            Console.Write("Choose Product Menu : ");
            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int no);
            if (!isInt)
            {
                Console.WriteLine("Invalid Sale Menu. Please choose 1 to 4");
                goto Result;
            }

            Console.WriteLine("-----------------------");

            EnumSaleMenu menu = (EnumSaleMenu)no;
            switch (menu)
            {
                case EnumSaleMenu.NewSale:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is New Sale");
                    NewSale();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumSaleMenu.SaleList:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is Show All Sale");
                    SaleList();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumSaleMenu.SaleDetail:
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("This is Sale Detail ");
                    SaleDetail();
                    Console.WriteLine("-----------------------");
                    goto Result;

                case EnumSaleMenu.Exit:
                    Console.WriteLine("This is Exit Sale");
                    goto End;
                case EnumSaleMenu.None:
                default:
                    Console.WriteLine("Invalid Sale Menu. Please Choose 1 to 4");
                    goto Result;
            }
            Console.WriteLine("-----------------------");
            goto Result;

        End:
            Console.WriteLine("Existing Product Menu");
        }

        public void NewSale()
        {
            List<TblSaleDetail> products = new List<TblSaleDetail>();
            SaleService saleService = new SaleService();

          FirstPage:
           #region add products
            Console.Write("Please enter product Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            //var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            var item = saleService.FindProduct(id);

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

           #endregion

            #region add more product or continue

            Console.WriteLine("Are you sure want to add more? Y/N");
            string comfirm = Console.ReadLine()!;
            if(comfirm == "Y")  goto FirstPage;

            #endregion end add more product or continue

            int result = saleService.Sale(products);
            Console.WriteLine(result > 0 ? "Sale Processing Success." : "Failed.");
            Console.WriteLine("-----------------------------------------------------");

        }

        public void SaleList()
        {
            SaleService saleService = new SaleService();
            var lst = saleService.GetSales();

            foreach (var item in lst)
            {
                Console.WriteLine("SaleID : " + item.SaleId);
                Console.WriteLine("Sale VoucherNo : " + item.VoucherNo);
                Console.WriteLine("Total Amount : " + item.TotalAmount);
                Console.WriteLine("Sale Date : " + item.SaleDate);
            }
        }

        public void SaleDetail()
        {
        FirstPage:
            Console.Write("Enter Id : ");
            string resultId = Console.ReadLine()!;
            bool isInt = int.TryParse(resultId, out int id);

            if (!isInt) goto FirstPage;

            SaleService saleService = new SaleService();
            var item = saleService.FindId(id);

            if (item == null)
            {
                Console.WriteLine("You Invalid Id!");
                goto FirstPage;
            }

            Console.WriteLine("SaleID : " + item.SaleId);
            Console.WriteLine("Sale VoucherNo : " + item.VoucherNo);
            Console.WriteLine("Total Amount : " + item.TotalAmount);
            Console.WriteLine("Sale Date : " + item.SaleDate);
        }

    }

    public enum EnumSaleMenu
    {
        None,
        NewSale,
        SaleList,
        SaleDetail,
        Exit
    }

}

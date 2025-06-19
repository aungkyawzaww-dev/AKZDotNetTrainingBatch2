using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    internal class DapperHomeWork
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                List<PhoneShopDto> lst = db.Query<PhoneShopDto>("SELECT * FROM Tbl_PhoneShop").ToList();
                foreach(var item in lst)
                {
                    Console.WriteLine("PhoneShopID => " + item.id);
                    Console.WriteLine("PhoneShopName => " + item.name);
                    Console.WriteLine("PhoneShopPrice => " + item.price);
                    Console.WriteLine("PhoneShopQuantity => " + item.quantity);
                }
            }
        }

        public void Edit()
        {
           FirstPage:
            Console.WriteLine("Enter Id : ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<PhoneShopDto>("SELECT * FROM Tbl_PhoneShop WHERE id = @id", new { Id = id });
                if (item == null)
                {
                    Console.WriteLine("PhoneShop id Not Found!" + id);
                    return;
                }

                Console.WriteLine("PhoneShopID => " + item.id);
                Console.WriteLine("PhoneShopName => " + item.name);
                Console.WriteLine("PhoneShopPrice => " + item.price);
                Console.WriteLine("PhoneShopQuantity => " + item.quantity);
            }
        }


        public void Create()
        {
            Console.Write("Enter Name : ");
            string PhoneName = Console.ReadLine()!;

            Console.Write("Enter Price : ");
            string PhonePrice = Console.ReadLine()!;

            Console.Write("Enter Quantity : ");
            string PhoneQuantity = Console.ReadLine()!;


            PhoneShopDto phoneShop = new PhoneShopDto()
            {
                name = PhoneName,
                price = PhonePrice,
                quantity = PhoneQuantity
            };

            string query = @"INSERT INTO [dbo].[Tbl_PhoneShop]
                           ([name]
                           ,[price]
                           ,[quantity])
                            VALUES
                           (@name
                           ,@price
                           ,@quantity)";

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, phoneShop);

                Console.WriteLine(result > 0 ? "Creating Successfully!" : "Creating Failed!");
            }


        }


        public void Update()
        {
           FirstPage:
            Console.WriteLine("Enter Id : ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            Console.Write("Enter Name : ");
            string PhoneName = Console.ReadLine()!;

            Console.Write("Enter Price : ");
            string PhonePrice = Console.ReadLine()!;

            Console.Write("Enter Quantity : ");
            string PhoneQuantity = Console.ReadLine()!;

            PhoneShopDto phoneShop = new PhoneShopDto()
            {
                id = id,
                name = PhoneName,
                price = PhonePrice,
                quantity = PhoneQuantity
            };

            string query = @"UPDATE [dbo].[Tbl_PhoneShop]
                            SET [name] = @name
                              ,[price] = @price
                              ,[quantity] = @quantity 
                           WHERE id = @id";

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, phoneShop);

                Console.WriteLine(result > 0 ? "Updating Successfully!" : "Updating Failed!");
            }
        }

        public void InsertColumn()
        {
           FirstPage:
            Console.WriteLine("Enter Id : ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            Console.Write("Enter Name : ");
            string PhoneName = Console.ReadLine()!;

            Console.Write("Enter Price : ");
            string PhonePrice = Console.ReadLine()!;

            Console.Write("Enter Quantity : ");
            string PhoneQuantity = Console.ReadLine()!;

            PhoneShopDto phoneShop = new PhoneShopDto()
            {
                id = id,
                name = PhoneName,
                price = PhonePrice,
                quantity = PhoneQuantity
            };

            string query = @"SET IDENTITY_INSERT Tbl_PhoneShop ON;
                            INSERT INTO Tbl_PhoneShop (id,name,price,quantity)
                            VALUES (@id,@name,@price,@quantity);
                            SET IDENTITY_INSERT Tbl_PhoneShop OFF;
                            ";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, phoneShop);

                Console.WriteLine(result > 0 ? "Updating Query Successfully!" : "Updating Query Failed!");
            }
        }

        public void Delete()
        {
        FirstPage:
            Console.WriteLine("Enter Id : ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);

            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<PhoneShopDto>("SELECT * FROM Tbl_PhoneShop WHERE id = @id", new { Id = id });
                if (item == null)
                {
                    Console.WriteLine("PhoneShop id Not Found!" + id);
                    return;
                }

                string query = "DELETE FROM Tbl_PhoneShop WHERE id = @id";

                var result = db.Execute(query, new PhoneShopDto { id = id });

                Console.WriteLine(result > 0 ? "Deleting Successfully!" : "Deleting Failed!");

            }
        }

    }
}

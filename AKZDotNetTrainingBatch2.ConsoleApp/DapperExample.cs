using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    internal class DapperExample
    {
        // Read
        // Edit

        // Create
        // Update
        // Delete

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
                List<BlogDto> lst = db.Query<BlogDto>("SELECT * FROM Tbl_Blog").ToList();
                foreach(var item in lst)
                {
                    Console.WriteLine("BlogID => "+ item.BlogId);
                    Console.WriteLine("BlogTitle => "+ item.BlogTitle);
                    Console.WriteLine("BlogAuthor => "+ item.BlogAuthor);
                    Console.WriteLine("BlogContent => "+ item.BlogContent);
                }
            }

        }

        public void Edit()
        {
        FirstPage:
            Console.WriteLine("Enter Id : ");
            string input = Console.ReadLine()!;
            //int id = Convert.ToInt32(Console.ReadLine());
            bool isInt = int.TryParse(input, out int id);

            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog id Not Found!" + id);
                    return;
                }

                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);

            }
        }

        public void Create()
        {

            Console.Write("Enter Blog Title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Blog Author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Blog Content : ");
            string content = Console.ReadLine()!;

            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([BlogTitle]
                           ,[BlogAuthor]
                           ,[BlogContent])
                            VALUES
                           (@BlogTitle,
                           @BlogAuthor,
                           @BlogContent)";

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, blogDto);

                Console.WriteLine(result > 0? "Saving Successfully!" : "Saving Failed!");
            }
        }

        public void Update()
        {
            FirstPage:
            Console.Write("Enter Blog Id : ");
            string inputId = Console.ReadLine()!;
            //int id = Convert.ToInt32(inputId);
            bool isInt = int.TryParse(inputId, out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            Console.Write("Modify Blog Title : ");
            string title = Console.ReadLine()!;

            Console.Write("Modify Blog Author : ");
            string author = Console.ReadLine()!;

            Console.Write("Modify Blog Content : ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                                SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent
                                WHERE [BlogId] = @BlogId";

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query,blog);  
                Console.WriteLine(result > 0 ? "Update Successfully!" : "Update Failed!");

            }
        }


        public void Delete()
        {
        FirstPage:
            Console.Write("Enter Blog Id : ");
            string inputId = Console.ReadLine()!;
            bool isInt = int.TryParse(inputId, out int id);
            if (!isInt)
            {
                Console.WriteLine("Invalid Id");
                goto FirstPage;
            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog id Not Found!" + id);
                    return;
                }

                string query = "DELETE FROM Tbl_Blog WHERE BlogID = @BlogId";

                var result = db.Execute(query, new BlogDto { BlogId = id });

                Console.WriteLine(result > 0 ? "Deleting Successfully!" : "Deleting Failed!");

            }
        }
    }
}

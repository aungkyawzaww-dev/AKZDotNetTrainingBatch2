using Microsoft.Data.SqlClient;
using System.Data;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    internal class AdoDotNetBlog
    {

        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection open.");

            string query = "SELECT * FROM Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection close.");


            List<BlogDto> list = new List<BlogDto>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);

                BlogDto blogDto = new BlogDto();
                blogDto.BlogId = Convert.ToInt32(row["BlogId"]);
                blogDto.BlogTitle = Convert.ToString(row["BlogTitle"])!;
                blogDto.BlogAuthor = Convert.ToString(row["BlogAuthor"])!;
                blogDto.BlogContent = Convert.ToString(row["BlogContent"])!;
                list.Add(blogDto); // list အသစ် တစ်ခုဆောက်ပြီးပြန် ထည့်ပေးတာ
            }

        }


        public void Edit()
        {
            Console.Write("Enter Id : ");
            string blogId = Console.ReadLine()!; // this value can be null so i write (!) 

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            // this can be sqlconjection
            string query = $"SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
                
            //input this code for protect sqlConjection
            cmd.Parameters.AddWithValue("@BlogId", blogId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }

        }

        public void Create()
        {
            Console.Write("Enter Title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content : ");
            string content = Console.ReadLine()!;

            //this can be sqlInjection 
            //string query = $@"INSERT INTO [dbo].[Tbl_Blog]] ([BlogTitle] ,[BlogAuthor],[BlogContent]) VALUES
            //           ('{title}', '{author}','{content}')";

            //this is correct 
                string query = $@"INSERT INTO [dbo].[Tbl_Blog] 
                ([BlogTitle],
                [BlogAuthor],
                [BlogContent]) 
                VALUES
                (@Title,
                  @Author,
                  @Content)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection); // connect command with database
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);

            int result = cmd.ExecuteNonQuery(); // ExecuteNonQuery is used for insert, update, delete operations
            connection.Close();
            Console.WriteLine(result > 0 ? "Create Success" : "Create Failed");

        }



        public void Update()
        {
            Console.Write("Enter Id : ");
            string blogId = Console.ReadLine()!;

            Console.Write("Enter Title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content : ");
            string content = Console.ReadLine()!;


            string query = $@"UPDATE [dbo].[Tbl_Blog]
               SET [BlogTitle] = @Title
                  ,[BlogAuthor] = @Author
                  ,[BlogContent] = @Content
             WHERE BlogId = @blogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection); // connect command with database
            cmd.Parameters.AddWithValue("@blogId", blogId);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Update Success" : "Update Failed");

        }

        public void Delete()
        {
            Console.Write("Enter Id : ");
            string blogId = Console.ReadLine()!;

            string query = $@"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @blogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection); // connect command with database
            cmd.Parameters.AddWithValue("@blogId", blogId);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Delete Success" : "Delete Failed");

        }


    }
}

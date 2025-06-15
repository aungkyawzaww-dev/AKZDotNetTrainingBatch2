using Microsoft.Data.SqlClient;
using System.Data;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    internal class AdoDotNetExample
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

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = ".";
            ////sqlConnectionStringBuilder.DataSource = "(local)";
            ////sqlConnectionStringBuilder.DataSource = "DESKTOP-TEJOLGB";
            //sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch2";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasa@123";
            //sqlConnectionStringBuilder.TrustServerCertificate = true;


            //SqlConnection connection = new SqlConnection(Data Source =.; Initial Catalog = DotNetTrainingBatch2; User ID = sa; Password = sasa@123; Trust Server Certificate=True);
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection open.");

            string query = "SELECT * FROM Tbl_Student";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection close.");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(row["studentId"]);
                Console.WriteLine(row["studentName"]);
            }

        }

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Student]
           ([StudentNo]
           ,[StudentName]
           ,[DateOfBirth]
           ,[MobileNo]
           ,[Email]
           ,[Gender]
           ,[Address]
           ,[FatherName]
           ,[DeleteFlag])
     VALUES
           ('S0019'
           ,'Lwin Lwin'
           ,'2000-01-01'
           ,'0938748882'
           ,'lwin@gmail.com'
           ,'Female'
           ,'Yangon'
           ,'U Aung'
           ,0)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection); // connect command with database
            int result = cmd.ExecuteNonQuery(); // do execute

            connection.Close();
            Console.WriteLine(result > 0 ? "Insert Success" : "Insert Failed");

        }


        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Student]
               SET [StudentNo] = 'S0019'
              ,[StudentName] = 'Lwin Lwin Aung'
              ,[DateOfBirth] = '2000-01-01 00:00:00.000'
              ,[MobileNo] = '0938748882'
              ,[Email] = 'lwin@gmail.com'
              ,[Gender] = 'Female'
              ,[Address] = 'Yangon'
              ,[FatherName] = 'U Aung'
              ,[DeleteFlag] = 0
               WHERE StudentId = 18 ";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection); // connect command with database
            int result = cmd.ExecuteNonQuery(); // do execute

            connection.Close();
            Console.WriteLine(result > 0 ? "Update Success" : "Update Failed");

        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Student] WHERE StudentId = 18";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection); // connect command with database
            int result = cmd.ExecuteNonQuery(); // do execute

            connection.Close();
            Console.WriteLine(result > 0 ? "Delete Success" : "Delete Failed");

        }


    }
}

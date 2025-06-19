using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = ".",
                    InitialCatalog = "DotNetTrainingBatch2",
                    UserID = "sa",
                    Password = "sasa@123",
                    TrustServerCertificate = true
                };

                //sql server ဖြစ်လို့  တခြား database ဆိုရင် တစ်မျိုးပြောင်းရေးရမယ် package သွင်းထားတာလည်းပြောင်းသွားမယ်
                optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
            }
        }

        // AppDbContext နဲ့ BlogModel ကို mapping လုပ် 
        public DbSet<BlogModel> Blogs { get; set; }
    }


    //Model First  > Database Column mapping
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        // Method 1 
        [Key] // Primary Key
        [Column("BlogId")]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public bool DeleteFlag { get; set; }
    }

}

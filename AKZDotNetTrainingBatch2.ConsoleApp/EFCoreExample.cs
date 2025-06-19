using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .OrderByDescending(x => x.BlogId)
                .ToList(); // execute 
            foreach (var item in lst)
            {
                Console.WriteLine("BlogID => " + item.BlogId);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }
        }


        public void Edit()
        {
           FirstPage:
            Console.Write("Enter Id : ");
            string result = Console.ReadLine()!;

            bool isInt = int.TryParse(result, out int id);
            if (!isInt)
            {
                goto FirstPage;
            };

            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.BlogId == id);
            //if (item == null) return;
            if (item is null)
            {
                Console.Write("You Invalid id!");
                goto FirstPage;
            };

            Console.WriteLine("BlogID => " + item.BlogId);
            Console.WriteLine("BlogTitle => " + item.BlogTitle);
            Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
            Console.WriteLine("BlogContent => " + item.BlogContent);

        }

        public void Create()
        {
            Console.Write("Enter Title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content : ");
            string content = Console.ReadLine()!;

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Saving Successful." : "Saving Failed.");
        }

        public void Update()
        {
           FirstPage:
            Console.Write("Enter Id : ");
            string myid = Console.ReadLine()!;

            bool isInt = int.TryParse(myid, out int id);
            if (!isInt)
            {
                goto FirstPage;
            };

            Console.Write("Enter Title : ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author : ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content : ");
            string content = Console.ReadLine()!;

            //Find BlogId 
            bool isExit = IsExitBlog(id);
            if (!isExit) return;

            // update process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.BlogId == id);

            //Method 1 (item မှာက BlogModel ဆိုတဲ့ model ပါလာပြီးသားဖြစ်တော့ တခါတည်းတန်း bind လို့ရ )
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            //Method 2
            //BlogModel blog = new BlogModel()
            //{
            //    BlogTitle = title,
            //    BlogAuthor = author,
            //    BlogContent = content
            //};

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Updating Successful." : "Updating Failed.");

        }

        public void Delete()
        {
          FirstPage:
            Console.Write("Enter Id : ");
            string myid = Console.ReadLine()!;

            bool isInt = int.TryParse(myid, out int id);
            if (!isInt)
            {
                goto FirstPage;
            }
            ;

            //Find BlogId 
            bool isExit = IsExitBlog(id);
            if (!isExit) return;

            // delete process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            //db.Blogs.Remove(item);
            item.DeleteFlag = true;

            int result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Deleting Successful." : "Deleting Failed.");
        }

        public bool IsExitBlog(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.DeleteFlag == false)
                .FirstOrDefault(x => x.BlogId == id);
            //return item == null ? true : false;
            return item != null;
        }
    }
}

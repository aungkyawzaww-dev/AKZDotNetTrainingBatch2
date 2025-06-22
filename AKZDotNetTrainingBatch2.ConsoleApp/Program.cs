

using AKZDotNetTrainingBatch2.ConsoleApp;
using AKZDotNetTrainingBatch2.Database;
using AKZDotNetTrainingBatch2.Database.App2DbContextModels;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

//AdoDotNetBlog adoDotNetBlog = new AdoDotNetBlog();
//adoDotNetBlog.Read();
//adoDotNetBlog.Edit();
//adoDotNetBlog.Create();
//adoDotNetBlog.Update();
//adoDotNetBlog.Delete();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
//dapperExample.Delete();


//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit();
//eFCoreExample.Create();
//eFCoreExample.Update();
//eFCoreExample.Delete();

//TestLinq testLinq = new TestLinq();
//testLinq.Read();

//DapperHomeWork dapperHomeWork = new DapperHomeWork();
//dapperHomeWork.Read();
//dapperHomeWork.Edit();
//dapperHomeWork.Create();
//dapperHomeWork.Update();
//dapperHomeWork.Delete();
//dapperHomeWork.InsertColumn();

//Class1 class1 = new Class1();
//int result = class1.Method(1,2);
//Console.WriteLine(result);

App2DbContext appDbContext = new App2DbContext();
var result = appDbContext.TblBlogs.ToList();


Console.ReadKey();
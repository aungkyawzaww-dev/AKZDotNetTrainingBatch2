using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKZDotNetTrainingBatch2.ConsoleApp
{
    public class TestLinq
    {
        List<StudentDto> students = new List<StudentDto>
    {
        new StudentDto
        {
            Id = 1,
            Name = "John Doe",
            FatherName = "Robert Doe",
            Age = 20,
            Address = "123 Elm Street, Springfield",
            DateOfBirth = new DateTime(2003, 5, 15),
            MobileNo = "123-456-7890",
            Gender = "Male",
            DeleteFlag = false
        },
        new StudentDto
        {
            Id = 2,
            Name = "Jane Smith",
            FatherName = "Michael Smith",
            Age = 22,
            Address = "456 Oak Avenue, Metropolis",
            DateOfBirth = new DateTime(2001, 3, 10),
            MobileNo = "987-654-3210",
            Gender = "Female",
            DeleteFlag = false
        },
        new StudentDto
        {
            Id = 3,
            Name = "Alice Johnson",
            FatherName = "William Johnson",
            Age = 19,
            Address = "789 Pine Road, Gotham",
            DateOfBirth = new DateTime(2004, 8, 20),
            MobileNo = "555-666-7777",
            Gender = "Female",
            DeleteFlag = false

        },
        new StudentDto
        {
            Id = 4,
            Name = "Mark Lee",
            FatherName = "Thomas Lee",
            Age = 21,
            Address = "101 Maple Drive, Star City",
            DateOfBirth = new DateTime(2002, 12, 5),
            MobileNo = "222-333-4444",
            Gender = "Male",
            DeleteFlag = true

        }
    };

        
        public void Read()
        {
            //var lst = students
            //    .Where(x => x.Age > 20)
            //    .Where(x => x.DeleteFlag == false)
            //    .OrderByDescending(x => x.Id)
            //    .ToList();

            //var lst = students
            //.Select(x => x.Age + 10)
            //.ToList();

            // OrderBy
            //var lst = students
            //    .Where(x => x.Gender == "Female")
            //    .OrderBy(x=>x.Id).ToList();

            //First
            //var lst = students.First();
            //Console.WriteLine("Id => " + lst.Id);
            //Console.WriteLine("Name => " + lst.Name);
            //Console.WriteLine("Father Name => " + lst.FatherName);
            //Console.WriteLine("Address => " + lst.Address);
            //Console.WriteLine("Gender => " + lst.Gender);

            //FirstOrDefault
            //var lst = students.FirstOrDefault(x => x.Gender == "Male");
            //Console.WriteLine("Id => " + lst.Id);
            //Console.WriteLine("Name => " + lst.Name);
            //Console.WriteLine("Father Name => " + lst.FatherName);
            //Console.WriteLine("Address => " + lst.Address);
            //Console.WriteLine("Gender => " + lst.Gender);


            // total age
            //var lst = students
            //    .Sum(x => x.Age);
            //Console.WriteLine("age => " + lst);

            // Max
            //var lst = students
            //    .Max(x => x.Age);
            //Console.WriteLine("Max age => " + lst);


            var lst = students.ToList();
            foreach (var x in lst)
            {
                //Console.WriteLine("Age => " + x);
                Console.WriteLine("Id => " + x.Id);
                Console.WriteLine("Name => " + x.Name);
                Console.WriteLine("Father Name => " + x.FatherName);
                Console.WriteLine("Address => " + x.Address);
                Console.WriteLine("Gender => " + x.Gender);
            }

        }
    }
}

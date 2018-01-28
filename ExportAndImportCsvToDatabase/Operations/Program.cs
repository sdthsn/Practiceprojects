using CsvHelper;
using DataLayer.ModelPerson;
using DataLayer.PersonRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    //string resourceName = "SeedingDataFromCSV.Domain.SeedData.countries.csv";
        //    string resourceName = "CSV//Sample.csv";
        //    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //        {
        //            CsvReader csvReader = new CsvReader(reader);
        //            var persons = csvReader.GetRecords<Person>().ToList();

        //            using (var db = new PersonContext())
        //            {
        //                db.Persons.AddOrUpdate(c=>c);
        //                var i = db.SaveChanges();
        //                Console.WriteLine(i);
        //                }
        //            }
        //        }
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            IList<Person> data = new List<Person>();
            //getting full file path of Uploaded file  
            string CSVFilePath = @"C:\Users\sdths\onedrive\documents\visual studio 2017\Projects\ExportAndImportCsvToDatabase\Operations\CSV\Sample.csv";
            //Reading All text  
            string ReadCSV = File.ReadAllText(CSVFilePath);
            //spliting row after new line  
            foreach (string csvRow in ReadCSV.Split('\n'))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    var colums = csvRow.Split(',');
                    Person person = new Person();
                    person.FirstName = colums[0];
                    person.LastName = colums[1];
                    person.Email = colums[2];
                    person.ContactNumber = colums[3];
                    data.Add(person);
                }
            }

            using (var db = new PersonContext())
            {
                //data.ForEach(c=>db.Persons.Add(c));
                data[0].Id = 1;
                data[0].FirstName = "Shadat";
                data[0].LastName = "Hossain";
                db.Persons.AddRange(data.AsEnumerable());
                Console.WriteLine(db.Database.Connection.ConnectionString);
                int i = db.SaveChanges();
                Console.WriteLine("{0} records added...", i);

            }
            Console.ReadLine();



            Console.ReadKey();

        }
    }
}

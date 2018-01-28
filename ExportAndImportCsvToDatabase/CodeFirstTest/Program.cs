using DataDomain.Model;
using DataDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db= new BlogContext())
            {
                Guid postId = Guid.NewGuid();
                Guid catId = Guid.NewGuid();
                var cat = new Category { Id = catId, Name = "ASP.NET" };
                var post = new BlogPost { Id = postId, Title = "Title1", Content = "Hello World!", PublishDate = new DateTime(2011, 1, 1), Category = cat };
                db.Categories.Add(cat);
                db.BlogPosts.Add(post);
                Console.WriteLine(db.Database.Connection.ConnectionString);
                int i = db.SaveChanges();
                Console.WriteLine("{0} records added...", i);

            }
            Console.ReadLine();
        }
    }
}

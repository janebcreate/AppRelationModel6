using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company = db.Companies.FirstOrDefault();
                db.Entry(company).Collection(t => t.Users).Load();
                Console.WriteLine($"Company: {company.Name}");
                foreach (var p in company.Users)
                    Console.WriteLine($"User: {p.Name}");
            }
        }
    }
}
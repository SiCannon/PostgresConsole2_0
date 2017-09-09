using System;
using System.Linq;

namespace PostgresConsole2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            Seed();

            using (var context = new PieContext())
            {
                Console.WriteLine("Here are the pies:");
                foreach (var p in context.Pies)
                {
                    Console.WriteLine($"  name: {p.Filling}");
                }
            }

            Console.WriteLine("end");
        }

        static void Seed()
        {
            using (var context = new PieContext())
            {
                if (!context.Pies.Any())
                {
                    Console.Write("Seeding database...");
                    context.Pies.Add(new Pie { Filling = "Custard" });
                    context.Pies.Add(new Pie { Filling = "Apple" });
                    context.Pies.Add(new Pie { Filling = "Steak & Kidney" });
                    context.SaveChanges();
                    Console.WriteLine("done");
                }
            }
        }
    }
}

using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace PostgresConsole2_0
{
    public class PieContext : DbContext
    {
        public DbSet<Pie> Pies { get; set; }

        public PieContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        private string ConnectionString
        {
            get
            {
                if (!File.Exists("connectionstring.txt"))
                {
                    throw new Exception("File not found: connectionstring.txt");
                }
                if (!File.Exists("password.txt"))
                {
                    throw new Exception("File not found: password.txt");
                }
                var connectionString = File.ReadAllText("connectionstring.txt");
                var password = File.ReadAllText("password.txt");
                return connectionString.Replace("%PASSWORD%", password);
            }
        }
    }
}

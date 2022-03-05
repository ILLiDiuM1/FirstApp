using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {           
                var builder = new ConfigurationBuilder()                
                .SetBasePath(Directory.GetCurrentDirectory())               
                .AddJsonFile("appsettings.json");
                var config = builder.Build();

                string connectionString = config.GetConnectionString("DefaultConnection");

                var optionsBuilder = new DbContextOptionsBuilder<helloappdbContext>();
                var options = optionsBuilder.UseSqlServer(connectionString).Options;
                using (helloappdbContext db = new helloappdbContext())
                {
                    var users = db.Users.ToList();
                    foreach (User u in users)
                    {
                        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                    }
                }
                Console.Read();
            }
        }
    }
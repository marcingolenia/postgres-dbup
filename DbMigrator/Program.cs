using System;
using System.Linq;
using System.Reflection;
using DbUp;
	
namespace DbMigrator
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? "Host=127.0.0.1;User Id=postgres;Password=Secret!Passw0rd;Database=crazy_database;Port=5432";
            EnsureDatabase.For.PostgresqlDatabase(connectionString);
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value: "Success!");
            Console.ResetColor();
            return 0;
        }
    }
}

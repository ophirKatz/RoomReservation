using DAL.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace DbFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var dataFileName = config["Reader:DataFileName"];
            var dbConfig = config.GetSection(nameof(DatabaseConfiguration))
                  .Get<DatabaseConfiguration>();

            new DatabaseFiller(new JsonDataReader(dataFileName), dbConfig)
                .FillDb();

            Console.ReadKey();
        }
    }
}
using DAL.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace DbFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            Configure();
            new DatabaseFiller(new JsonDataReader(DataFileName), DbConfig)
                .FillDb();
            Console.ReadKey();
        }

        public static IDatabaseConfiguration Configure()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            DataFileName = config["Reader:DataFileName"];
            DbConfig = config.GetSection(nameof(DatabaseConfiguration))
                .Get<DatabaseConfiguration>();

            return DbConfig;
        }

        private static string DataFileName;
        private static IDatabaseConfiguration DbConfig;
    }
}
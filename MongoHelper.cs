using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Arduino_testi
{
    class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb://Tietotekniikkaprojekti:projekti2020@cluster0-shard-00-00-bg3jl.azure.mongodb.net:27017,cluster0-shard-00-01-bg3jl.azure.mongodb.net:27017,cluster0-shard-00-02-bg3jl.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
        public static string MongoDatabase = "Tietotekniikka";

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
                Console.WriteLine("Yhteys muodostettu");

            }
            catch (Exception)
            {
                Console.WriteLine("Yhteys muodostettu2");
                throw;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace M101DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static async Task MainAsync(String[] args)
        {
            //var doc = new BsonDocument
            //{
            //    {"name","Jones"}
            //};
            //doc.Add("age", 30);
            //doc["profession"] = "Hacker";

            //var nestedArray = new BsonArray();
            //nestedArray.Add(new BsonDocument("color", "Red"));
            //doc.Add("array", nestedArray);

            //Console.WriteLine(doc["name"]);
            //Console.WriteLine(doc["array"][0]["color"]);
            //Console.WriteLine(doc);

            //var ele = new BsonElement();

            //doc.TryGetElement("name", out ele);
            //Console.WriteLine(ele);
            var doc = new BsonDocument
            {
                {"name", "Jones"}
                ,{"age", 32}
                ,{"profession", "Hacker"}
            };

            var doc2 = new BsonDocument
            {
                {"name", "Sam"}
                ,{"age", 42}
                ,{"profession", "Engineer"}
            };

            var doc3 = new Person
            {
                Name = "Nimal",
                Age = 33,
                Profession = "Doctor"
            };

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");
            //var col = db.GetCollection<Person>("people");

            //await col.InsertOneAsync(doc);
            //await col.InsertManyAsync(new[] { doc, doc2 });

            //Console.WriteLine(doc3.Id);
            //await col.InsertOneAsync(doc3);
            //Console.WriteLine(doc3.Id);

            await col.InsertOneAsync(doc);
            doc.Remove("_id");
            await col.InsertOneAsync(doc);
        }
    }

    class Person
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Profession { get; set; }
    }
}

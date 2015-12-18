using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static async Task MainAsync(String[] args)
        {

            var client = new MongoClient();
            var db = client.GetDatabase("test");

            var animals = db.GetCollection<BsonDocument>("animals");

            var animal = new BsonDocument
                            {
                            {"animal", "monkey"}
                            };

            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "cat");
            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "lion");
            await animals.InsertOneAsync(animal);
            //var client = new MongoClient();
            //var db = client.GetDatabase("exam");

            //var images = db.GetCollection<Image>("images");

            //List<Album> Albums = await db.GetCollection<Album>("albums").Find("{}").ToListAsync();
            //List<Image> Images = await images.Find("{}").ToListAsync();
            //int count = 0;
            //List<Image> lstOrphanImages = new List<Image>();
            //foreach (Image img in Images)
            //{
            //    bool isFound = false;
            //    foreach (Album album in Albums)
            //    {
            //        if (album.images.Any(x => x == img.Id))
            //        {
            //            isFound = true;
            //            break;
            //        }
            //    }

            //    if (!isFound)
            //    {
            //        count++;
            //        lstOrphanImages.Add(img);
            //        await images.DeleteOneAsync(x => x.Id == img.Id);
            //    }
            //}
        }
    }
}

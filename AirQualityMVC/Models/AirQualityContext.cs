using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AirQualityMVC.Models
{
    public class AirQualityContext
    {

        public IMongoDatabase MongoDB;

        public AirQualityContext()
        {
            var client = new MongoClient();
            MongoDB = client.GetDatabase("AirQualityViewMongoDB");
            var collection = MongoDB.GetCollection<AirQuality>("AirQualityViewCollection");
        }

        public IMongoCollection<AirQuality> AirQualityData
        {
            get { return MongoDB.GetCollection<AirQuality>("AirQualityViewCollection"); }
        }
    }
}

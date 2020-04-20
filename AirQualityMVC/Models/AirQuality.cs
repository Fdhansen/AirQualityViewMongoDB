using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQualityMVC.Models
{
    public class AirQuality
    {
        public ObjectId Id { get; set; }
        public DateTime DatoMaerke { get; set; }
        public double ProduktId { get; set; }
        public string Kode { get; set; }
        public string Navn { get; set; }
        public double RaaResultat { get; set; }
        public string StofNavn { get; set; }
        public string Expr1 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using MongoDB.Driver;

namespace AirQualityViewMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            AirQualityViewXML();
            Console.ReadKey();
        }

        public class AirQualityViewData
        {
            public DateTime DatoMaerke { get; set; }
            public double ProduktId { get; set; }
            public string Kode { get; set; }
            public string Navn { get; set; }
            public double RaaResultat { get; set; }
            public string StofNavn { get; set; }
            public string Expr1 { get; set; }

            public override string ToString()
            {
                return $"DatoMaerke: {DatoMaerke}, ProduktId: {ProduktId}, Kode: {Kode}, Navn: {Navn}, RaaResultat: {RaaResultat}, StofNavn: {StofNavn}, Expr1: {Expr1}";
            }
        }

        public class AirQualityContext
        {
            protected static IMongoDatabase mongoDB;

            public AirQualityContext()
            {
                var mongoclient = new MongoClient();
                mongoDB = mongoclient.GetDatabase("AirQualityViewMongoDB");
            }

            public IMongoCollection<AirQualityViewData> AirQualityViewCollection =>
                mongoDB.GetCollection<AirQualityViewData>("AirQualityViewCollection");
        }

        private static void AirQualityViewXML()
        {
            AirQualityContext ctx = new AirQualityContext();
            AirQualityViewData AirQualityData = new AirQualityViewData();

            XmlReader ViewReader = XmlReader.Create("C:/Users/fdh_0/Documents/DataBase/AirQualityData/AirQualityView.xml");

            while (ViewReader.Read())
            {
                if (ViewReader.NodeType == XmlNodeType.Element)
                {
                    if (ViewReader.Name == "DatoMaerke")
                    {
                        AirQualityData.DatoMaerke = ViewReader.ReadElementContentAsDateTime();
                    }

                    if (ViewReader.Name == "ProduktId")
                    {
                        AirQualityData.ProduktId = ViewReader.ReadElementContentAsDouble();
                    }

                    if (ViewReader.Name == "Kode")
                    {
                        AirQualityData.Kode = ViewReader.ReadElementContentAsString();
                    }

                    if (ViewReader.Name == "Navn")
                    {
                        AirQualityData.Navn = ViewReader.ReadElementContentAsString();
                    }

                    if (ViewReader.Name == "RaaResultat")
                    {
                        AirQualityData.RaaResultat = ViewReader.ReadElementContentAsDouble();
                    }

                    if (ViewReader.Name == "StofNavn")
                    {
                        AirQualityData.StofNavn = ViewReader.ReadElementContentAsString();
                    }

                    if (ViewReader.Name == "Expr1")
                    {
                        AirQualityData.Expr1 = ViewReader.ReadElementContentAsString();
                        ctx.AirQualityViewCollection.InsertOne(AirQualityData);
                        Thread.Sleep(200);
                    }
                }
            }
        }
    }
}

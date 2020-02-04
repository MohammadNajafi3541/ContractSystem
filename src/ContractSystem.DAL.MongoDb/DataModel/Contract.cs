using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContractSystem.DAL.MongoDb.DataModel
{
   public class Contract
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string BrokerAgentName { get; set; }
        public string BrokerCompanyName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; }   

    }
      
}

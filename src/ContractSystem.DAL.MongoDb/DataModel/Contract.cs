using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContractSystem.DAL.MongoDb.DataModel
{
    /// <summary>
    /// this is contract class that is in the data base
    /// </summary>
   public class Contract
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        [BsonRequired]
        public string BrokerAgentName { get; set; }
        [BsonRequired]
        public string BrokerCompanyName { get; set; }
        [BsonRequired]
        public decimal TotalPrice { get; set; }
        [BsonRequired]
        [BsonDateTimeOptions]
        public DateTime  StartDate { get; set; }
        [BsonRequired]
        [BsonDateTimeOptions]
        public DateTime EndDate { get; set; }   

    }
      
}

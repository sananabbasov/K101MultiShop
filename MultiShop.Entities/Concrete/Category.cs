using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Entities.Concrete
{
    [BsonCollection("categories")]
    public class Category : IEntity
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<CategoryLanguage> CategoryLanguages { get; set; }
        public string PhotoUrl { get; set; }
    }
}


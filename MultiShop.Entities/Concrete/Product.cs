using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Entities.Concrete
{
	[BsonCollection("products")]
	public class Product : IEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public List<ProductLanguage> ProductLanguages { get; set; }
		public List<string> PhotoUrl { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Discount { get; set; }
		public DateTime DiscountEndDate { get; set; }
        public List<string> Categories { get; set; }
		//public List<Specification> Specifications { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
	}
}


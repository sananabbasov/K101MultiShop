﻿using System;
namespace MultiShop.Core.DataAccess.MongoDb.MongoSettings
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class BsonCollectionAttribute : Attribute
	{
		public BsonCollectionAttribute(string collectionName)
		{
			CollectionName = collectionName;
		}

		public string CollectionName { get; set; }
	}
}

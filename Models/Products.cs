using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InventoryControl.Models
{
	public class Products
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public string Category { get; set; }

	}
}


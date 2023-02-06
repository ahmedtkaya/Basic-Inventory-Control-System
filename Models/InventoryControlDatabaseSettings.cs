using System;
namespace InventoryControl.Models
{
	public class InventoryControlDatabaseSettings
	{
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ProductsCollectionName { get; set; } = null!;

        public string CategoryCollectionName { get; set; } = null!;
    }
}


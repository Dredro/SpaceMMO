using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;

namespace Data
{
    public class MockDbContext : DbContext
    {
        public List<InventoryEntity> Inventories { get; set; } = new();
        public List<PlayerStatsEntity> StatsList { get; set; } = new();
        public List<PlayerEntity> Players { get; set; } = new();
        public List<ItemEntity> Items { get; set; } = new();

        public MockDbContext()
        {
            Mock();
        }

   
        private void Mock()
        {
            var testArmor = new ItemEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Armor"
            };

            Items.Add(testArmor);

            var inventory = new InventoryEntity
            {
                Id = Guid.NewGuid().ToString()
            };
            inventory.Items.Add(testArmor.Id);
            
            var player = new PlayerEntity
            {
                Id = "0",
                Inventory = inventory.Id
            };
            
            
            inventory.PlayerId = "0";
            
            Players.Add(player);
            var stats = new PlayerStatsEntity
            {
                Id = "0",
                Health = 100,
                Energy = 100
            };
            StatsList.Add(stats);
           
            Inventories.Add(inventory);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Entities;

public class GameRepository : IGameRepository
{
    public DbContext DataStorage { get; set; } = new MockDbContext();

    public Inventory GetInventory(string id)
    {
        var inventoryData = DataStorage.Inventories.FirstOrDefault(i => i.PlayerId == id);
        if (inventoryData == null) return new Inventory();

        var items = inventoryData.Items
            .Select(itemId => DataStorage.Items.FirstOrDefault(i => i.Id == itemId))
            .Where(itemData => itemData != null)
            .Select(itemData => new BaseArmor
            {
                id = itemData.Id,
                name = itemData.Name
            }).ToList<Item>();

        return new Inventory
        {
            id = inventoryData.Id,
            items = items
        };
    }

    public Stats GetStats(string id)
    {
        var statsData = DataStorage.StatsList.First(s=>s.Id == id);

        return new Stats
        {
            id = statsData.Id,
            Health = statsData.Health,
            Energy = statsData.Energy
        };
    }

    public PlayerEntity GetPlayer()
    {
        return DataStorage.Players.First();
    }

    public void UpdateInventory(string id)
    {
       
    }
}
using System.Collections.Generic;
using Data.Entities;

public interface DbContext
{
    public List<InventoryEntity> Inventories { get; set; }
    public List<PlayerStatsEntity> StatsList { get; set; }
    public List<PlayerEntity> Players { get; set; }
    public List<ItemEntity> Items { get;  set; } 
}
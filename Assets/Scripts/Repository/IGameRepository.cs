using System;
using System.Data;
using Data.Entities;
using UnityEditor;

public interface IGameRepository
{
    public DbContext DataStorage{ get; set; }

    public Inventory GetInventory(string id);
    public void UpdateInventory(string id);

    public Stats GetStats(string id);
    PlayerEntity GetPlayer(); // MOCK
}
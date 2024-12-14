using System;
using UnityEditor;

public class InventoryController
{
    private static InventoryController? _instance;
    private IGameRepository _repository;

    private InventoryController()
    {
        _repository = new GameRepository();
    }
    public static InventoryController GetInstance()
    {
        _instance ??= new InventoryController();
        return _instance;
    }
    public Inventory GetInventory(string id)
    {
        return  _repository.GetInventory(id);
    }

    public void UpdateInventory(string id)
    {
       
    }
}
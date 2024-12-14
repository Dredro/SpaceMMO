
using System;
using UnityEditor;

public class StatsController
{
    private static StatsController? _instance;
    private IGameRepository _repository;

    private StatsController()
    {
        _repository = new GameRepository();
    }
    public static StatsController GetInstance()
    {
        _instance ??= new StatsController();
        return _instance;
    }

    public Stats GetStats(string id)
    {
       return _repository.GetStats(id);
    }
}

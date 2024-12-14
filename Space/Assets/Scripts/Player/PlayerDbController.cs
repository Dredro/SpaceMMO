using System;
using Data.Entities;

    public class PlayerDbController{
        
        private static PlayerDbController? _instance;
        private IGameRepository _repository;

        private PlayerDbController()
        {
            _repository = new GameRepository();
        }
        public static PlayerDbController GetInstance()
        {
            _instance ??= new PlayerDbController();
            return _instance;
        }

        public string GetPlayer()
        {
            return _repository.GetPlayer().Id;
        }
    }
using Source.Scripts.GameBase;
using Source.Scripts.Infrastructure.Common;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.SO;

namespace Source.Scripts.Infrastructure.Pools
{
    public class Pool : IPools
    {
        public PoolEnemies Enemies { get; set; }
        public PoolHeroes Heroes { get; set; }
        
        public Pool(GameConfig config, IGameFactory gameFactory, GameModule gameModule, DataManager dataManager)
        {
            Enemies = new PoolEnemies(config, gameFactory, gameModule, dataManager);
            Heroes = new PoolHeroes(config, gameFactory);
        }
    }
}
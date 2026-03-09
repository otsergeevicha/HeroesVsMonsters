using Source.Scripts.GameBase;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.SO;

namespace Source.Scripts.Infrastructure.Pools
{
    public class Pool : IPools
    {
        public PoolEnemies Enemies { get; set; }
        public PoolHeroes Heroes { get; set; }
        
        public Pool(GameConfig config, IGameFactory gameFactory, GameModule gameModule)
        {
            Enemies = new PoolEnemies(config, gameFactory, gameModule);
            Heroes = new PoolHeroes(config, gameFactory);
        }
    }
}
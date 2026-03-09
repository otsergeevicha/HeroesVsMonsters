using Source.Scripts.Infrastructure.Pools;

namespace Source.Scripts.Infrastructure.Interfaces
{
    public interface IPools
    {
        PoolEnemies Enemies { get; set; }
        PoolHeroes Heroes { get; set; }
    }
}
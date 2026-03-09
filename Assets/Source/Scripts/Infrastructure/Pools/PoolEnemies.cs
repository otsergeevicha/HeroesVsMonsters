using System.Collections.Generic;
using Source.Scripts.Enemies;
using Source.Scripts.GameBase;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.SO;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Pools
{
    public class PoolEnemies
    {
        private readonly List<Enemy> _enemies = new ();

        public PoolEnemies(GameConfig config, IGameFactory gameFactory, GameModule gameModule)
        {
            if (config.Enemies.SpawnAmount == 0)
            {
                Debug.Log("No enemies to spawn");
                return;
            }
            
            for (int i = 0; i < config.Enemies.SpawnAmount; i++)
            {
                Enemy enemy = gameFactory.CreateEnemy(config.Enemies.LinkPrefab);
                enemy.Construct(gameModule.TargetForEnemy);
                enemy.InActive();
                _enemies.Add(enemy);
            }
        }
    }
}
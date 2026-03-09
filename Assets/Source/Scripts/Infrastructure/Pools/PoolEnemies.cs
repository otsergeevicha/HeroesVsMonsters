using System.Collections.Generic;
using System.Linq;
using Assets.FantasyMonsters.Common.Scripts;
using Source.Scripts.Enemies;
using Source.Scripts.GameBase;
using Source.Scripts.Infrastructure.Common;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.SO;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Pools
{
    public class PoolEnemies
    {
        private readonly List<Enemy> _enemies = new ();

        public PoolEnemies(GameConfig config, IGameFactory gameFactory, GameModule gameModule, DataManager dataManager)
        {
            if (config.Enemies.SpawnAmount == 0)
            {
                Debug.Log("No enemies to spawn");
                return;
            }
            
            LevelSetting level = config.Balance.Levels.FirstOrDefault(item => 
                item.Level == dataManager.ReactCurrentLevel.Value);

            if (level == null)
            {
                Debug.Log("Level setting not found for current level");
                return;
            }
            
            for (int i = 0; i < config.Enemies.SpawnAmount; i++)
            {
                Enemy enemy = gameFactory.CreateEnemy(config.Enemies.LinkPrefab);
                enemy.Construct(gameModule.SpawnPoints);
                enemy.InActive();
                
                foreach (MonsterSettingConfig entity in level.Monsters)
                {
                    Monster monster = gameFactory.CreateMonster(entity.MonsterPrefab, enemy.transform);
                    monster.gameObject.SetActive(false);
                    enemy.AddMonster(monster);
                }
                
                _enemies.Add(enemy);
            }
        }
        
        public Enemy TryGetEnemy() => 
            _enemies.FirstOrDefault(enemy => !enemy.gameObject.activeInHierarchy);
    }
}
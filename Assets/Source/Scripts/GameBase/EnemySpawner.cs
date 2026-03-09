using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using Source.Scripts.Enemies;
using Source.Scripts.Infrastructure.Common;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.SO;
using UnityEngine;

namespace Source.Scripts.GameBase
{
    public class EnemySpawner : MonoBehaviour
    {
        private Coroutine _spawnRoutine;
        private IPools _pools;
        private GameConfig _gameConfig;
        private DataManager _dataManager;
        private GameModule _gameModule;

        [Inject]
        private void Construct(IPools pools, GameConfig gameConfig, DataManager dataManager, GameModule gameModule)
        {
            _gameModule = gameModule;
            _dataManager = dataManager;
            _gameConfig = gameConfig;
            _pools = pools;
        }
        
        private void Start()
        {
            LevelSetting levelSetting = _gameConfig.Balance.Levels.FirstOrDefault(item => 
                item.Level == _dataManager.ReactCurrentLevel.Value);

            if (levelSetting == null)
            {
                Debug.Log("Level empty");
                return;
            }

            _spawnRoutine = StartCoroutine(SpawnWaves(levelSetting.Waves));
        }

        private void StopSpawnRoutine()
        {
            if (_spawnRoutine == null)
                return;

            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }

        private IEnumerator SpawnWaves(List<WaveSetting> waves)
        {
            for (var i = 0; i < waves.Count; i++)
                yield return SpawnWave(waves[i]);
        }

        private IEnumerator SpawnWave(WaveSetting wave)
        {
            if (wave == null)
                yield break;

            int maxQuantity = Mathf.Max(0, wave.MaxQuantity);
            float spawnInterval = Mathf.Max(0f, wave.SpawnInterval);
            float totalSpawnTime = 0f;

            for (var i = 0; i < maxQuantity; i++)
            {
                TrySpawnEnemy();
                totalSpawnTime += spawnInterval;
                yield return new WaitForSeconds(spawnInterval);
            }

            float remainingWaveTime = Mathf.Max(0f, wave.Duration - totalSpawnTime);
            
            if (remainingWaveTime > Mathf.Epsilon)
                yield return new WaitForSeconds(remainingWaveTime);
        }

        private void TrySpawnEnemy()
        {
            Enemy enemy = _pools?.Enemies?.TryGetEnemy();

            if (!enemy)
            {
                Debug.Log("Enemy pool returned no inactive enemy to spawn.");
                return;
            }

            if (!_gameModule || !_gameModule.TargetForEnemy)
            {
                Debug.Log($"EnemySpawner has no target assigned. [{_gameModule.TargetForEnemy}]");
                return;
            }
            
            enemy.SetTarget(_gameModule.TargetForEnemy);
            enemy.OnActive();
        }

        private void OnDestroy() => 
            StopSpawnRoutine();
    }
}

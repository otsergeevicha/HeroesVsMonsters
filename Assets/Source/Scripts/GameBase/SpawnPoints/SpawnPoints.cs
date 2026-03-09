using System;
using Source.Scripts.Infrastructure.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts.GameBase.SpawnPoints
{
    [Serializable]
    public class SpawnPoints
    {
        [SerializeField] private Transform[] _flyingSpawnPoints;
        [SerializeField] private Transform[] _comingSpawnPoints;
        [SerializeField] private Transform[] _crawlingSpawnPoints;

        public Vector3 GetRandomPosition(TypeEnemyMovement typeEnemyMovement)
        {
            switch (typeEnemyMovement)
            {
                case TypeEnemyMovement.Flying:
                    return TryGetPosition(_flyingSpawnPoints);
                case TypeEnemyMovement.Coming:
                    return TryGetPosition(_comingSpawnPoints);
                case TypeEnemyMovement.Crawling:
                    return TryGetPosition(_crawlingSpawnPoints);
                default:
                    Debug.Log($"No {nameof(typeEnemyMovement)}");
                    return Vector3.zero;
            }
        }

        private Vector3 TryGetPosition(Transform[] currentArray)
        {
            if (currentArray == null || currentArray.Length == 0)
            {
                Debug.Log($"No {currentArray} spawn points available");
                return Vector3.zero;
            }
            
            return currentArray[Random.Range(0, currentArray.Length)]
                .position;
        }
    }
}
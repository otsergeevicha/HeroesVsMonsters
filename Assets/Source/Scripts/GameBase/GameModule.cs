using UnityEngine;

namespace Source.Scripts.GameBase
{
    public class GameModule : MonoBehaviour
    {
        [SerializeField] private Transform _targetForEnemy;
        [Space] [Header("Spawn points holder for enemies")]
        [SerializeField] private SpawnPoints.SpawnPoints _spawnPoints;
        
        public Transform TargetForEnemy => 
            _targetForEnemy;

        public SpawnPoints.SpawnPoints SpawnPoints =>
            _spawnPoints;
    }
}
using System;
using System.Collections.Generic;
using Assets.FantasyMonsters.Common.Scripts;
using Source.Scripts.GameBase.SpawnPoints;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts.Enemies
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [HideInInspector] [SerializeField] private BoxCollider2D _boxCollider2D;
        private readonly List<Monster> _monsters = new ();
        
        protected Transform CurrentTarget;
        private SpawnPoints _spawnPoints;
        private Monster CurrentMonster { get; set; }

        public void Construct(SpawnPoints spawnPoints) => 
            _spawnPoints = spawnPoints;

        private void OnValidate() => 
            _boxCollider2D ??= GetComponent<BoxCollider2D>();

        public void OnActive()
        {
            CurrentMonster = GetRandomMonster();
            transform.position = _spawnPoints.GetRandomPosition(CurrentMonster.Type);
            CurrentMonster.gameObject.SetActive(true);
            gameObject.SetActive(true);
            UpdateCollider();
            _enemyMovement.StartMovement();
        }

        public void InActive()
        {
            _enemyMovement.StopMovement();
            CurrentMonster?.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void UpdateCollider()
        {
            CapsuleCollider2D collider2D = CurrentMonster.gameObject.GetComponent<CapsuleCollider2D>();

            if (!collider2D)
            {
                Debug.Log("Current monster does not have a CapsuleCollider2D component");
                return;
            }
            
            _boxCollider2D.size = collider2D.size;
            _boxCollider2D.offset = collider2D.offset;
        }

        public void SetTarget(Transform target) => 
            CurrentTarget = target;

        public void AddMonster(Monster monster) => 
            _monsters.Add(monster);

        private Monster GetRandomMonster() => 
            _monsters[Random.Range(0, _monsters.Count)];

        private void OnDestroy()
        {
            foreach (var monster in _monsters) 
                Destroy(monster.gameObject);
        }
    }
}
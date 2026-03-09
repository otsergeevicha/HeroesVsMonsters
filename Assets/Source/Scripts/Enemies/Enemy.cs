using Assets.FantasyMonsters.Common.Scripts;
using Source.Scripts.Infrastructure.Enums;
using UnityEngine;

namespace Source.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private TypeEnemyMovement _typeEnemyMovement;
        
        protected Transform CurrentTarget;
        protected Monster CurrentMonster;

        public void Construct(Transform target) => 
            CurrentTarget = target;

        public void SetEnemy(Monster newMonster) =>
            CurrentMonster = newMonster;
        
        public virtual void OnActive()
        {
            gameObject.SetActive(true);
        }

        public virtual void InActive()
        {
            gameObject.SetActive(false);
        }
    }
}
using System;
using System.Collections.Generic;
using Assets.FantasyMonsters.Common.Scripts;
using UnityEngine;

namespace Source.Scripts.Infrastructure.SO
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public SettingEnemies Enemies;
        public SettingHeroes Heroes;
        [Space] [Header("Balance")]
        public BalanceConfig Balance;
        
        [Serializable]
        public class SettingEnemies
        {
            public int SpawnAmount;
            public GameObject LinkPrefab;
        }
        
        [Serializable]
        public class SettingHeroes
        {
            public List<SettingHeroEntity> Entities;
            
            [Serializable]
            public class SettingHeroEntity
            {
                public GameObject LinkPrefab;
            }
        }
    }
}
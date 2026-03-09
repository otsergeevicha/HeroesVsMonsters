using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Infrastructure.SO
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public SettingEnemies Enemies;
        public SettingHeroes Heroes;

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
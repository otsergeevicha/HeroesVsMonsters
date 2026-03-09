using System;
using System.Collections.Generic;
using Source.Scripts.Infrastructure.Enums;
using UnityEngine;

namespace Source.Scripts.Infrastructure.SO
{
    [CreateAssetMenu(fileName = "BalanceConfig", menuName = "Game/BalanceConfig")]
    public class BalanceConfig : ScriptableObject
    {
        public List<LevelSetting> Levels;
    }
    
    [Serializable]
    public class LevelSetting
    {
        public TypeLevel Level;
        [Space] [Header("Какие будут монстры на уровне")] public MonsterSettingConfig[] Monsters;
        [Space] [Header("Настройка волн на уровне")] public List<WaveSetting> Waves;
    }

    [Serializable]
    public class MonsterSettingConfig
    {
        public GameObject MonsterPrefab;
        [Space] [Header("Параметры монстра на уроне")]
        public MonsterParameter MonsterParameter;
    }

    [Serializable]
    public class MonsterParameter
    {
        public float BaseDamage = 10f;
        public int MaxHealth = 30;
        public float BaseSpeed = 5f;
        [Space] [Range(0, 1)] public float CriticalChance = .5f;
        public float MultiplierCritical = 2.5f;
    }

    [Serializable]
    public class WaveSetting
    {
        public int Duration = 30;
        public float SpawnInterval = 1f;
        public int MaxQuantity = 15;
    }
}
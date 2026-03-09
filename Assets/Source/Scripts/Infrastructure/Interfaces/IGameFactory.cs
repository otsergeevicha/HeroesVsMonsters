using Assets.FantasyMonsters.Common.Scripts;
using Source.Scripts.Enemies;
using Source.Scripts.HeroBase;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Interfaces
{
    public interface IGameFactory
    {
        Enemy CreateEnemy(GameObject prefabLinkEnemy);
        Hero CreateHero(GameObject linkPrefab);
        Monster CreateMonster(GameObject entityMonsterPrefab, Transform parent);
    }
}
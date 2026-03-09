using Source.Scripts.Enemies;
using Source.Scripts.HeroBase;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Interfaces
{
    public interface IGameFactory
    {
        Enemy CreateEnemy(GameObject prefabLinkEnemy);
        Hero CreateHero(GameObject linkPrefab);
    }
}
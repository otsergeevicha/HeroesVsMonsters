using Source.Scripts.Enemies;
using Source.Scripts.HeroBase;
using Source.Scripts.Infrastructure.Interfaces;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider = new AssetProvider();

        public Enemy CreateEnemy(GameObject prefabLinkEnemy) => 
            _assetProvider.InstantiateEntity(prefabLinkEnemy)
                .GetComponent<Enemy>();

        public Hero CreateHero(GameObject linkPrefab) =>
            _assetProvider.InstantiateEntity(linkPrefab)
                .GetComponent<Hero>();
    }
}
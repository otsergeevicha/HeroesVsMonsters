using Source.Scripts.Infrastructure.Interfaces;

namespace Source.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider = new AssetProvider();

        // public Enemy CreateEnemy(GameObject prefabLinkEnemy) => 
        //     _assetProvider.InstantiateEntity(prefabLinkEnemy)
        //         .GetComponent<Enemy>();
    }
}
using Source.Scripts.Infrastructure.Interfaces;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Factory
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject InstantiateEntity(string path, Transform holder)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, holder);
        }
        
        public GameObject InstantiateEntity(GameObject prefabObj, Transform holder) => 
            Object.Instantiate(prefabObj, holder);
    }
}
using UnityEngine;

namespace Source.Scripts.Infrastructure.Interfaces
{
    public interface IAssetProvider
    {
        GameObject InstantiateEntity(string path, Transform holder = null);
        GameObject InstantiateEntity(GameObject prefabObj, Transform holder = null);
    }
}
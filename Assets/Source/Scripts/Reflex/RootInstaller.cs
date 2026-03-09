using Reflex.Core;
using Source.Scripts.Infrastructure.Common;
using Source.Scripts.Infrastructure.SO;
using UnityEngine;

namespace Source.Scripts.Reflex
{
    public class RootInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private DataManager _dataManager;
        [SerializeField] private GameConfig _config;
        
        public void InstallBindings(ContainerBuilder container)
        {
            container.RegisterValue(_dataManager);
            container.RegisterValue(_config);
        }
    }
}
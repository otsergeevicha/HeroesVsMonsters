using Reflex.Core;
using Reflex.Enums;
using Source.Scripts.GameBase;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Infrastructure.Interfaces;
using Source.Scripts.Infrastructure.Pools;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Source.Scripts.Reflex
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameModule _gameModule;

        public void InstallBindings(ContainerBuilder container)
        {
            container.RegisterType(typeof(GameFactory), new[] { typeof(IGameFactory) }, Lifetime.Scoped, Resolution.Eager);
            container.RegisterType(typeof(Pool), new[] {typeof(IPools)}, Lifetime.Scoped, Resolution.Eager);
            container.RegisterValue(_gameModule);
        }
    }
}
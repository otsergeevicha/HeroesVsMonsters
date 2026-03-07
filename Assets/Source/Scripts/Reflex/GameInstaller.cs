using Reflex.Core;
using UnityEngine;

namespace Source.Scripts.Reflex
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder container)
        {
            //container.RegisterValue("World");
        }
    }
}
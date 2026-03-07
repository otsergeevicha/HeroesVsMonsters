using Reflex.Core;
using UnityEngine;

namespace Source.Scripts.Reflex
{
    public class RootInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder container)
        {
            //container.RegisterValue("Hello"); // Note that values are always registered as singletons
        }
    }
}
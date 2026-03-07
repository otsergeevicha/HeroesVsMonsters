using Source.Scripts.Infrastructure.Interfaces;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Inputs
{
    public class InputService : MonoBehaviour, IInputService
    {
        private InputSystem_Actions _map = new InputSystem_Actions();
    }
}
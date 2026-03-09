using R3;
using Source.Scripts.Infrastructure.Enums;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Common
{
    public class DataManager : MonoBehaviour
    {
        public readonly ReactiveProperty<TypeLevel> ReactCurrentLevel = new (TypeLevel.One);
    }
}
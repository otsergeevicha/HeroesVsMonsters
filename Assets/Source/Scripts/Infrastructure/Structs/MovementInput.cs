using Source.Scripts.Infrastructure.Enums;
using UnityEngine;

namespace Source.Scripts.Infrastructure.Structs
{
    public readonly struct MovementInput
    {
        public MovementInputType Type { get; }
        public Vector2 Value { get; } // если Direction -> нормализованный вектор; если Point -> мировая позиция
        public Vector2 ScreenPosition { get; } // экранная позиция для кликов/тапов


        public MovementInput(MovementInputType type, Vector2 value, Vector2 screenPosition)
        {
            Type = type;
            Value = value;
            ScreenPosition = screenPosition;
        }
    }
}
using UnityEngine;

namespace Source.Scripts.Infrastructure.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(int amount, GameObject source);
    }
}
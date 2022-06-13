using System;

using UnityEngine;

namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyHealth : MonoBehaviour
    {
        public const uint MaxHealth = 3;
        public const uint MinHealth = 0;

        [SerializeField, Range(1, MaxHealth)] private uint health = 1;

        public event Action<uint> HealthChanged;
        public event Action<EnemyHealth> EnemyDied;        

        public bool IsAlive()
        {
            return health == MinHealth;
        }

        public void TakeDamage()
        {
            health--;
            HealthChanged?.Invoke(health);

            if (health == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            EnemyDied?.Invoke(this);
        }
    }
}
using System;
using System.Collections.Generic;

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

        [SerializeField] private List<EnemyHitBox> enemyHitBoxes = new List<EnemyHitBox>();

        private void Awake()
        {
            foreach(var hitBox in enemyHitBoxes)
            {
                hitBox.Hited += TakeDamage;
            }
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

            UnsubsribeFromHitBoxes();
        }

        private void UnsubsribeFromHitBoxes()
        {
            foreach (var hitBox in enemyHitBoxes)
            {
                hitBox.Hited -= TakeDamage;
            }
        }

        private void OnDestroy()
        {
            UnsubsribeFromHitBoxes();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;

        [SerializeField] private Image healthBar;

        private void Awake()
        {
            enemy.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(uint health)
        {
            UpdateBarFillAmount(health);

            if (health == 0)
                enemy.HealthChanged -= OnHealthChanged;
        }

        private void UpdateBarFillAmount(uint health)
        {
            healthBar.fillAmount = (float)health / Enemy.MaxHealth;
        }

        private void OnDestroy()
        {
            enemy.HealthChanged -= OnHealthChanged;
        }
    }
}
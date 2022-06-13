using SquareDinoTestWork.Enemies;

using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork.Plot
{
    public sealed class Waypoint : MonoBehaviour
    {
        [SerializeField] private List<EnemyHealth> enemies = new List<EnemyHealth>();

        private void Start()
        {
            foreach(var enemy in enemies)
            {
                enemy.EnemyDied += OnEnemyDied;
            }
        }

        private void OnEnemyDied(EnemyHealth enemy)
        {
            enemies.Remove(enemy);

            enemy.EnemyDied -= OnEnemyDied;
        }

        internal bool HaveEnemies()
        {
            return enemies.Count > 0;
        }

        private void OnDestroy()
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyDied -= OnEnemyDied;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}
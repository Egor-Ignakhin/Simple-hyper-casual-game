using SquareDinoTestWork.Enemies;

using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork.Plot
{
    public sealed class Waypoint : MonoBehaviour
    {
        [SerializeField] private List<Enemy> enemies = new List<Enemy>();

        private void Start()
        {
            foreach(var enemy in enemies)
            {
                enemy.EnemyDied += OnEnemyDied;
            }
        }

        private void OnEnemyDied(Enemy enemy)
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
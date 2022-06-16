using SquareDinoTestWork.Enemies;

using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork.Plot
{
    public sealed class Waypoint : MonoBehaviour
    {
        [SerializeField] private List<EnemyHealth> enemies = new List<EnemyHealth>();

        private bool playerReachedPoint;

        private void Start()
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyDied += OnEnemyDied;
            }
        }

        private void OnEnemyDied(EnemyHealth enemy)
        {
            enemies.Remove(enemy);

            enemy.EnemyDied -= OnEnemyDied;
        }

        internal void SetPlayerReachedPoint(bool v)
        {
            playerReachedPoint = v;
        }

        internal bool HaventEnemies()
        {
            return enemies.Count == 0;
        }

        internal Vector3 GetDirection()
        {
            return transform.forward;
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

        internal bool CanSkip()
        {
            return HaventEnemies() && playerReachedPoint;
        }
    }
}

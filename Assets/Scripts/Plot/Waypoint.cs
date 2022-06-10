using SquareDinoTestWork.Enemies;

using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork.Plot
{
    public sealed class Waypoint : MonoBehaviour
    {
        [SerializeField] private List<EnemyManager> enemies = new List<EnemyManager>();

        internal bool HaveEnemies()
        {
            return enemies.Count > 0;
        }
    }
}
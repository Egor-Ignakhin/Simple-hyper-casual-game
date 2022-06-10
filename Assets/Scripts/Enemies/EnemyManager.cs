using UnityEngine;

namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyManager : MonoBehaviour
    {
        private bool isAlive = true;

        public bool IsAlive()
        {
            return isAlive;
        }
    }
}
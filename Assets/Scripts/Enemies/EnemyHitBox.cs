using SquareDinoTestWork.Combat;

using UnityEngine;
namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyHitBox : MonoBehaviour, IBulletReceiver
    {
        [SerializeField] private Enemy enemyManager;

        [SerializeField] private Rigidbody mRigidbody;

        public void Hit(Bullet bullet)
        {
            enemyManager.Hit();
            AddForceToRigidbody(bullet);
        }

        private void AddForceToRigidbody(Bullet bullet)
        {
            mRigidbody.AddForce(bullet.GetDirection() * bullet.GetForce());
        }
    }
}
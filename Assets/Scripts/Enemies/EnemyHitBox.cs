using SquareDinoTestWork.Combat;

using UnityEngine;
namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyHitBox : MonoBehaviour, IBulletReceiver
    {
        [SerializeField] private EnemyHealth EnemyHealth;

        [SerializeField] private Rigidbody mRigidbody;

        public void Hit(Bullet bullet)
        {
            EnemyHealth.TakeDamage();
            AddForceToRigidbody(bullet);
        }

        private void AddForceToRigidbody(Bullet bullet)
        {
            mRigidbody.AddForce(bullet.GetDirection() * bullet.GetForce());
        }
    }
}
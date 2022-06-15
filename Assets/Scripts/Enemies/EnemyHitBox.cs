using SquareDinoTestWork.Combat;

using System;

using UnityEngine;
namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyHitBox : MonoBehaviour, IBulletReceiver
    {
        public event Action Hited;

        [SerializeField] private Rigidbody mRigidbody;

        public void Hit(Bullet bullet)
        {
            Hited?.Invoke();
            AddForceToRigidbody(bullet);
        }

        private void AddForceToRigidbody(Bullet bullet)
        {
            mRigidbody.AddForce(bullet.GetDirection() * bullet.GetForce());
        }
    }
}
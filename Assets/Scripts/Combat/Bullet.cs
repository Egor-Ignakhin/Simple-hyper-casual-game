using UnityEngine;

namespace SquareDinoTestWork.Combat
{
    public sealed class Bullet : PoolableObject
    {
        private IBulletReceiver ibulletReceiver;

        [SerializeField] private BulletMotion bulletMotion;

        [SerializeField] private uint force = 10000;

        public void Initialize(Vector3 position, Vector3 surfacePoint, IBulletReceiver bulletReceiver)
        {
            transform.position = position;
            this.ibulletReceiver = bulletReceiver;

            bulletMotion.Initialize(surfacePoint);

            bulletMotion.MoveCompleted += Hit;
        }

        private void Hit()
        {
            ibulletReceiver?.Hit(this);
            bulletMotion.MoveCompleted -= Hit;
            mPool.ReturnToPool(this);
        }

        internal Vector3 GetDirection()
        {
            return transform.forward;
        }

        internal uint GetForce()
        {
            return force;
        }
    }
}
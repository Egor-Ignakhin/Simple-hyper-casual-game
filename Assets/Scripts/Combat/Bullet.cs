using UnityEngine;

namespace SquareDinoTestWork.Combat
{
    public sealed class Bullet : PoolableObject
    {
        private IBulletReceiver bulletReceiver;

        [SerializeField] private BulletMotion bulletMotion;

        [SerializeField] private uint force = 10000;

        public void Initialize(Vector3 position, Vector3 surfacePoint, IBulletReceiver bulletReceiver)
        {
            transform.position = position;
            this.bulletReceiver = bulletReceiver;

            bulletMotion.Initialize(surfacePoint);

            bulletMotion.MoveCompleted += Hit;
        }

        private void Hit()
        {
            bulletReceiver?.Hit(this);
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
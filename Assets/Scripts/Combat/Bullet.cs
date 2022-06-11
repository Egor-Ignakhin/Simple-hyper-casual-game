
using System;

using UnityEngine;

namespace SquareDinoTestWork.Combat
{
    public sealed class Bullet : PoolableObject
    {
        private Vector3 surfacePoint;

        private IBulletReceiver bulletReceiver;

        [SerializeField, Range(0, 1)] private float bulletSpeed = 0.325f;

        [SerializeField] private uint force = 10000;

        public void SetupBullet(Vector3 position, Vector3 surfacePoint, IBulletReceiver bulletReceiver)
        {
            transform.position = position;
            this.surfacePoint = surfacePoint;
            this.bulletReceiver = bulletReceiver;

            transform.LookAt(surfacePoint);
        }     

        private void Update()
        {
            MoveBulletToSurface();

            if (CanHit())
            {
                HitSurface();
            }
        }
        
        private void MoveBulletToSurface()
        {            
            transform.position = Vector3.MoveTowards(transform.position, surfacePoint, bulletSpeed);
        }

        private bool CanHit()
        {
            return Vector3.Distance(transform.position, surfacePoint) < 0.2f;
        }

        private void HitSurface()
        {
            bulletReceiver?.Hit(this);
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
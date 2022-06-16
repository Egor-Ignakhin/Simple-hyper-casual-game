using System;

using UnityEngine;

namespace SquareDinoTestWork.Combat
{
    public sealed class BulletMotion : MonoBehaviour
    {
        public event Action MoveCompleted;

        private Vector3 target;

        [SerializeField, Range(0, 1)] private float bulletSpeed = 0.325f;

        public void Initialize(Vector3 target)
        {
            this.target = target;

            transform.LookAt(target);
        }

        private void Update()
        {
            Move();

            if (CanHit())
            {
                MoveCompleted?.Invoke();
            }
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed);
        }

        private bool CanHit()
        {
            return Vector3.Distance(transform.position, target) < 0.2f;
        }
    }
}
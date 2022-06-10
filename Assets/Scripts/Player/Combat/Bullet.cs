using System;

using UnityEngine;

namespace SquareDinoTestWork.Player.Combat
{
    public sealed class Bullet : MonoBehaviour
    {
        private Vector3 endPoint;

        internal void Setup(Vector3 position, Vector3 endPoint)
        {
            transform.position = position;
            this.endPoint = endPoint;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, 1);
        }
    }
}
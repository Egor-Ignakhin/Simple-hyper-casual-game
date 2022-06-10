
using System;

using UnityEngine;

namespace SquareDinoTestWork.Player.Combat
{
    public sealed class PlayerCombatManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform bulletInstantiatePlace;

        [SerializeField] private Transform bulletsParent;

        public void Shoot()
        {
            var ballet = CreateBullet();
            Ray ray = mainCamera.ViewportPointToRay(bulletInstantiatePlace.position);
            Vector3 bulletEndPoint;

            if (Physics.Raycast(ray, out RaycastHit hit, 100, ~0,
                QueryTriggerInteraction.Ignore))
            {
                bulletEndPoint = hit.point;
            }
            else
            {
                bulletEndPoint = ray.GetPoint(100);
            }

            ballet.Setup(bulletInstantiatePlace.position, bulletEndPoint);
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(Resources.Load<Bullet>("BulletInstance"), bulletsParent);

            return bullet;
        }
    }
}
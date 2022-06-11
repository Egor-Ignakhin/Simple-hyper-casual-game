using SquareDinoTestWork.Combat;

using UnityEngine;

namespace SquareDinoTestWork.Player.Combat
{
    public sealed class PlayerCombatManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Transform bulletInstantiatePlace;

        [SerializeField] private BulletsPool bulletsPool;

        private void Awake()
        {
            bulletsPool.Initialize();
        }

        public void Shoot()
        {
            Bullet ballet = (Bullet)bulletsPool.GetObjectFromPool();
            Vector3 bulletEndPoint;
            IBulletReceiver bulletReceiver = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = TryThrowRayCast(ray);

            if (hit.collider)
            {
                bulletEndPoint = hit.point;
                bulletReceiver = hit.transform.GetComponent<IBulletReceiver>();
            }
            else
            {
                bulletEndPoint = ray.GetPoint(100);
            }

            ballet.SetupBullet(bulletInstantiatePlace.position, bulletEndPoint, bulletReceiver);
        }

        private RaycastHit TryThrowRayCast(Ray ray)
        {
            Physics.Raycast(ray, out RaycastHit hit, 100, ~0, QueryTriggerInteraction.Ignore);

            return hit;
        }
    }
}
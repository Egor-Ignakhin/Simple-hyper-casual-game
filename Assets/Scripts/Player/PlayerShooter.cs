using SquareDinoTestWork.Combat;

using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerShooter : MonoBehaviour, IGameAction
    {
        public bool CanDo { get; set; }

        [SerializeField] private Transform bulletInstantiatePlace;

        [SerializeField] private BulletsPool bulletsPool;

        [SerializeField] private PlayerMotion playerMotion;

        [SerializeField] private PlayerInput playerInput;

        private IPlayerMotionState currentPlayerMotionState;

        private void Awake()
        {
            bulletsPool.Initialize();

            playerMotion.MotionStateChanged += OnMotionTypeChanged;
        }

        private void OnMotionTypeChanged(IPlayerMotionState playerMotionState)
        {
            currentPlayerMotionState = playerMotionState;
        }

        private void Update()
        {
            if (!CanDo)
                return;

            if (CanShoot())
            {
                Shoot();
            }
        }

        private bool CanShoot()
        {
            return (currentPlayerMotionState is IdlePlayerMotionState) &&
                playerInput.ShootButtonDown();
        }

        private void Shoot()
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

            ballet.Initialize(bulletInstantiatePlace.position, bulletEndPoint, bulletReceiver);
        }

        private RaycastHit TryThrowRayCast(Ray ray)
        {
            Physics.Raycast(ray, out RaycastHit hit, 100, ~0,
                QueryTriggerInteraction.Ignore);

            return hit;
        }

        private void OnDestroy()
        {
            playerMotion.MotionStateChanged -= OnMotionTypeChanged;
        }
    }
}
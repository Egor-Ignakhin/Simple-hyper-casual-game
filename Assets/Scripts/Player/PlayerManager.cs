using SquareDinoTestWork.Plot;

using UnityEngine;
namespace SquareDinoTestWork.Player
{
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlotManager plotManager;

        [SerializeField] private PlayerCombat playerCombatManager;

        [SerializeField] private PlayerMotion playerMotion;

        [SerializeField] private PlayerAnimator playerAnimator;

        [SerializeField] private PlayerInput playerInput;

        private void Awake()
        {
            playerMotion.MotionTypeChanged += OnPlayerMotionTypeChanged;
        }

        private void Update()
        {
            if (!plotManager.GameIsStarted())
                return;

            if (CanSkipWaypoint())
            {
                SkipWaypoint();
            }


            if (CanShoot())
            {
                playerCombatManager.Shoot();
            }
            else
            {
                playerMotion.Move();
            }
        }

        private bool CanShoot()
        {
            return playerMotion.TryStop() && plotManager.WaypointHaveEnemies() && playerInput.ShootButtonIsDown();
        }

        internal void OnPlayerMotionTypeChanged(PlayerMotionTypes playerMotionType)
        {
            switch (playerMotionType)
            {
                case PlayerMotionTypes.Run:
                    playerAnimator.SetAnimatorState(PlayerMotionTypes.Run);
                    break;

                case PlayerMotionTypes.Idle:
                    playerAnimator.SetAnimatorState(PlayerMotionTypes.Idle);
                    break;
            }

            Vector3 agentDirection = playerMotion.AgentIsStopped() ? GetWaypointDirection().normalized :
                      playerMotion.GetAgentSteerengTargetDirection();
            playerMotion.SetupDirection(agentDirection);
        }

        internal Vector3 GetWaypointDirection()
        {
            return plotManager.GetWaypointDirection().normalized;
        }

        private bool CanSkipWaypoint()
        {
            return (!plotManager.WaypointHaveEnemies()) && playerMotion.TryStop();
        }

        private void SkipWaypoint()
        {
            plotManager.SkipWaypoint();

            Vector3 agentTarget = plotManager.GetWaypointPosition();
            playerMotion.SetupAgentDestination(agentTarget);
        }

        private void OnDestroy()
        {
            playerMotion.MotionTypeChanged -= OnPlayerMotionTypeChanged;
        }
    }
}
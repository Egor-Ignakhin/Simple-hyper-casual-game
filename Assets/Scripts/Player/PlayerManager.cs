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

        internal void OnAgentStop()
        {
            playerAnimator.SetAnimatorState(PlayerAnimatorStates.Idle);
        }

        internal void OnAgentRun()
        {
            playerAnimator.SetAnimatorState(PlayerAnimatorStates.Run);
        }

        internal Vector3 GetWaypointDirection()
        {
            return plotManager.GetWaypointDirection().normalized;
        }

        internal Vector3 GetWaypointPosition()
        {
            return plotManager.GetWaypointPosition();
        }

        private bool CanSkipWaypoint()
        {
            return (!plotManager.WaypointHaveEnemies()) && playerMotion.TryStop();
        }

        private void SkipWaypoint()
        {
            plotManager.SkipWaypoint();
            playerMotion.SetupWaypoint();
        }
    }
}
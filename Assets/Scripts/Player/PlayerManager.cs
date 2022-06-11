using SquareDinoTestWork.Player.Combat;
using SquareDinoTestWork.Plot;

using System;

using UnityEngine;
namespace SquareDinoTestWork.Player
{
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlotManager plotManager;

        [SerializeField] private PlayerCombatManager playerCombatManager;

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
            return playerMotion.CanStop() && plotManager.WaypointHaveEnemies() && playerInput.ShootButtonIsDown();
        }

        internal void OnAgentStop()
        {
            playerAnimator.SetAnimatorState(PlayerAnimatorStates.Idle);
        }

        internal void OnAgentRun()
        {
            playerAnimator.SetAnimatorState(PlayerAnimatorStates.Run);
        }

        private bool CanSkipWaypoint()
        {
            return (!plotManager.WaypointHaveEnemies()) && playerMotion.CanStop();
        }

        private void SkipWaypoint()
        {
            plotManager.SkipWaypoint();
            playerMotion.SetupWaypoint();
        }
    }
}
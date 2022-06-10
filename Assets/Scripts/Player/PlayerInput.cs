using SquareDinoTestWork.Player.Combat;
using SquareDinoTestWork.Plot;

using UnityEngine;
namespace SquareDinoTestWork.Player
{
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlotManager plotManager;

        [SerializeField] private PlayerCombatManager playerCombatManager;

        [SerializeField] private PlayerMotion playerMotion;

        private bool canMoving = true;

        private void Awake()
        {
            plotManager.WaypointSkipped += OnWaypointSkipped;
        }

        private void OnWaypointSkipped()
        {
            canMoving = false;
        }

        private void Update()
        {
            if (!canMoving)
            {
                if (!playerMotion.TargetIsReached())
                {
                    canMoving = true;
                }
                if (plotManager.WaypointHaveEnemies())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        playerCombatManager.Shoot();
                    }
                }
            }
        }

        internal bool CanMoving()
        {
            return canMoving;
        }

        private void OnDestroy()
        {
            plotManager.WaypointSkipped -= OnWaypointSkipped;
        }
    }
}
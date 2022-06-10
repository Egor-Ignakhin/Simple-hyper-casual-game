using SquareDinoTestWork.Plot;

using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerMotion : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private PlotManager plotManager;

        [SerializeField] private PlayerInput playerInput;

        private void Start()
        {
            SetupFirstWaypoint();
        }

        private void SetupFirstWaypoint()
        {
            var firstWaypoint = plotManager.GetWaypointPosition(transform.position);
            navMeshAgent.SetDestination(firstWaypoint);
        }

        private void Update()
        {
            if (!plotManager.GameIsStarted())
                return;

            if (!playerInput.CanMoving())
            {
                navMeshAgent.Stop();
                return;
            }

            Move();
        }

        private void Move()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                plotManager.SkipWaypoint();
            }

            var nextWaypointPosition = plotManager.GetWaypointPosition(transform.position);
            navMeshAgent.SetDestination(nextWaypointPosition);
        }

        internal bool TargetIsReached()
        {
            return (2 * navMeshAgent.remainingDistance) > navMeshAgent.stoppingDistance;
        }
    }
}
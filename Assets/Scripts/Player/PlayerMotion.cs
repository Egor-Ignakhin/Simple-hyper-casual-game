using SquareDinoTestWork.Plot;

using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerMotion : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private PlotManager plotManager;

        [SerializeField] private PlayerManager playerManager;

        private void Start()
        {
            SetupWaypoint();
        }

        public void SetupWaypoint()
        {
            navMeshAgent.SetDestination(plotManager.GetWaypointPosition());
        }

        public void Move()
        {
            if (CanStop())
            {
                navMeshAgent.isStopped = true;
                playerManager.OnAgentStop();
                RotateBodyToWaypointDirection();
                return;
            }

            RotateBodyToTarget();

            navMeshAgent.isStopped = false;
            playerManager.OnAgentRun();
        }

        internal bool CanStop()
        {
            return navMeshAgent.remainingDistance <= (navMeshAgent.stoppingDistance * 5);
        }


        private void RotateBodyToWaypointDirection()
        {
            var direction = plotManager.GetWaypointDirection().normalized;

            if (direction != Vector3.zero)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), 1);
        }


        private void RotateBodyToTarget()
        {
            var direction = (navMeshAgent.steeringTarget - transform.position).normalized;
            direction.y = 0f;

            if ((navMeshAgent.steeringTarget - transform.position) != Vector3.zero)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), 1);
        }
    }
}
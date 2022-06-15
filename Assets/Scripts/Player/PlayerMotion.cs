
using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerMotion : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private PlayerManager playerManager;

        private void Start()
        {
            SetupWaypoint();
        }

        public void SetupWaypoint()
        {
            navMeshAgent.SetDestination(playerManager.GetWaypointPosition());
        }

        public void Move()
        {
            navMeshAgent.isStopped = TryStop();
            RotateBodyToTarget();

            if (navMeshAgent.isStopped)
            {
                playerManager.OnAgentStop();
            }
            else
            {
                playerManager.OnAgentRun();
            }
        }

        internal bool TryStop()
        {
            return navMeshAgent.remainingDistance <= (navMeshAgent.stoppingDistance * 5);
        }

        private void RotateBodyToTarget()
        {
            Vector3 direction = navMeshAgent.isStopped ? playerManager.GetWaypointDirection().normalized :
                (navMeshAgent.steeringTarget - transform.position).normalized;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(direction), 1);
            }
        }
    }
}
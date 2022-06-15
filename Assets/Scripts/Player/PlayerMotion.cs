
using System;

using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerMotion : MonoBehaviour
    {
        public event Action<PlayerMotionTypes> MotionTypeChanged;

        private Vector3 bodyDirection;

        [SerializeField] private NavMeshAgent navMeshAgent;

        public void SetupAgentDestination(Vector3 target)
        {
            navMeshAgent.SetDestination(target);
        }

        public void Move()
        {
            bool prevAgentIsStopped = navMeshAgent.isStopped;
            navMeshAgent.isStopped = TryStop();
            RotateBodyToTarget();

            if (prevAgentIsStopped == navMeshAgent.isStopped)
                return;

            if (navMeshAgent.isStopped)
            {
                MotionTypeChanged?.Invoke(PlayerMotionTypes.Idle);
            }
            else
            {
                MotionTypeChanged?.Invoke(PlayerMotionTypes.Run);
            }
        }

        internal bool TryStop()
        {
            return navMeshAgent.remainingDistance <= (navMeshAgent.stoppingDistance * 5);
        }

        internal bool AgentIsStopped()
        {
            return navMeshAgent.isStopped;
        }

        internal Vector3 GetAgentSteerengTargetDirection()
        {
            return navMeshAgent.steeringTarget - transform.position;
        }

        public void SetupDirection(Vector3 direction)
        {
            bodyDirection = direction;
        }

        private void RotateBodyToTarget()
        {
            if (bodyDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(bodyDirection), 1);
            }
        }
    }
}
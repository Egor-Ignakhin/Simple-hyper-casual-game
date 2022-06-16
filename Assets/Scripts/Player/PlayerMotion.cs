
using SquareDinoTestWork.Plot;

using System;

using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerMotion : MonoBehaviour, IGameAction
    {
        public event Action<PlayerMotionTypes> MotionTypeChanged;

        public bool CanDo { get; set; }

        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private WaypointsTracker waypointsTracker;

        private Waypoint currentWaypoint;

        private void Awake()
        {
            navMeshAgent.isStopped = true;
            waypointsTracker.WaypointSkipped += OnWaypointSkipped;
        }

        private void OnWaypointSkipped(Waypoint waypoint)
        {
            currentWaypoint = waypoint;
            navMeshAgent.SetDestination(currentWaypoint.transform.position);
        }

        private void Update()
        {
            if (!CanDo)
                return;

            Move();
        }

        public void Move()
        {
            bool prevAgentStoppedState = navMeshAgent.isStopped;
            navMeshAgent.isStopped = CanStop();
            RotateBodyToTarget();


            if (prevAgentStoppedState == navMeshAgent.isStopped)
                return;

            ChangeMotionType();
        }

        private void ChangeMotionType()
        {
            if (navMeshAgent.isStopped)
            {
                MotionTypeChanged?.Invoke(PlayerMotionTypes.Idle);
                currentWaypoint.SetPlayerReachedPoint(true);
            }
            else
            {
                MotionTypeChanged?.Invoke(PlayerMotionTypes.Run);
            }
        }

        private bool CanStop()
        {
            return navMeshAgent.remainingDistance <= (navMeshAgent.stoppingDistance * 5);
        }

        private void RotateBodyToTarget()
        {
            Vector3 normalizedDirection = ComputeNormalizedDirection();

            if (normalizedDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(normalizedDirection), 1);
            }
        }

        private Vector3 ComputeNormalizedDirection()
        {
            Vector3 direction = navMeshAgent.isStopped ?
                currentWaypoint.GetDirection() :
                      GetAgentSteerengTargetDirection();

            return direction.normalized;
        }

        internal Vector3 GetAgentSteerengTargetDirection()
        {
            return navMeshAgent.steeringTarget - transform.position;
        }

        private void OnDestroy()
        {
            waypointsTracker.WaypointSkipped -= OnWaypointSkipped;
        }
    }
}
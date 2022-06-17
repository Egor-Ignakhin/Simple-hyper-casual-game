
using SquareDinoTestWork.Plot;

using System;

using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerMotion : MonoBehaviour, IGameAction
    {
        public event Action<IPlayerMotionState> MotionStateChanged;

        public bool CanDo { get; set; }

        private IPlayerMotionState noneState;
        private IPlayerMotionState idleState;
        private IPlayerMotionState runState;

        private IPlayerMotionState state;

        [SerializeField] private NavMeshAgent navMeshAgent;

        [SerializeField] private WaypointsTracker waypointsTracker;

        private Waypoint currentWaypoint;

        private void Awake()
        {
            navMeshAgent.isStopped = true;
            waypointsTracker.WaypointSkipped += OnWaypointSkipped;

            noneState = new NonePlayerMotionState(this);
            idleState = new IdlePlayerMotionState(this);
            runState = new RunPlayerMotionState(this);

            state = noneState;
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
                SetState(idleState);
                currentWaypoint.SetPlayerReachedPoint(true);
            }
            else
            {
                SetState(runState);
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

        public void Run()
        {
            state.SetRun();
        }

        public void Idle()
        {
            state.SetIdle();
        }

        public void SetState(IPlayerMotionState state)
        {
            this.state = state;
            MotionStateChanged?.Invoke(state);
        }

        public IPlayerMotionState GetIdleState()
        {
            return idleState;
        }

        public IPlayerMotionState GetRunState()
        {
            return runState;
        }

        private void OnDestroy()
        {
            waypointsTracker.WaypointSkipped -= OnWaypointSkipped;
        }
    }
}
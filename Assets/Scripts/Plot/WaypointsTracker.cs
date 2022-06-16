
using System;
using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork.Plot
{
    public sealed class WaypointsTracker : MonoBehaviour
    {
        public event Action<Waypoint> WaypointSkipped;

        private readonly Queue<Waypoint> waypointsQueue = new Queue<Waypoint>();
        [SerializeField] private Transform waypointsParent;

        private void Awake()
        {
            InitWaypointsQueue();
        }

        private void InitWaypointsQueue()
        {
            for (int i = 0; i < waypointsParent.childCount; i++)
            {
                Waypoint childWaypoint = waypointsParent.GetChild(i).GetComponent<Waypoint>();

                waypointsQueue.Enqueue(childWaypoint);
            }
        }

        private void Start()
        {
            SkipWaypoint();
        }

        private void Update()
        {
            if (CanSkipWaypoint())
            {
                SkipWaypoint();
            }
        }

        private bool CanSkipWaypoint()
        {
            if (waypointsQueue.Count > 0)
                return waypointsQueue.Peek().CanSkip();

            return true;
        }

        internal void SkipWaypoint()
        {
            if (waypointsQueue.Count == 0)
            {
                GamePlot.RestartLevel();
                return;
            }

            Waypoint waypoint = waypointsQueue.Dequeue();
            waypoint.gameObject.SetActive(false);

            if (waypointsQueue.Count == 0)
                return;

            WaypointSkipped?.Invoke(waypointsQueue.Peek());
        }
    }
}
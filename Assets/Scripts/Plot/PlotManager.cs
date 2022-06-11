using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDinoTestWork.Plot
{
    public sealed class PlotManager : MonoBehaviour
    {
        private bool gameIsStarted;

        private readonly Queue<Waypoint> waypointsQueue = new Queue<Waypoint>();
        [SerializeField] private Transform waypointsParent;

        public event Action WaypointSkipped;

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

        internal void StartGame()
        {
            gameIsStarted = true;
        }

        public bool GameIsStarted()
        {
            return gameIsStarted;
        }

        internal Vector3 GetWaypointPosition()
        {
            if (waypointsQueue.Count == 0)
            {
                return Vector3.zero;
            }

            return waypointsQueue.Peek().transform.position;
        }

        internal Vector3 GetWaypointDirection()
        {
            if (waypointsQueue.Count == 0)
            {
                return Vector3.zero;
            }

            return waypointsQueue.Peek().transform.forward;
        }

        internal void SkipWaypoint()
        {
            if (waypointsQueue.Count == 0)
            {
                RestartScene();
                return;
            }

            Waypoint waypoint = waypointsQueue.Dequeue();
            waypoint.gameObject.SetActive(false);

            WaypointSkipped?.Invoke();
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(0);
        }

        internal bool WaypointHaveEnemies()
        {
            if (waypointsQueue.Count == 0)
                return false;

            Waypoint currentWaypoint = waypointsQueue.Peek();

            return currentWaypoint.HaveEnemies();
        }
    }
}
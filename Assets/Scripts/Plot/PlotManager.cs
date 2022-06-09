using System;

using UnityEngine;

namespace SquareDinoTestWork.Plot
{
    public sealed class PlotManager : MonoBehaviour
    {
        private bool gameIsStarted;

        internal void StartGame()
        {
            gameIsStarted = true;
        }

        public bool GameIsStarted()
        {
            return gameIsStarted;
        }
    }
}
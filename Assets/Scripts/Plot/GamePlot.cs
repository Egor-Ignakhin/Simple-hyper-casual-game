using System;

using UnityEngine.SceneManagement;

namespace SquareDinoTestWork.Plot
{
    internal static class GamePlot
    {
        public static event Action LevelStarted;

        internal static void StartLevel()
        {
            LevelStarted?.Invoke();
        }

        internal static void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}
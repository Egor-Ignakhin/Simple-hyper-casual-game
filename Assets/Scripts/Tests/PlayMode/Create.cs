using SquareDinoTestWork.Enemies;
using SquareDinoTestWork.Menu;
using SquareDinoTestWork.Player.Combat;
using SquareDinoTestWork.Plot;

using UnityEngine;

namespace SquareDinoTestWork.Tests
{
    internal static class Create
    {
        internal static StartTapHandler StartTapHandler()
        {
            StartTapHandler startTapHandler = new GameObject().AddComponent<StartTapHandler>();

            return startTapHandler;
        }

        internal static PlotManager PlotManager()
        {
            PlotManager plotManager = new GameObject().AddComponent<PlotManager>();

            return plotManager;
        }

        internal static EnemyManager EnemyManager()
        {
            return new GameObject().AddComponent<EnemyManager>();
        }

        internal static PlayerCombatManager PlayerCombatManager()
        {
            return new GameObject().AddComponent<PlayerCombatManager>();
        }
    }
}
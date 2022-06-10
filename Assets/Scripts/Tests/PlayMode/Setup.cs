using SquareDinoTestWork.Enemies;
using SquareDinoTestWork.Menu;
using SquareDinoTestWork.Player.Combat;
using SquareDinoTestWork.Plot;

using System.Reflection;

using UnityEngine;

namespace SquareDinoTestWork.Tests
{
    internal static class Setup
    {
        internal static StartTapHandler StartTapHandler(PlotManager plotManager)
        {
            StartTapHandler startTapHandler = Create.StartTapHandler();

            FieldInfo tapHintFieldInfo = startTapHandler.GetType().GetField("tapHintGM",
               BindingFlags.NonPublic | BindingFlags.Instance);
            GameObject tapHintGM = new GameObject();
            tapHintFieldInfo.SetValue(startTapHandler, tapHintGM);

            FieldInfo plotManagerFieldInfo = startTapHandler.GetType().GetField("plotManager",
               BindingFlags.NonPublic | BindingFlags.Instance);
            plotManagerFieldInfo.SetValue(startTapHandler, plotManager);

            return startTapHandler;
        }

        internal static PlotManager PlotManager()
        {
            PlotManager plotManager = Create.PlotManager();

            FieldInfo waypointsParentFI = plotManager.GetType().GetField("waypointsParent",
          BindingFlags.NonPublic | BindingFlags.Instance);
            Transform waypointsParent = new GameObject().transform;
            waypointsParentFI.SetValue(plotManager, waypointsParent);

            return plotManager;
        }

        internal static EnemyManager EnemyManager()
        {
            EnemyManager enemyManager = Create.EnemyManager();

            return enemyManager;
        }

        internal static PlayerCombatManager PlayerCombatManager()
        {
            PlayerCombatManager playerCombatManager = Create.PlayerCombatManager();

            FieldInfo mainCameraFI = playerCombatManager.GetType().GetField("mainCamera",
               BindingFlags.NonPublic | BindingFlags.Instance);
            Camera mainCamera = new GameObject().AddComponent<Camera>();
            mainCameraFI.SetValue(playerCombatManager, mainCamera);

            FieldInfo bulletInstantiatePlaceFI = playerCombatManager.GetType().GetField("bulletInstantiatePlace",
               BindingFlags.NonPublic | BindingFlags.Instance);
            Transform bulletInstantiatePlace = new GameObject().transform;
            bulletInstantiatePlaceFI.SetValue(playerCombatManager, bulletInstantiatePlace);

            FieldInfo bulletsParentFI = playerCombatManager.GetType().GetField("bulletsParent",
              BindingFlags.NonPublic | BindingFlags.Instance);
            Transform bulletsParent = new GameObject().transform;
            bulletsParentFI.SetValue(playerCombatManager, bulletsParent);

            return playerCombatManager;
        }
    }
}
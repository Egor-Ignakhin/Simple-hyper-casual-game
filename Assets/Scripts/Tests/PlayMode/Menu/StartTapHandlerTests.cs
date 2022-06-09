using NUnit.Framework;

using SquareDinoTestWork.Plot;

using System.Collections;

using UnityEngine;
using UnityEngine.TestTools;

namespace SquareDinoTestWork.Menu.Tests
{
    internal sealed class StartTapHandlerTests
    {
        [UnityTest]
        public IEnumerator StartGameTest()
        {
            StartTapHandler startTapHandler = new GameObject(nameof(StartTapHandler)).AddComponent<StartTapHandler>();
            PlotManager plotManager = new GameObject(nameof(PlotManager)).AddComponent<PlotManager>();

            startTapHandler.OnPointerClick(null);

            Assert.IsTrue(plotManager.GameIsStarted());

            return null;
        }
    }
}
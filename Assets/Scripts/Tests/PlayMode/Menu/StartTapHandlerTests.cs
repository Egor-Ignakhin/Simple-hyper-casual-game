
using NUnit.Framework;

using SquareDinoTestWork.Menu;
using SquareDinoTestWork.Plot;

using System.Collections;

using UnityEngine.TestTools;

namespace SquareDinoTestWork.Tests
{
    internal sealed class StartTapHandlerTests
    {
        [UnityTest]
        public IEnumerator WhenClickingOnTap_AndGameIsNotStarted_ThenGameShouldBeStarted()
        {
            // Arrange.
            PlotManager plotManager = Setup.PlotManager();
            StartTapHandler startTapHandler = Setup.StartTapHandler(plotManager);

            // Act.
            startTapHandler.OnPointerClick(null);

            // Assert.
            Assert.AreEqual(true, new { c = plotManager.GameIsStarted() });

            return null;
        }
    }
}
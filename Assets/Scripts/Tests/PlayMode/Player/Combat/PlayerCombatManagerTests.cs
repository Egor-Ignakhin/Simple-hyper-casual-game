using NUnit.Framework;

using SquareDinoTestWork.Enemies;
using SquareDinoTestWork.Player.Combat;

using System.Collections;

using UnityEngine;
using UnityEngine.TestTools;

namespace SquareDinoTestWork.Tests
{
    internal sealed class PlayerCombatManagerTests
    {
        [UnityTest]
        public IEnumerator WhenShootingFromPlayer_AndEnemyIsAlive_ThenEnemyShouldBeDead()
        {
            // Arrange.
            EnemyManager enemy = Setup.EnemyManager();
            PlayerCombatManager playerCombatManager = Setup.PlayerCombatManager();

            // Act.
            playerCombatManager.Shoot();

            // Assert.
            Assert.IsFalse(enemy.IsAlive());

            return null;

        }
    }
}
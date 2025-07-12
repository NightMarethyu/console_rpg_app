namespace console_rpg_app.Tests
{
    public class ActionManagerTests
    {
        [Fact]
        public void GetCurrentActions_Should_ReturnOnlyPlayerQuitAction_When_PlayerIsInAnIsolatedLocation()
        {
            var (mapManager, characterManager) = new TestWorldBuilder().Build();

            var actionManager = new ActionManager(mapManager, characterManager);

            var actions = actionManager.GetCurrentActions();

            Assert.Single(actions);
            Assert.Contains("Quit", actions[0].Description);
        }

        [Fact]
        public void GetCurrentActions_Should_ReturnAttackAction_When_EnemyIsPresent()
        {
            var (mapManager, characterManager) = new TestWorldBuilder()
                .WithEnemies(1)
                .Build();

            var actionManager = new ActionManager(mapManager, characterManager);

            var actions = actionManager.GetCurrentActions();

            Assert.Contains(actions, action => action.Description.StartsWith("Attack"));
        }

        [Fact]
        public void GetCurrentActions_Should_NOT_ReturnAttackAction_When_EnemyIsDead()
        {
            var (mapManager, characterManager) = new TestWorldBuilder()
                .WithEnemies(1, false)
                .Build();

            var actionManager = new ActionManager(mapManager, characterManager);

            var actions = actionManager.GetCurrentActions();

            Assert.DoesNotContain(actions, action => action.Description.StartsWith("Attack"));
        }
    }
}

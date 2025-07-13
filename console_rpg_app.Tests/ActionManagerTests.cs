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

        [Fact]
        public void GetCurrentActions_Should_ReturnMoveActions_ForEach_LocationExit()
        {
            var (mapManager, characterManager) = new TestWorldBuilder()
                .WithExits(3)
                .Build();

            var actionManager = new ActionManager(mapManager, characterManager);

            var actions = actionManager.GetCurrentActions();

            var filteredActions = actions.Where(a => a.Description.StartsWith("Move")).ToList();

            Assert.Equal(3, filteredActions.Count);
        }

        [Fact]
        public void GetCurrentActions_Should_ReturnAttackAction_For_Each_LivingEnemyInLocation()
        {
            var (mapManager, characterManager) = new TestWorldBuilder()
                .WithEnemies(3)
                .WithEnemies(1, false)
                .Build();

            var actionManager = new ActionManager(mapManager, characterManager);

            var actions = actionManager.GetCurrentActions();

            var filteredActions = actions.Where(a => a.Description.StartsWith("Attack")).ToList();

            Assert.Equal(3, filteredActions.Count);
        }

        [Fact]
        public void GetCurrentActions_Should_CombineActions_From_Player_Location_And_Characters()
        {
            var (mapManager, characterManager) = new TestWorldBuilder()
                .WithEnemies(3)
                .WithExits(3)
                .Build();

            var actionManager = new ActionManager(mapManager, characterManager);

            Assert.Equal(7, actionManager.GetCurrentActions().Count);
        }
    }
}

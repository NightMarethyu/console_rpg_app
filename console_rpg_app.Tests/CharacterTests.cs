namespace console_rpg_app.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void TakeDamage_WhenCalled_ReducesCurrentHPByCorrectAmount()
        {
            var builder = new CharacterBuilder()
                .WithMaxHP(100)
                .WithCurrentHP(100);
            var factory = new CharacterFactory();
            var enemy = factory.CreateCharacter(builder, CharacterType.Enemy);

            int damageAmount = 25;
            int expectedHP = 75;

            enemy.TakeDamage(damageAmount);
            Assert.Equal(expectedHP, enemy.CurrentHP);
        }

        [Fact]
        public void TakeDamage_WhenCalled_LethalDamageSetsIsAliveToFalse()
        {
            var builder = new CharacterBuilder()
                .WithMaxHP(100)
                .WithCurrentHP(25);
            var factory = new CharacterFactory();
            var enemy = factory.CreateCharacter(builder, CharacterType.Enemy);

            int damageAmount = 25;
            bool expectedIsAlive = false;

            enemy.TakeDamage(damageAmount);
            Assert.Equal(expectedIsAlive, enemy.IsAlive);
        }
    }
}
using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.SpecialAttackPower, 3);
        }
    }
}

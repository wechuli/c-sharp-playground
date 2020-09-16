using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        [Theory]
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData), 
        //    MemberType = typeof(ExternalHealthDamageTestData))]
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    public class DataDrivenTest
    {
        private readonly PlayerCharacter _sut;
        public DataDrivenTest()
        {
            _sut = new PlayerCharacter();
        }

        [Theory]
        [InlineData(0,100)]
        [InlineData(1,99)]
        [InlineData(2,98)]
        public void TakeDamage(int damage,int expectedHealth)
        {
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }

        //using data from outside the class
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData),MemberType =typeof(InternalHealthDamageTestData))]
        public void TakeDamageMore(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, _sut.Health);
        }

    }
}

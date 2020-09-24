using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
   public class PlayerCharacterNumericShould
    {

        private readonly PlayerCharacter _sut;

        public PlayerCharacterNumericShould()
        {
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
           

            //Test equality

            Assert.Equal(100, _sut.Health);

            // Assert not equal

            Assert.NotEqual(0, _sut.Health);

        }

        [Fact(Skip ="Don't need to run this")]
        public void IncreaseHealthafterSleeping()
        {
        
            _sut.Sleep(); //Expected increase between 1 to 100 inclusive

            Assert.InRange<int>(_sut.Health, 101, 200);

        }
        // Floating point
    }
}

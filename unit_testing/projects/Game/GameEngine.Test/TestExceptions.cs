using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    public class TestExceptions
    {

        private readonly PlayerCharacter _sut;
        private readonly EnemyFactory _enemy;

        public TestExceptions()
        {
            _sut = new PlayerCharacter();
            _enemy = new EnemyFactory();
        }

        [Fact]
        public void NotAllowNullName()
        {
            

            Assert.Throws<ArgumentNullException>(() => _enemy.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
           
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => _enemy.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

        [Fact]
        public void RaiseSleptEvent()
        {
        

            Assert.Raises<EventArgs>(handler => _sut.PlayerSlept += handler, handler => _sut.PlayerSlept -= handler, () => _sut.Sleep());
        }
    }
}

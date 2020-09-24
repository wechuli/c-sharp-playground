using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    [Trait("Category", "Boss")]
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output;
        private readonly BossEnemy bossEnemy;
        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
            bossEnemy = new BossEnemy();
        }

        [Fact]
        
        public void HaveCorrectPower()
        {

            _output.WriteLine("Creating Boss Enemy");
          

            Assert.Equal(166.667, bossEnemy.TotalSpecialAttackPower,precision:3);
        }


      
    }
}

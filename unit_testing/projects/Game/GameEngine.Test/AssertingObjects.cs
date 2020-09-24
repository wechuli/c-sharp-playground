using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    [Trait("Category","Enemy")]
    public class AssertingObjectsShould
    {

        private readonly EnemyFactory enemy;
        public AssertingObjectsShould()
        {
            this.enemy = new EnemyFactory();
        }

        [Fact]
        
        public void CreateNormalEnemyByDefault()
        {
            

            enemy.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
            Assert.IsNotType<Enemy>(enemy);

            // if inheritence
            Assert.IsAssignableFrom<Enemy>(enemy);

            //test equality
        }

        [Fact]
        public void CreateSeparateInstances()
        {
           

            Enemy enemy1 = enemy.Create("Zombie");
            Enemy enemy2 = enemy.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
            //Assert.Same(enemy1, enemy2);
        }
    }
}

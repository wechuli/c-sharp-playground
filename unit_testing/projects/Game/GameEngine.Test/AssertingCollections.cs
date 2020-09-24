using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    public class AssertingCollectionsShould
    {

        private readonly PlayerCharacter _sut;
        public AssertingCollectionsShould()
        {
            _sut = new PlayerCharacter();
        }
        [Fact]
        public void HaveALongBow()
        {
            

            Assert.Contains("Long Bow", _sut.Weapons);
            Assert.DoesNotContain("Staff Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
           

            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            
            var expectedWeapons = new[] { "Long Bow","Short Bow","Short Sword"};

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        // loop through a collection and assert
        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
         
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

    }
}

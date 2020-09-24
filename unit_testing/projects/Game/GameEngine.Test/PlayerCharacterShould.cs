using System;
using Xunit;
using Xunit.Abstractions;


namespace GameEngine.Test
{
    public class PlayerCharacterShould:IDisposable
    {

        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        public PlayerCharacterShould(ITestOutputHelper ouput)
        {
            _sut = new PlayerCharacter();
            _output = ouput;
        }
        [Fact]
        public void BeInexperiencedWhenNew()
        {

      

            Assert.True(_sut.IsNoob);
            //Assert.False(sut.IsNoob);
            

        }

        [Fact]
        public void CalculateFullName()
        {
            
            _sut.FirstName = "Paul";
            _sut.LastName = "Wechuli";

            Assert.Equal("Paul Wechuli", _sut.FullName);
        }


        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {

           
            _sut.FirstName = "Paul";
            _sut.LastName = "Wechuli";

            Assert.StartsWith("Pau", _sut.FullName);
            Assert.EndsWith("li", _sut.FullName);
            Assert.Contains("chul", _sut.FullName);
            // Assert.Matches("[A-Z]{1}", sut.FullName);

        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
           

            _sut.FirstName = "JUNE";
            _sut.LastName = "NEKESA";

            Assert.Equal("June Nekesa", _sut.FullName,ignoreCase:true);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            

            Assert.Null(_sut.Nickname);
            // Assert.NotNull(sut.Nickname);
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");

        }
    }


}

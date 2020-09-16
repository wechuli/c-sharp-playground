using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    public class TestClass2
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public TestClass2(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;

            _output = output;
        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }
    }
}

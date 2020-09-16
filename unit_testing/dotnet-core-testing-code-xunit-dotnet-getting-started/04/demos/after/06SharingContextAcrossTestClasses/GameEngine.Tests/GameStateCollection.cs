using Xunit;

namespace GameEngine.Tests
{
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection : ICollectionFixture<GameStateFixture> {}
}

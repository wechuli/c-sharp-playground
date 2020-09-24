using Xunit;

namespace GameEngine.Test
{
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection : ICollectionFixture<GameStateFixture> {}
}

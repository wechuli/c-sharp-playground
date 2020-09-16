using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class GameState
    {
        public static readonly int EarthquakeDamage = 25;
        public List<PlayerCharacter> Players { get; set; } = new List<PlayerCharacter>();
        public Guid Id { get; } = Guid.NewGuid();

        public GameState()
        {
            CreateGameWorld();
        }        

        public void Earthquake()
        {
            foreach (var player in Players)
            {
                player.TakeDamage(EarthquakeDamage);
            }
        }

        public void Reset()
        {
            Players.Clear();
        }

        private void CreateGameWorld()
        {
            // Simulate expensive creation
            System.Threading.Thread.Sleep(2000);
        }
    }
}

using RiskPOC.Engine.models;
using System.Collections.Generic;

namespace RiskPOC.Engine.services
{
    public interface IPlayerCreator
    {
        List<Player> CreateNew(int count);
    }

    public static class PlayerCreatorFactory
    {
        public static IPlayerCreator Create(Game game)
        {
            return new PlayerCreator(game);
        }
    }

    internal class PlayerCreator : IPlayerCreator
    {
        internal Game _game;

        internal PlayerCreator(Game game)
        {
            _game = game;
        }
        
        public List<Player> CreateNew(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var player = new Player() { Game = _game };
                _game.players.Add(player);
            }

            return _game.players;
        }
    }
}

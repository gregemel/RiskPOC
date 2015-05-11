using RiskPOC.Engine.models;
using System;
using System.Collections.Generic;

namespace RiskPOC.Engine.services
{
    public interface IGameStarter
    {
        void AssignPlayerColor(List<Player> players);

        void AssignCountries(Game game);
    }

    public static class GameStarterFactory
    {
        public static IGameStarter Create()
        {
            return new GameStarter();
        }
    }

    internal class GameStarter : IGameStarter
    {
        public void AssignPlayerColor(List<Player> players)
        {
            var color = Color.Unassigned;

            foreach(var player in players)
            {
                color++;
                player.Color = color;
            }
        }

        public void AssignCountries(Game game)
        {
            var playerIterator = 0;

            if (game.players == null || game.players.Count == 0)
                throw new Exception("No players in the game!!!  Assigning countries requires players in the game.");

            foreach(var country in game.countries)
            {
                country.PlayerOccupying = game.players[playerIterator];

                if (country.Card == null)
                    throw new Exception("Country without a card!!!  Assigning countries requires each country to have a card.");

                country.TroopOccupyCount = country.ArmyCardCount;

                playerIterator++;

                if (playerIterator >= game.players.Count)
                    playerIterator = 0;
            }
        }
    }
}

using RiskPOC.Engine.models;
using System;

namespace RiskPOC.Engine.services
{
    public interface ICountriesHeldCounter
    {
        int CountPlayerHoldings(Player player);
    }

    public static class CountriesHeldCounterFactory
    {
        public static ICountriesHeldCounter Create()
        {
            return new CountriesHeldCounter();
        }
    }

    internal class CountriesHeldCounter : ICountriesHeldCounter
    {
        Player player;

        public int CountPlayerHoldings(Player newPlayer)
        {
            ValidatePlayer(newPlayer);

            return GetPlayersOccupyCount();
        }

        private void ValidatePlayer(Player newPlayer)
        {
            if (newPlayer == null)
                throw new Exception("Invalid player object!!!  Cannot count player's country holdings.");

            if (newPlayer.Game == null)
                throw new Exception("Player has no game!!!  Player must have a game to count countries.");

            player = newPlayer;
        }

        private int GetPlayersOccupyCount()
        {
            int counter = 0;

            foreach (var country in player.Game.countries)
            {
                if (country.PlayerOccupying == player)
                    counter++;
            }

            return counter;
        }
    }
}

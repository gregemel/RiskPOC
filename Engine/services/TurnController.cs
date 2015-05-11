using RiskPOC.Engine.models;
using System;

namespace RiskPOC.Engine.services
{
    public interface ITurnController
    {
        void GetNewArmies(Player player);

        bool CheckForHoldsEnoughCountries(Player player, int playerCount);
    }

    public static class TurnFactory
    {
        public static ITurnController CreateNextTurn()
        {
            return new TurnController();
        }
    }

    internal class TurnController : ITurnController
    {
        public void GetNewArmies(Player player)
        {
            player.ArmiesToPlaceThisTurn = player.CountriesCurrentlyHeld / 3;

            if (player.ArmiesToPlaceThisTurn < 3)
                player.ArmiesToPlaceThisTurn = 3;
        }

        public bool CheckForHoldsEnoughCountries(Player player, int playerCount)
        {
            switch(playerCount)
            {
                case 3:
                    return (player.CountriesCurrentlyHeld >= 25);
                case 4:
                    return (player.CountriesCurrentlyHeld >= 20);
                case 5:
                    return (player.CountriesCurrentlyHeld >= 15);
                default:
                    throw new Exception(string.Format("Unsupported player count of {0}!!!", playerCount));

            }

        }
    }
}

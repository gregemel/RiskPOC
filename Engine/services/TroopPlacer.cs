using System;
using RiskPOC.Engine.models;

namespace RiskPOC.Engine.services
{
    public interface ITroopPlacer
    {

        void PlaceTroop(Country country, int troopsToPlace);
    }

    public static class TroopPlacerFactory
    {
        public static ITroopPlacer Create(Player player)
        {
            return new TroopPlacer(player);
        }
    }

    internal class TroopPlacer : ITroopPlacer
    {
        Player player;

        internal TroopPlacer(Player playerNew)
        {
            if (playerNew == null)
                throw new Exception("TroopPlacer will not work without a player!!!");

            player = playerNew;
        }

        public void PlaceTroop(Country country, int troopsToPlace)
        {
            if (country == null)
                throw new Exception("TroopPlacer will not work without a country!!!");

            if (troopsToPlace < 1)
                throw new Exception("TroopPlacer will not place less than 1 troop!!!");

            if (country.PlayerOccupying != player)
                throw new Exception("TroopPlacer will not place troops in unheld country!!!");

            country.TroopOccupyCount += troopsToPlace;
        }
    }
}

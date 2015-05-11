
using System;
namespace RiskPOC.Engine.models
{
    public class Country
    {
        public Player PlayerOccupying { get; set; }

        public int TroopOccupyCount { get; set; }

        public TerritoryCard Card { get; set; }

        public int ArmyCardCount 
        { 
            get
            {
                if (Card == null)
                    throw new Exception("Country without a Card!!!");

                return Card.StarCount;
            }
        }
    }
}

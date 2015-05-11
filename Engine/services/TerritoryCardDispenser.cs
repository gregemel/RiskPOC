using RiskPOC.Engine.models;

namespace RiskPOC.Engine.services
{
    public interface ITerritoryCardDispenser
    {
        void GetEndOfTurnCard(Player player);
    }

    public static class TerritoryCardDispenserFactory
    {
        public static ITerritoryCardDispenser Create()
        {
            return new TerritoryCardDispenser();
        }
    }

    internal class TerritoryCardDispenser : ITerritoryCardDispenser
    {
        public void GetEndOfTurnCard(Player player)
        {
            if(player.CountryConqueredThisTurn)
                player.CardsCurrentlyHeld += 1;
        }

    }
}

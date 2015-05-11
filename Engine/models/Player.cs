using RiskPOC.Engine.services;

namespace RiskPOC.Engine.models
{
    public class Player
    {
        public Game Game { get; set; }

        public Color Color { get; set; }

        public int ArmiesToPlaceThisTurn { get; set; }
        public bool CountryConqueredThisTurn { get; set; }

        public int CardsCurrentlyHeld { get; set; }
        public int CountriesCurrentlyHeld 
        {
            get
            {
                var countriesHeldService = CountriesHeldCounterFactory.Create();
                return countriesHeldService.CountPlayerHoldings(this);
            }
        }
    }
}

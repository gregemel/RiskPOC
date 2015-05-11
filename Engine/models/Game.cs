using System.Collections.Generic;
using RiskPOC.Engine.services;

namespace RiskPOC.Engine.models
{
    public class Game
    {
        public List<Country> countries { get; set; }
        public List<Player> players { get; set; }

        public Game()
        {
            CountriesInitialize();

            PlayersInitialize();
        }

        private void PlayersInitialize()
        {
            players = new List<Player>();
        }

        private void CountriesInitialize()
        {
            var countriesCreator = CountriesCreatorFactory.Create();
            countries = countriesCreator.CreateNewCountryList();
        }
    }
}

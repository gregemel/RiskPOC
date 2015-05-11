using System.Collections.Generic;
using RiskPOC.Engine.models;

namespace RiskPOC.Engine.services
{
    public interface ICountriesCreator
    {

        List<Country> CreateNewCountryList();
    }

    public static class CountriesCreatorFactory
    {
        public static ICountriesCreator Create()
        {
            return new CountriesCreator();
        }
    }

    internal class CountriesCreator : ICountriesCreator
    {
        List<Country> countries = new List<Country>();

        public List<Country> CreateNewCountryList()
        {
            var country1 = CreateCountry(1);
            var country2 = CreateCountry(1);
            var country3 = CreateCountry(1);
            var country4 = CreateCountry(2);
            var country5 = CreateCountry(1);
            var country6 = CreateCountry(1);
            var country7 = CreateCountry(2);
            var country8 = CreateCountry(1);
            var country9 = CreateCountry(1);
            var country10 = CreateCountry(2);
            var country11 = CreateCountry(1);
            var country12 = CreateCountry(1);
            var country13 = CreateCountry(2);
            var country14 = CreateCountry(1);
            var country15 = CreateCountry(1);
            var country16 = CreateCountry(1);
            var country17 = CreateCountry(2);
            var country18 = CreateCountry(1);
            var country19 = CreateCountry(1);
            var country20 = CreateCountry(2);
            var country21 = CreateCountry(1);
            var country22 = CreateCountry(1);
            var country23 = CreateCountry(1);
            var country24 = CreateCountry(2);
            var country25 = CreateCountry(1);


            return countries;
        }

        private Country CreateCountry(int starCount)
        {
            var card = new TerritoryCard() { StarCount = starCount };
            var country = new Country() { Card = card };

            countries.Add(country);

            return country;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RiskPOC.Engine.models;
using RiskPOC.Engine.services;


namespace RiskPOC.Tests
{
    [TestClass]
    public class AtTheBeginningOfTheGame
    {
        private Game game;

        private IGameStarter gameStarter;

        public AtTheBeginningOfTheGame()
        {
            GameInitialize();

            GamePlayersInitialize();

            GameCountriesInitialize();

            GameStarterInitialize();
        }


        [TestMethod]
        public void ANewGameStartsWithAllCountries()
        {
            Assert.IsTrue(game.countries.Count > 0);
        }

        [TestMethod]
        public void ThereIsLeast1Players()
        {
            Assert.IsTrue(game.players.Count > 0);
        }

        [TestMethod]
        public void ThereAreAtLeast12Countries()
        {
            Assert.IsTrue(game.countries.Count >= 12);
        }

        [TestMethod]
        public void EachPlayerIsAssigned1Color()
        {
            Assert.IsTrue(game.players.Count > 0);
            Assert.IsTrue(game.players[0].Color > 0);
        }

        [TestMethod]
        public void EachPlayerIsAssignedUniqueColor()
        {
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.players);
            Assert.IsTrue(game.players.Count > 0);

            for (int i = 0; i < game.players.Count; i++)
            {
                for (var j = i + 1; j < game.players.Count; j++)
                    Assert.AreNotEqual(game.players[i].Color, game.players[j].Color);
            }
        }

        [TestMethod]
        public void EachPlayerIsAssignedCountries()
        {
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.players);
            Assert.IsTrue(game.players.Count > 0);

            foreach (var player in game.players)
            {
                Assert.IsTrue(player.CountriesCurrentlyHeld > 0);
            }

        }

        [TestMethod]
        public void EachCountryGetsAPlayer()
        {
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.players);
            Assert.IsTrue(game.countries.Count > 0);

            foreach (var country in game.countries)
            {
                Assert.IsNotNull(country.PlayerOccupying);
            }
        }

        [TestMethod]
        public void WhenInitiallyAssigningCountriesEachCountryGetsAnArmy()
        {
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.players);
            Assert.IsTrue(game.countries.Count > 0);

            foreach (var country in game.countries)
            {
                Assert.IsTrue(country.TroopOccupyCount > 0);
            }
        }

        [TestMethod]
        public void AssignedArmyCountIsCountrysStarCount()
        {
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.players);
            Assert.IsTrue(game.countries.Count > 0);

            foreach (var country in game.countries)
            {
                Assert.AreEqual(country.TroopOccupyCount, country.ArmyCardCount);
            }
        }


        private void GameInitialize()
        {
            game = new Game();
        }

        private void GamePlayersInitialize()
        {
            var playerCreator = PlayerCreatorFactory.Create(game);

            game.players = playerCreator.CreateNew(2);
        }

        private void GameCountriesInitialize()
        {
            var countriesCreator = CountriesCreatorFactory.Create();

            game.countries = countriesCreator.CreateNewCountryList();

        }

        private void GameStarterInitialize()
        {
            gameStarter = GameStarterFactory.Create();
            gameStarter.AssignPlayerColor(game.players);
            gameStarter.AssignCountries(game);
        }
    }
}

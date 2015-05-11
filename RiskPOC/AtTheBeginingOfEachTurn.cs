using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskPOC.Engine.models;
using RiskPOC.Engine.services;

namespace RiskPOC.Tests
{
    [TestClass]
    public class AtTheBeginingOfEachTurn
    {
        private Game game;

        private ITurnController turn;
        private IGameStarter gameStarter;
        private IPlayerCreator playerCreator;

        public AtTheBeginingOfEachTurn()
        {
            CreateTurnGameAndPlayers();
        }

        [TestMethod]
        public void PlayerGetsAtLeast3Armies()
        {
            turn.GetNewArmies(game.players[0]);

            Assert.IsTrue(game.players[0].ArmiesToPlaceThisTurn >= 3);

        }

        [TestMethod]
        public void PlayerGets1ArmyForEvery3CountriesHeld()
        {
            gameStarter.AssignCountries(game);

            turn.GetNewArmies(game.players[0]);

            Assert.IsTrue(game.players[0].ArmiesToPlaceThisTurn == 8);
        }

        [TestMethod]
        public void ThreePlayerGameIsOverWhenAPlayerHolds25()
        {
            var player = game.players[0];

            gameStarter = GameStarterFactory.Create();
            gameStarter.AssignCountries(game);

            bool hasEnough = turn.CheckForHoldsEnoughCountries(player, 3);

            Assert.IsTrue(hasEnough);
        }

        [TestMethod]
        public void PlayerCanPlaceNewTroopsOnHeldCountry()
        {
            Player player = game.players[0];

            Country country = game.countries[0];

            Assert.AreEqual(player, game.countries[0].PlayerOccupying);

            int originalValue = country.TroopOccupyCount;
            int troopsToPlace = 3;

            var troopPlacer = TroopPlacerFactory.Create(player);
            troopPlacer.PlaceTroop(country, troopsToPlace);

            Assert.AreEqual(originalValue + troopsToPlace, country.TroopOccupyCount);
        }


        [TestMethod]
        public void PlayerCanNotPlaceNewTroopsOnUnheldCountry()
        {
            Player otherPlayer = new Player() { Game = game };
            game.players.Add(otherPlayer);

            Assert.AreNotEqual(otherPlayer, game.countries[0].PlayerOccupying);

            Country country = game.countries[0];
            int originalValue = country.TroopOccupyCount;
            int troopsToPlace = 3;
            bool exceptionThrown = false;

            var troopPlacer = TroopPlacerFactory.Create(otherPlayer);

            try
            {
                troopPlacer.PlaceTroop(country, troopsToPlace);
            }
            catch
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
            Assert.AreNotEqual(originalValue + troopsToPlace, country.TroopOccupyCount);
        }

        private void CreateTurnGameAndPlayers()
        {
            CreateGame();

            CreatePlayersInGame();

            CreateTurn();

            CreateGameStarter();
        }

        private void CreateGame()
        {
            game = new Game();
        }

        private void CreatePlayersInGame()
        {
            if (game == null)
                throw new Exception("Creating players requires a game!!! ");

            playerCreator = PlayerCreatorFactory.Create(game);

            game.players = playerCreator.CreateNew(1);
        }

        private void CreateTurn()
        {
            turn = TurnFactory.CreateNextTurn();
        }

        private void CreateGameStarter()
        {
            gameStarter = GameStarterFactory.Create();
            gameStarter.AssignCountries(game);
        }

    }
}

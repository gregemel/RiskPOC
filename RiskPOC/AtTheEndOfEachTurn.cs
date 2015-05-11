using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskPOC.Engine.models;
using RiskPOC.Engine.services;

namespace RiskPOC.Tests
{
    [TestClass]
    public class AtTheEndOfEachTurn
    {
        Player player;

        ITerritoryCardDispenser cardDispenser;

        public AtTheEndOfEachTurn()
        {
            PlayerInitialize();

            CardDispenserInitialize();
        }


        [TestMethod]
        public void PlayerGetsANewCardIfCountryConquered()
        {
            player.CountryConqueredThisTurn = true;

            cardDispenser.GetEndOfTurnCard(player);

            Assert.IsTrue(player.CardsCurrentlyHeld == 1);
        }

        [TestMethod]
        public void PlayerDoesNotGetCardWithoutCountryConquered()
        {
            player.CountryConqueredThisTurn = false;

            cardDispenser.GetEndOfTurnCard(player);

            Assert.IsTrue(player.CardsCurrentlyHeld == 0);
        }


        private void PlayerInitialize()
        {
            player = new Player();
            player.CardsCurrentlyHeld = 0;
        }

        private void CardDispenserInitialize()
        {
            cardDispenser = TerritoryCardDispenserFactory.Create();
        }

    }
}

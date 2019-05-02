using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class RoundPassController
    {
        private static RoundPassController instance;

        public static RoundPassController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoundPassController();
                }
                return instance;
            }
        }

        CampsiteModel playerOne;
        CampsiteModel playerTwo;
        RoundPassedModel roundPassedForPlayerOne;
        RoundPassedModel roundPassedForPlayerTwo;

        List<RoundPassedUnitTypeModel> roundPassedUnitTypes;
        List<Campermodel> campers;

        private int roundNumber;
        private int amountOfCampers;

        public int RoundNumber { get => roundNumber; }
        public int AmountOfCampers { get => amountOfCampers; }
        public RoundPassedModel RoundPassedForPlayerOne { get => roundPassedForPlayerOne; }
        public RoundPassedModel RoundPassedForPlayerTwo { get => roundPassedForPlayerTwo; }

        private RoundPassController()
        {
            this.roundNumber = 0;
        }


        public void CalculateRoundEvents()
        {
            //logik for det som skal ske før IntermediateState påbegyndes


            this.roundNumber += 1;
            this.amountOfCampers = 30;

            roundPassedUnitTypes = new List<RoundPassedUnitTypeModel>();
            campers = new List<Campermodel>();

            playerOne = CampsiteController.Instance.PlayerOne;
            playerTwo = CampsiteController.Instance.PlayerTwo;

            // Create rounds
            roundPassedForPlayerOne = new RoundPassedModel(playerOne.ID, this.roundNumber, playerOne.TotalIncome);
            roundPassedForPlayerTwo = new RoundPassedModel(playerTwo.ID, this.roundNumber, playerTwo.TotalIncome);

            // Create rounds and unittypes binding
            foreach (UnitTypeModel unit in CampsiteController.Instance.Units)
            {
                if (unit.CampingGroundsID == playerOne.ID)
                {
                    roundPassedUnitTypes.Add(new RoundPassedUnitTypeModel(roundPassedForPlayerOne.ID, unit.ID));
                }
                else if (unit.CampingGroundsID == playerTwo.ID)
                {
                    roundPassedUnitTypes.Add(new RoundPassedUnitTypeModel(roundPassedForPlayerTwo.ID, unit.ID));
                }
            }

            // Create 30 campers
            campers = CamperFactory.Instance.CreateCamper(this.roundNumber, this.amountOfCampers);

            // Check if campers want to live anywhere
            foreach (Campermodel campist in campers)
            {
                HandleCamperLivingSomewhereFunctionality(campist);
            }

        }





        private void HandleCamperLivingSomewhereFunctionality(Campermodel campist)
        {
            // Get a list of non-occupied roundpassedunittypes fra spiller 1 og to i roundpassedunittype listen
            List<RoundPassedUnitTypeModel> freeRoundPassedUnitTypes = roundPassedUnitTypes.FindAll((rpum) =>
            {
                if (rpum.CampistID == 0)
                {
                    return true;
                }
                return false;
            });

            // Get the list of actual unit types fra spiller 1 og 2
            List<UnitTypeModel> freeUnitTypes = CampsiteController.Instance.Units.FindAll((unit) =>
            {
                bool isFree = freeRoundPassedUnitTypes.Exists((frput) =>
                {
                    return (frput.UnitTypeID == unit.ID) ? true : false;
                });

                return (isFree) ? true : false;
            });


            // Find a free unit type hos spliller 1, som er samme type osm campist leder efter
            UnitTypeModel playerOneUnitType = freeUnitTypes.FirstOrDefault((unit) =>
            {
                return (unit.Type == campist.Pref && unit.CampingGroundsID == playerOne.ID) ? true : false;
            });

            // Find a free unit type hos spliller 2, som er samme type osm campist leder efter
            UnitTypeModel playerTwoUnitType = freeUnitTypes.FirstOrDefault((unit) =>
            {
                return (unit.Type == campist.Pref && unit.CampingGroundsID == playerTwo.ID) ? true : false;
            });

            // Check which player the camper prefers to choose
            CampsiteModel chosenPlayer = null;
            if (playerOneUnitType == null && playerTwoUnitType == null)
            {
                chosenPlayer = null;
            }
            else if (playerOneUnitType != null && playerTwoUnitType == null)
            {
                chosenPlayer = playerOne;
            }
            else if (playerOneUnitType == null && playerTwoUnitType != null)
            {
                chosenPlayer = playerTwo;
            }
            else if (playerOneUnitType != null && playerTwoUnitType != null)
            {
                // Make sure player one and two does not have same price cap
                if (campist.Pref == "Tent" && playerOne.PriceOfTent != playerTwo.PriceOfTent)
                {
                    // Vælger den billigste
                    chosenPlayer = (playerOne.PriceOfTent < playerTwo.PriceOfTent) ? playerOne : playerTwo;
                }
                else if (campist.Pref == "Caravan" && playerOne.PriceOfCaravan != playerTwo.PriceOfCaravan)
                {
                    // Vælger den billigste
                    chosenPlayer = (playerOne.PriceOfCaravan < playerTwo.PriceOfCaravan) ? playerOne : playerTwo;
                }
                else
                {
                    // Tilfældig spiller
                    Random random = new Random();
                    chosenPlayer = (random.Next(1, 100) < 50) ? playerOne : playerTwo;
                }
            }


            // Hvis der er en ledig plads hos en af spillerne
            if (chosenPlayer != null)
            {
                // Hvis campisten har råd!
                if (chosenPlayer.PriceOfTent <= campist.MaxPay)
                {
                    if (chosenPlayer.ID == playerOne.ID)
                    {
                        // Get the RP unit
                        RoundPassedUnitTypeModel rput = freeRoundPassedUnitTypes.FirstOrDefault((frupt) =>
                        {
                            return (frupt.UnitTypeID == playerOneUnitType.ID) ? true : false;
                        });

                        MoveCamperIntoTheFrickinSiteAndUpdateIncomeFunctionality(playerOne, campist, roundPassedForPlayerOne, rput);
                    }
                    else if (chosenPlayer.ID == playerTwo.ID)
                    {
                        RoundPassedUnitTypeModel rput = freeRoundPassedUnitTypes.FirstOrDefault((frupt) =>
                        {
                            return (frupt.UnitTypeID == playerTwoUnitType.ID) ? true : false;
                        });

                        MoveCamperIntoTheFrickinSiteAndUpdateIncomeFunctionality(playerTwo, campist, roundPassedForPlayerTwo, rput);
                    }
                }
            }
        }

        private void MoveCamperIntoTheFrickinSiteAndUpdateIncomeFunctionality(CampsiteModel player, Campermodel campist, RoundPassedModel rp, RoundPassedUnitTypeModel rput)
        {
            // Add camper to the unit
            rput.AddCampist(campist.ID);

            // Set campist to have et id for pladsen
            campist.ChangeUnitTypeID(rput.UnitTypeID);

            if (campist.Pref == "Tent")
            {
                // Update income for campsitemodel
                playerOne.ChangeTotalIncome(playerOne.PriceOfTent);

                // Update income for roundpassed model
                rp.UpdateIncome(playerOne.PriceOfTent);
            }
            else if (campist.Pref == "Caravan")
            {
                // Update income for campsitemodel
                playerOne.ChangeTotalIncome(playerOne.PriceOfTent);

                // Update income for roundpassed model
                rp.UpdateIncome(playerOne.PriceOfTent);
            }
        }

    }
}

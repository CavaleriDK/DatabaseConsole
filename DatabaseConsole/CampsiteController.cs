using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class CampsiteController
    {
        List<UnitTypeModel> units = new List<UnitTypeModel>();

        //properties til player 1 og 2 og unit listen
        string playerName;
        int campsiteCount;
        int caravanPrice;
        int tentPrice;
        CampsiteModel playerOne;
        CampsiteModel playerTwo;

        public CampsiteModel PlayerOne { get => playerOne; }
        public CampsiteModel PlayerTwo { get => playerTwo; }
        public List<UnitTypeModel> Units { get => units; }

        private static CampsiteController instance;

        public static CampsiteController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CampsiteController();
                }
                return instance;
            }
        }

        private CampsiteController()
        {

        }

        public void AddCampsiteByName(string name, bool isPlayerOne)
        {
            if (isPlayerOne == true)
            {
                playerOne = new CampsiteModel(name);
            }
            else
            {
                playerTwo = new CampsiteModel(name);
            }
        }

        public int SetTentPrice(string price, bool isPlayerOne)
        {
            try
            {
                tentPrice = Int32.Parse(price);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
            }

            if (isPlayerOne == true)
            {
                playerOne.UpdateTentPrice(tentPrice);
                return tentPrice;
            }
            else
            {
                playerTwo.UpdateTentPrice(tentPrice);
                return tentPrice;
            }
        }

        public int SetCaravanPrice(string price, bool isPlayerOne)
        {
            try
            {
                caravanPrice = Int32.Parse(price);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
            }

            if (isPlayerOne == true)
            {
                playerOne.UpdateCaravanPrice(caravanPrice);
                return caravanPrice;
            }
            else
            {
                playerTwo.UpdateCaravanPrice(caravanPrice);
                return caravanPrice;
            }
        }

        public void AddTent(bool isPlayerOne)
        {
            if (isPlayerOne == true)
            {
                units.Add(new UnitTypeModel("Tent", playerOne.MyID()));
            }
            else
            {
                units.Add(new UnitTypeModel("Tent", playerTwo.MyID()));
            }
        }

        public void AddCaravan(bool isPlayerOne)
        {
            if (isPlayerOne == true)
            {
                units.Add(new UnitTypeModel("Caravan", playerOne.MyID()));
            }
            else
            {
                units.Add(new UnitTypeModel("Caravan", playerTwo.MyID()));
            }
        }

        public void RemoveTent(bool isPlayerOne)
        {
            // Find telt som passer til den rette spiller i liste

            // Kald model.remove på teltet
            UnitTypeModel tentForRemoval = null;
            // Fjern modellen fra listen
            if (isPlayerOne == true)
            {
                foreach (UnitTypeModel unit in units)
                {
                    if (unit.Type == "Tent" && unit.CampingGroundsID == playerOne.MyID())
                    {
                        tentForRemoval = unit;
                        break;
                    }
                }
                if (tentForRemoval != null)
                {
                    tentForRemoval.Remove();
                    units.Remove(tentForRemoval);
                }
            }
            else
            {
                foreach (UnitTypeModel unit in units)
                {
                    if (unit.Type == "Tent" && unit.CampingGroundsID == playerTwo.MyID())
                    {
                        tentForRemoval = unit;
                        break;
                    }
                }
                if (tentForRemoval != null)
                {
                    tentForRemoval.Remove();
                    units.Remove(tentForRemoval);
                }
            }
        }

        public void RemoveCaravan(bool isPlayerOne)
        {
            UnitTypeModel caravanForRemoval = null;

            if (isPlayerOne == true)
            {
                foreach (UnitTypeModel unit in units)
                {
                    if (unit.Type == "Caravan" && unit.CampingGroundsID == playerOne.MyID())
                    {
                        caravanForRemoval = unit;
                        break;
                    }
                }
                if (caravanForRemoval != null)
                {
                    caravanForRemoval.Remove();
                    units.Remove(caravanForRemoval);
                }
            }
            else
            {
                foreach (UnitTypeModel unit in units)
                {
                    if (unit.Type == "Caravan" && unit.CampingGroundsID == playerTwo.MyID())
                    {
                        caravanForRemoval = unit;
                        break;
                    }
                }
                if (caravanForRemoval != null)
                {
                    caravanForRemoval.Remove();
                    units.Remove(caravanForRemoval);
                }
            }
        }

        public void PassTurn(bool isPlayerOne)
        {
            //revider når states er lavet færdige
            /*
            GameWorld.ChangeState(PlayerTwoState.Instance);
            */
            if (isPlayerOne == true)
            {
                //Program.ChangeState(PlayerTwoTurnState.Instance);
            }
            else
            {
                //Program.ChangeState(IntermediateState.Instance);
            }
        }
    }
}

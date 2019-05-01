using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class CamperFactory
    {
        Random rnd = new Random();

        private static CamperFactory instance;
        public static CamperFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CamperFactory();
                }
                return instance;
            }
        }


        public List<Campermodel> CreateCamper()
        {
            List<Campermodel> NewCampers = new List<Campermodel>();
            for (int i = 0; i < 30; i++)
            {

                int randomPay;
                int randomPercent = rnd.Next(100);
                if (randomPercent < 50)
                {
                    randomPay = rnd.Next(10, 120);
                    NewCampers.Add(new Campermodel("Tent", randomPay));
                }
                else
                {
                    randomPay = rnd.Next(50, 200);
                    NewCampers.Add(new Campermodel("Caravan", randomPay));
                }

            }
            return NewCampers;
        }



        // Først få lavet  denne factory til en singleton

        // Lave en metode, som kan oprette 30 campister
        // Kan ev.t gøres med en for() løkke
        // Metoden skal returnere List<Campermodel>
        // Hver campist i listen er en new Campermodel(pref, maxpay)
        // Kig evt. på Random klassen


    }
}

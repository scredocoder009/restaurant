using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourant
{
    class EggOrder
    {
        private int quality;
        private int quantity;

        public EggOrder(int quantity)
        {
           this.quantity = quantity;

           Random random = new Random();
           quality = random.Next(30, 101);
        }

        public int GetQuantity()
        {
            return this.quantity;
        }


        public int GetQuality()
        {
            return quality;
        }

         
        public void Crack()
        {
            if (this.quality < 25)
            {
                throw new Exception("This simulates a rotten egg");
            }
        }

        public void DiscardShell()
        {

        }

        public void Cook()
        {

        }

    }
}

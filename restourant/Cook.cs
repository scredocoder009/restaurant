using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourant
{
    class Cook
    {
        private int chicken_quantity = 0;
        private int egg_quantity = 0;
        private ChickenOrder chickenOrder;
        private EggOrder eggOrder;

        public void Submit(MenuItem item)
        {
            if (item == MenuItem.chicken)
            {
                chicken_quantity++;
              
            }
            else if (item == MenuItem.egg)
            {
                egg_quantity++;
              
            }
        }

        public void PrepareFood()
        {
            if (chicken_quantity > 0)
            {
                chickenOrder = new ChickenOrder(chicken_quantity);
                for (int j = 0; j < chicken_quantity; j++)
                {
                    chickenOrder.CutUp();
                }
                chickenOrder.Cook();
            }
            if (egg_quantity > 0)
            {
                eggOrder = new EggOrder(egg_quantity);
                for (int j = 0; j < egg_quantity; j++)
                {
                    eggOrder.Crack();
                    eggOrder.DiscardShell();
                }
                eggOrder.Cook();
            }
        }

        public string Inspect()
        {
            if (egg_quantity > 0)
            {
                return eggOrder.GetQuality().ToString();
            }
            return "No inspection is required";
        }
    }
}

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
        private int chickenQuantity = 0;
        private int eggQuantity = 0;
        private ChickenOrder chickenOrder;
        private EggOrder eggOrder;

        public void Submit(MenuItem item)
        {
            if (item == MenuItem.chicken)
            {
                chickenQuantity++;
            }
            else if (item == MenuItem.egg)
            {
                eggQuantity++;
            }
        }

        public void PrepareFood()
        {
            if (chickenQuantity > 0)
            {
                chickenOrder = new ChickenOrder(chickenQuantity);
                for (int j = 0; j < chickenQuantity; j++)
                {
                    chickenOrder.CutUp();
                }
                chickenOrder.Cook();
            }
            if (eggQuantity > 0)
            {
                eggOrder = new EggOrder(eggQuantity);
                for (int j = 0; j < eggQuantity; j++)
                {
                    eggOrder.Crack();
                    eggOrder.DiscardShell();
                }
                eggOrder.Cook();
            }
        }

        public string Inspect()
        {
            if (eggQuantity > 0)
            {
                return eggOrder.GetQuality().ToString();
            }
            return "No inspection is required";
        }
    }
}

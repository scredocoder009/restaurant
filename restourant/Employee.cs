using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourant
{
    class Employee
    {
        private int quant;
        private object menu_Item;


        public Employee()
        {

        }

        public object NewRequest(int quantity, Type MenuIntem)
        {
            quant = quantity;
            menu_Item = MenuIntem;

            if (MenuIntem ==typeof( ChickenOrder))
            {
                return new ChickenOrder(quantity);
            }
            return new EggOrder(quantity);
        }
   

        public object CopyRequest()
        {
            if (menu_Item is ChickenOrder)
            {
                return new ChickenOrder(quant);
            }
            return new EggOrder(quant);
        }


        public string Inspect(object menuItem)
        {
            if (menuItem is EggOrder)
            {
                return "Egg quality" + ((EggOrder)menuItem).GetQuality();
            }

            return "No inspection is required";

        }


        public string PrepareFood(object menuItem)
        {

            if (menuItem is ChickenOrder)
            {
                ChickenOrder chickenOrder = (ChickenOrder)menuItem;


                for (int i = 0; i < chickenOrder.GetQuantity(); i++)
                {
                    chickenOrder.CutUp();
                }

                chickenOrder.Cook();

                return $"{chickenOrder.GetQuantity() } is ready chicken";
            }
            else
            {
                EggOrder eggorder = (EggOrder)menuItem;

                for (int i = 0; i < eggorder.GetQuantity(); i++)
                {
                    eggorder.Crack();
                    eggorder.DiscardShell();
                }
                eggorder.Cook();
                return $"{eggorder.GetQuantity() } is ready egg";
            }


        }
    }
}

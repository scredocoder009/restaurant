using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourant
{
    class Employee
    {
        private int quant;
        private object menu_Item;
        private int calc = 0;

        public Employee()
        {

        }
       
        public object NewRequest(int quantity, Type MenuIntem)
        {

            quant = quantity;

            if (MenuIntem == typeof(ChickenOrder))
            {
                menu_Item = new ChickenOrder(quantity);
            }
            else
            {
                menu_Item = new EggOrder(quantity);
            }
            return menu_Item;
        }
        
        //TODO: Method should copy last order even if it was an wrong order
        public object CopyRequest()
        {
            if (menu_Item.GetType() == typeof(EggOrder))
            {
                return new EggOrder(quant);
            }
            return new ChickenOrder(quant);
        }
        
        //TODO: You have to simulate 1/2 forgetting inspectation if the order is an egg
        public string Inspect(object menuItem)
        {
            if (menuItem.GetType() == typeof(EggOrder))
            {
                return ((EggOrder)menuItem).GetQuality().ToString();
            }
            return " No inspection is required";
        }

        public string PrepareFood(object menuItem)
        {
            calc++;

            if (calc == 3)
            {
                if (menuItem.GetType() == typeof(ChickenOrder))
                {
                    menuItem = new EggOrder(quant);
                }
                else
                {
                    menuItem = new ChickenOrder(quant);
                }
                calc = 0;
            }

            if (menuItem.GetType() == typeof(ChickenOrder))
            {
                ChickenOrder chickenOrder = (ChickenOrder)menuItem;
                for (int i = 0; i < chickenOrder.GetQuantity(); i++)
                {
                    chickenOrder.CutUp();
                }
                chickenOrder.Cook();
                return chickenOrder.GetQuantity().ToString() + " chicken is ready";
            }
            else
            {
                EggOrder eggorder = (EggOrder)menuItem;
                for (int i = 0; i < eggorder.GetQuantity(); i++)
                {
                    try
                    {
                        eggorder.Crack();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    eggorder.DiscardShell();
                }
                eggorder.Cook();
                return ($"{eggorder.GetQuantity() } egg is ready");
            }
        }

        public static bool IsNumeric( string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}

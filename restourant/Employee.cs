using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct PrepareFoodResult
{

    public PrepareFoodResult(bool valid, string message)
    {
        this.valid = valid;
        this.message = message;
    }

    public bool valid;
    public string message;
}

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
            //menu_Item = MenuIntem;

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


        public object CopyRequest()
        {
            if (menu_Item.GetType() == typeof(EggOrder))
            {
                return new EggOrder(quant);
            }
            return new ChickenOrder(quant);
        }


        public string Inspect(object menuItem)
        {
            if (menuItem.GetType() == typeof(EggOrder))
            {
                return ((EggOrder)menuItem).GetQuality().ToString();
                     
            }

            return " No inspection is required";
            
        }


        public PrepareFoodResult PrepareFood(object menuItem)
        {   

            if (menuItem.GetType() == typeof(ChickenOrder))
            {
                ChickenOrder chickenOrder = (ChickenOrder)menuItem;


                for (int i = 0; i < chickenOrder.GetQuantity(); i++)
                {
                    chickenOrder.CutUp();
                }

                chickenOrder.Cook();

                return  new PrepareFoodResult(true, $"{chickenOrder.GetQuantity() } chicken is ready ");
            }
            else
            {
                EggOrder eggorder = (EggOrder)menuItem;

                for (int i = 0; i < eggorder.GetQuantity(); i++)
                {
                    try {
                        eggorder.Crack();
                    }catch(Exception ex)
                    {
                        return new PrepareFoodResult(false, ex.Message);
                    }
                    
                    eggorder.DiscardShell();
                }
                eggorder.Cook();
                return  new  PrepareFoodResult( true , $"{eggorder.GetQuantity() } egg is ready");
            }


        }
    }
}

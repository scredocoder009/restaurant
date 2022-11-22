using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourant
{

    class Server
    {
        MenuItem[][] OrderList = new MenuItem[8][];
        int CustomerIndex = 0;
        Cook cook;
        public Server()
        {
            cook = new Cook();
        }

        public int Receive(int quantChicken, int quantEgg, int juise)
        {
            if (CustomerIndex == 8)
            {
                throw new Exception("order more than 8");
            }
            OrderList[CustomerIndex] = new MenuItem[quantChicken + quantEgg + 1];
            for (int i = 0; i < quantChicken; i++)
            {
                OrderList[CustomerIndex][i] = MenuItem.chicken;
            }
            for (int i = 0; i < quantEgg; i++)
            {
                OrderList[CustomerIndex][i] = MenuItem.egg;
            }

            OrderList[CustomerIndex][quantChicken + quantEgg] = (MenuItem)juise;
            CustomerIndex++;
            return CustomerIndex;
        }

        public string Send()
        {
            for (int i = 0; i < CustomerIndex; i++)
            {
                MenuItem[] item = OrderList[i];
                for (int j = 0; j < item.Length; j++)
                {
                    cook.Submit(item[j]);
                }
                cook.PrepareFood();
            }
            return cook.Inspect();

        }
        public string[] Serve()
        {
            string[] result = new string[8];
            int chicken = 0;
            int egg = 0;
            for (int i = 0; i < CustomerIndex; i++)
            {
                for (int j = 0; j < OrderList[i].Length - 1; j++)
                {
                    if (OrderList[i][j] == MenuItem.chicken)
                    {
                        chicken++;
                    }
                    else
                    {
                        egg++;
                    }
                }
                result[i] = "Customer " + i + " is served " + chicken + " chicken " + egg + " egg " + OrderList[i][OrderList[i].Length - 1];
                chicken = 0;
                egg = 0;
            }
            CustomerIndex = 0;
            return result;
        }
    }
}

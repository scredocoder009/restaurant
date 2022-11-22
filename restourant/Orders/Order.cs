using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourant
{
    class Order
    {
        public  int quantity;

        public Order(int quantity)
        {
            this.quantity = quantity;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void Cook()
        {

        }
        public void SubstractQuantity()
        {

        }
    }
}

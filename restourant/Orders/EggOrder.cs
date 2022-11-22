﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourant
{
    class EggOrder:Order
    {
        private int quality;

        public EggOrder(int quantity) : base(quantity)
        {
           this.quantity = quantity;
            Random random = new Random();
            quality = random.Next(30, 101);
        }

        public int GetQuality()
        {
            return quality;
        }
     
        public void Crack() 
        {
  
        }

        public void DiscardShell()
        {

        }
    }
}

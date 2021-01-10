using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class BasketSummaryVM
    {
        public int BaksetCount { get; set; }
        public decimal BasketTotal { get; set; }

        public BasketSummaryVM()
        {
                
        }

        public BasketSummaryVM(int basketCount, decimal basketTotal )
        {
            this.BaksetCount = basketCount;
            this.BasketTotal = basketTotal;
        }
    }
}

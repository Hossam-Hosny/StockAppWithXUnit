using Entities;
using ServiceContracts.ValidationClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderRequest
    {
        [Required]
        public string StockSymbol { get; set; }
        [Required]
        public string StockName { get; set; }
        [DateNotOlderThan2000]
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(minimum: 1, maximum: 100_000)]
        public  uint Quantity { get; set; }
        [Range(minimum: 1, maximum: 10_000)]
        public double Price { get; set; }





        public SellOrder ToSellOrder()
        {
            return new SellOrder
            {
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Price = Price,
                StockName = StockName,
                StockSymbol = StockSymbol,
                Quantity = Quantity
            };
        }
    }
}

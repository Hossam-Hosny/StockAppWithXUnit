using Entities;
using ServiceContracts.ValidationClass;
using System.ComponentModel.DataAnnotations;
namespace ServiceContracts.DTO
{
    public class BuyOrderRequest
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






        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder
            {
                StockName = StockName,
                StockSymbol = StockSymbol,
                Price = Price,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity
                
            };
        }
    }
}

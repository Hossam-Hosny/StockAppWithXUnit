using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BuyOrder
    {
        [Required]
        public Guid BuyOrderId { get; set; }
        [Required]
        public string StockSymbol { get; set; }
        [Required]
        public string StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(minimum:1,maximum:100_000)]
        public uint Quantity { get; set; }

        [Range(minimum:1 , maximum:10_000)]
        public double Price { get; set; }




       


    }
}

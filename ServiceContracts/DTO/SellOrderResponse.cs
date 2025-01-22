using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderResponse
    {
        public Guid SellOrderId { get; set; }
     
        public string StockSymbol { get; set; }
 
        public string StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
     
        public  uint Quantity { get; set; }
    
        public double Price { get; set; }
        public double TradeAmount { get; set; }




        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj is not SellOrderResponse) { return false; }
            SellOrderResponse sellOrder = (SellOrderResponse)obj;
            return SellOrderId == sellOrder.SellOrderId &&
                StockSymbol == sellOrder.StockSymbol &&
                StockName == sellOrder.StockName &&
                Price == sellOrder.Price &&
                DateAndTimeOfOrder == sellOrder.DateAndTimeOfOrder &&
                Quantity == sellOrder.Quantity;

        }

        public override string ToString()
        {
            return $"Sell Order Id {SellOrderId} , Stock Symbol {StockSymbol} , " +
                $"Stock Name {StockName} , Price {Price} , DateAndTime of Order {DateAndTimeOfOrder.ToString("dd MMMM yyyy hh:mm ss tt")}" +
                $"UniteQuantity {Quantity} Trade Amount {TradeAmount}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class SellOrderExtentions
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                DateAndTimeOfOrder=sellOrder.DateAndTimeOfOrder,
                Price =sellOrder.Price,
                SellOrderId = sellOrder.SellOrderId,
                StockName = sellOrder.StockName,
                StockSymbol = sellOrder.StockSymbol,
                TradeAmount = sellOrder.Price * sellOrder.Quantity,
                Quantity = sellOrder.Quantity
            };
        }
    }
}

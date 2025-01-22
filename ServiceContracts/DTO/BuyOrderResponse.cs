using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class BuyOrderResponse
    {
        
        public Guid BuyOrderId { get; set; }        
        public string StockSymbol { get; set; }   
        public string StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public  uint Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }




        public override bool Equals(object? obj)
        {
            if (obj is null) { return false; }
            if (obj is not BuyOrderResponse) { return false; }
            BuyOrderResponse buyOrder = (BuyOrderResponse)obj;
            return BuyOrderId == buyOrder.BuyOrderId &&
                StockSymbol == buyOrder.StockSymbol &&
                StockName == buyOrder.StockName &&
                Price == buyOrder.Price &&
                TradeAmount == buyOrder.TradeAmount &&
                Quantity == buyOrder.Quantity &&
                DateAndTimeOfOrder == buyOrder.DateAndTimeOfOrder;
        }
        public override string ToString()
        {
            return $" Buy Order Id {BuyOrderId} , Stock Symbol {StockSymbol} , " +
                $"Stock Name {StockName} , Price {Price} , Trade Amount {TradeAmount} ," +
                $"Unit Quantity {Quantity} , Date And Time of Order {DateAndTimeOfOrder.ToString("dd MMMM yyyy hh:mm ss tt")}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }







    }



    public static class BuyOrderExtentions
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse()
            {
                BuyOrderId = buyOrder.BuyOrderId,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Price = buyOrder.Price,
                StockName = buyOrder.StockName,
                StockSymbol = buyOrder.StockSymbol,
                Quantity = buyOrder.Quantity,
                TradeAmount = buyOrder.Price * buyOrder.Quantity
            };
        }
    }


}


using Entities;
using ServiceContracts.DTO;
using ServiceContracts.Helpers;
using ServiceContracts.Interfaces;

namespace Services
{
    public class StockServices : IStockService
    {

        private readonly List<BuyOrder> _buyOrders;
        private readonly List<SellOrder> _sellOerder;

        public StockServices()
        {
            _buyOrders = new List<BuyOrder>();
            _sellOerder = new List<SellOrder>();
        }

        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
           if (buyOrderRequest is null) { throw new ArgumentNullException(nameof(buyOrderRequest)); }

            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
            buyOrder.BuyOrderId = Guid.NewGuid();

            _buyOrders.Add(buyOrder);

            return buyOrder.ToBuyOrderResponse();


        }

        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest is null) { throw new ArgumentNullException(nameof(sellOrderRequest)); }

            ValidationHelper.ModelValidation(sellOrderRequest);

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            sellOrder.SellOrderId = Guid.NewGuid();
            _sellOerder.Add(sellOrder);

            return sellOrder.ToSellOrderResponse();

        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            return _buyOrders.
                 OrderByDescending(temp => temp.DateAndTimeOfOrder)
                 .Select(temp => temp.ToBuyOrderResponse()).ToList();
        }

        public List<SellOrderResponse> GetSellOrders()
        {
            return _sellOerder
                .OrderByDescending(temp => temp.DateAndTimeOfOrder)
                .Select(temp => temp.ToSellOrderResponse()).ToList();
        }
    }
}

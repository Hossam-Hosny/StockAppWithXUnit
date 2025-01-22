﻿using ServiceContracts.DTO;

namespace ServiceContracts.Interfaces
{
    public interface IStockService
    {

        BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
        SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest);
        List<BuyOrderResponse> GetBuyOrders();
        List<SellOrderResponse> GetSellOrders();

    }
}

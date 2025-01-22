using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Interfaces
{
    public interface IFinnhubService
    {

        Task<Dictionary<string, object>?> GetCompanyProfile(string StockSymbol);
        Task<Dictionary<string,object>?> GetStockPriceQuote(string StockSymbol);




    }
}

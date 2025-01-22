using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts.DTO;
using ServiceContracts.Helpers;
using ServiceContracts.Interfaces;

namespace StockAppWithXUnit.Controllers
{
    public class TradeController : Controller
    {
        private readonly TradingOptions _tradingOptions;
        private readonly IFinnhubService _finnhubService;
        private readonly IStockService _stockService;
        private readonly IConfiguration _configuration;

        public TradeController( IOptions<TradingOptions> options,IConfiguration config ,IFinnhubService finnhubService, IStockService stockService)
        {
            _tradingOptions = options.Value;
            _finnhubService = finnhubService;
            _stockService = stockService;
            _configuration = config;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(_tradingOptions.DefaultStockSymbol)) { _tradingOptions.DefaultStockSymbol ="MSFT"; }

            var CompanyProfileDictionary =await _finnhubService.GetCompanyProfile(_tradingOptions.DefaultStockSymbol);
            var StockQuoteDictionary =await _finnhubService.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);



            StockTrade stockTrade = new StockTrade()
            {

                StockName = Convert.ToString(CompanyProfileDictionary["name"]),
                StockSymbol = Convert.ToString(CompanyProfileDictionary["ticker"]),
                Price = Convert.ToDouble(StockQuoteDictionary["c"].ToString())

            };

            ViewBag.FinnhubToken = _configuration["GetCompanyToken"];

            return View(stockTrade);
        }
    }
}

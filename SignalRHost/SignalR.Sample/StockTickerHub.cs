using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRHost.SignalR.Sample
{
    [HubName("stockTickerHub")]
    public class StockTickerHub : Hub
    {
        private readonly StockTicker _stockTicker;

        public StockTickerHub() : this(StockTicker.Instance) { }

        public StockTickerHub(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            Debug.WriteLine("Get all Stocks called.");
            return _stockTicker.GetAllStocks();
        }

        public string GetMarketState()
        {
            Debug.WriteLine("Get Market State called");
            return _stockTicker.MarketState.ToString();
        }

        public void OpenMarket()
        {
            Debug.WriteLine("Open Market called");
            _stockTicker.OpenMarket();
        }

        public void CloseMarket()
        {
            Debug.WriteLine("Close Market called");
            _stockTicker.CloseMarket();
        }

        public void Reset()
        {
            Debug.WriteLine("Reset called.");
            _stockTicker.Reset();
        }

        public override Task OnConnected()
        {
            Debug.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            Debug.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            Debug.WriteLine("Hub OnReconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected());
        }
    }
}
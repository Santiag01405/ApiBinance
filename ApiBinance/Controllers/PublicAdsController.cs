using System.Text.Json;
using ApiBinance.Models;
using ApiBinance.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiBinance.Controllers;

public class PublicAdsController : Controller
{
    private readonly BinanceApiClient _binanceClient;

    public PublicAdsController(BinanceApiClient binanceClient)
    {
        _binanceClient = binanceClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string asset = "USDT", string fiat = "VES", string tradeType = "SELL", string? payType = null)
    {
        var request = new PublicAdvSearchRequest
        {
            Asset = asset,
            Fiat = fiat,
            TradeType = tradeType
        };

        if (!string.IsNullOrEmpty(payType))
            request.PayTypes.Add(payType);

        var json = await _binanceClient.GetPublicAdsAsync(request);
        var response = JsonSerializer.Deserialize<PublicAdvSearchResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        var model = new PublicAdsViewModel
        {
            SelectedAsset = asset,
            SelectedFiat = fiat,
            SelectedTradeType = tradeType,
            Assets = new List<string> { "USDT", "BTC", "ETH", "BNB", "DAI" },
            Fiats = new List<string> { "VES", "USD", "EUR", "BRL", "ARS" },
            TradeTypes = new List<string> { "BUY", "SELL" },
            Data = response
        };

        return View("~/Views/Binance/PublicAds.cshtml", model);
    }

}

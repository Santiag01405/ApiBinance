using ApiBinance.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiBinance.Models;

public class OrdersController : Controller
{
    private readonly BinanceApiClient _binanceClient;

    public OrdersController(BinanceApiClient binanceClient)
    {
        _binanceClient = binanceClient;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var json = await _binanceClient.GetUserOrdersAsync();
            var model = JsonSerializer.Deserialize<BinanceUserOrderListResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("~/Views/Orders/Index.cshtml", model);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("~/Views/Orders/Error.cshtml");
        }
    }
}

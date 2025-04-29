using Microsoft.AspNetCore.Mvc;
using ApiBinance.Models;
using ApiBinance.Services;

namespace BinanceAPI.Controllers;

public class BinanceController : Controller
{
    private readonly BinanceApiClient _binanceClient;

    public BinanceController(BinanceApiClient binanceClient)
    {
        _binanceClient = binanceClient;
    }

    // VISTA: Formulario para publicar anuncio
    [HttpGet]
    public IActionResult PostAd()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PostAd(AdPublishRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.PostAdAsync(request);
        ViewBag.Response = result;
        return View("PostAdResult");
    }

    // VISTA: Formulario para actualizar anuncio
    [HttpGet]
    public IActionResult UpdateAd()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAd(AdUpdateRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.UpdateAdAsync(request);
        ViewBag.Response = result;
        return View("UpdateAdResult");
    }

    // VISTA: Formulario para actualizar estado anuncio
    [HttpGet]
    public IActionResult UpdateAdStatus()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAdStatus(AdUpdateStatusRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.UpdateAdStatusAsync(request);
        ViewBag.Response = result;
        return View("UpdateAdStatusResult");
    }

    // VISTA: Formulario para liberar la orden (release coin)
    [HttpGet]
    public IActionResult ReleaseCoin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ReleaseCoin(ReleaseCoinRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.ReleaseCoinAsync(request);
        ViewBag.Response = result;
        return View("ReleaseCoinResult");
    }

    // SECCIONES DE CHAT (pueden quedar como Json)

    [HttpPost]
    public async Task<IActionResult> GetChatImageUploadUrl(ChatImageUrlRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.GetChatImageUploadUrlAsync(request);
        ViewBag.Response = result;
        return View("ChatImageUploadUrlResult");
    }

    [HttpPost]
    public async Task<IActionResult> MarkMessagesRead(MarkMessagesReadRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.MarkMessagesAsReadAsync(request);
        ViewBag.Response = result;
        return View("MarkMessagesReadResult");
    }

    [HttpGet]
    public async Task<IActionResult> GetChatCredentials()
    {
        var result = await _binanceClient.GetChatCredentialsAsync();
        ViewBag.Response = result;
        return View("ChatCredentialsResult");
    }

    [HttpGet]
    public async Task<IActionResult> GetChatMessages(ChatMessagesQueryParams query)
    {
        var result = await _binanceClient.GetChatMessagesPaginatedAsync(query);
        ViewBag.Response = result;
        return View("ChatMessagesResult");
    }

    // Si quieres todavía exponer GetAdDetail como JSON:
    [HttpGet]
    public async Task<IActionResult> GetAdDetail(string adsNo)
    {
        var result = await _binanceClient.GetAdDetailAsync(adsNo);
        return Json(result);
    }
}

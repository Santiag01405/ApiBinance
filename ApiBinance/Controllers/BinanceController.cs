using Microsoft.AspNetCore.Mvc;
using ApiBinance.Models;
using ApiBinance.Services;
using System.Text.Json;

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

    //Publicar anuncio
    [HttpPost]
    public async Task<IActionResult> PostAd(AdPublishRequest request)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Datos inválidos. Verifica el formulario.";
            return View(request);
        }

        try
        {
            var result = await _binanceClient.PostAdAsync(request);
            TempData["Success"] = "Anuncio publicado correctamente.";
            return RedirectToAction("PostAd"); // redirige para evitar reenvío al refrescar 
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al publicar anuncio: {ex.Message}";
            return View(request);
        }

        /*if (!ModelState.IsValid)
            return View(request);

        var result = await _binanceClient.PostAdAsync(request);
        ViewBag.Response = result;
        return View("PostAdResult");*/
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

    //Actualizar estado del anuncio
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

    //Obtener categorias aplicabkes para los anuncios
    [HttpGet]
    public async Task<IActionResult> GetAdCategories()
    {
        try
        {
            var result = await _binanceClient.GetAvailableAdsCategoriesAsync();
            ViewBag.Data = result;
            return View(); 
        }
        catch (InvalidOperationException ex)
        {
            TempData["ErrorMessage"] = "No se puede acceder a las categorías. Requiere un número de teléfono verificado.";
            return RedirectToAction("Index", "Dashboard"); 
        }
    }

    //Obtener lista y filtrado
    /*[HttpGet]
    public async Task<IActionResult> UserOrders()
    {
        var request = new UserOrderListRequest();

        try
        {
            var rawResponse = await _binanceClient.GetUserOrdersAsync(request);

            // Devuelve el contenido crudo como texto plano
            return Content(rawResponse, "application/json");
        }
        catch (Exception ex)
        {
            return Content($"EXCEPCIÓN: {ex.Message}\n\n{ex.StackTrace}", "text/plain");
        }
    }*/

    [HttpGet]
    public async Task<IActionResult> UserOrders()
    {
        var data = await _binanceClient.GetUserOrdersAuthenticatedAsync();
        return View("~/Views/Binance/UserOrders.cshtml", data);

    }
}

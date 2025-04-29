using Microsoft.AspNetCore.Mvc;

namespace ApiBinance.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

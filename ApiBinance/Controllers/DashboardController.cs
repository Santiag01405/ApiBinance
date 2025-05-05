
using ApiBinance.Models;
using ApiBinance.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
﻿using Microsoft.AspNetCore.Mvc;


namespace ApiBinance.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

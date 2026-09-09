using Microsoft.AspNetCore.Mvc;

namespace Vedantu.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}

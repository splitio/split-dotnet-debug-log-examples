using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Splitio.Services.Client.Interfaces;
using SplitLog4netExample_NETCore.Models;
using System.Diagnostics;

namespace SplitLog4netExample_NETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISplitClient _sdk;

        public HomeController(ILogger<HomeController> logger, ISplitInitializer initializer)
        {
            _sdk = initializer.GetSplitClient();
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogDebug("treatment = " + _sdk.GetTreatment("KEY", "sample_feature"));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

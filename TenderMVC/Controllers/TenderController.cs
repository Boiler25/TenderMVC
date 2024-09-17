using Microsoft.AspNetCore.Mvc;
using TenderMVC.Services;

namespace TenderMVC.Controllers
{
    public class TenderController : Controller
    {
        private readonly ITenderApiClient _tenderApiClient;

        public TenderController(ITenderApiClient tenderApiClient)
        {
            _tenderApiClient = tenderApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var tenders = await _tenderApiClient.GetTendersAsync();
            return View(tenders);
        }
    }
}

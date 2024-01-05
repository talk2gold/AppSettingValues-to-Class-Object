using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Test.Models;
using Test.Settings;
using Test.ViewModel;

namespace Test.Controllers
{
    public class HomeController : Controller
    {

        private readonly StripeSettings _stripeSettings;
        private readonly CompanySettings _companySettings;
        public HomeController( IOptions<StripeSettings> stripeSettings,
            IOptions<CompanySettings> companySettings)
        {
            _stripeSettings = stripeSettings.Value;
            _companySettings = companySettings.Value;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.info.Add($"PublicKey : {_stripeSettings.PublicKey}");
            homeVM.info.Add($"SecretKey : {_stripeSettings.SecretKey}");
            homeVM.Company = _companySettings;
            return View(homeVM);
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

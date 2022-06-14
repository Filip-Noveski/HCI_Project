using System.Diagnostics;
using HCI_Project.Classes;
using HCI_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace HCI_Project.Controllers
{
    public class PartialController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _environment;

        private readonly FileAdd _fileAdd;

        private readonly FileGet _fileGet;

        public PartialController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
            _fileAdd = new FileAdd(_environment);
            _fileGet = new FileGet(_environment);
        }

        public IActionResult CheckoutItems([FromForm] IFormCollection data)
        {
            string items = data["itemIds"].ToString();
            List<int> itemIds = new();
            foreach (var item in items.Split("|"))
            {
                bool res = int.TryParse(item, out int val);
                if (res)
                    itemIds.Add(val);
            }
            List<OfferData> offers = SqlGet.OfferData(itemIds.ToArray());
            Dictionary<long, List<string>> files = _fileGet.FilePaths(offers);
            ViewBag.Offers = offers;
            ViewBag.Paths = files;
            ViewBag.TotalPrice = Format.FinalPrice(offers, Currency.Euro);
            return PartialView();
        }
        
        public IActionResult CartItems([FromForm] IFormCollection data)
        {
            string items = data["itemIds"].ToString();
            List<int> itemIds = new();
            foreach (var item in items.Split("|"))
            {
                bool res = int.TryParse(item, out int val);
                if (res)
                    itemIds.Add(val);
            }
            List<OfferData> offers = SqlGet.OfferData(itemIds.ToArray());
            Dictionary<long, List<string>> files = _fileGet.FilePaths(offers);
            ViewBag.Offers = offers;
            ViewBag.Paths = files;
            return PartialView();
        }

        public IActionResult LoadCountries([FromForm] IFormCollection data)
        {
            string continent = data["continent"].ToString();
            if (continent == String.Empty)
            {
                ViewBag.Countries = new Dictionary<string, string>();
                ViewBag.Flags = ViewBag.Countries; // Avoid needless allocation
                return PartialView();
            }
            Dictionary<string, string> countries = _fileGet.Countries(continent);
            Dictionary<string, string> flags = new();
            foreach (var country in countries)
            {
                string path = $"/Countries/flags/{country.Key}.jpg";
                flags.Add(country.Key, path);
            }
            ViewBag.Countries = countries;
            ViewBag.Flags = flags;
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

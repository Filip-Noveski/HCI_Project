using System.Diagnostics;
using HCI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using HCI_Project.Classes;
using Microsoft.AspNetCore.Identity;

namespace HCI_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _environment;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly FileAdd _fileAdd;

        private readonly FileGet _fileGet;

        private readonly int _itemsPerPage = 10;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment, UserManager<IdentityUser> userManager)
        {
            _environment = environment;
            _logger = logger;
            _userManager = userManager;
            _fileAdd = new FileAdd(_environment);
            _fileGet = new FileGet(_environment);
        }

        public IActionResult Index()
        {
            List<OfferData> offers = Format.Shuffle(SqlGet.OfferData());
            ViewBag.Offers = offers.GetRange(0, Math.Min(10, offers.Count));
            ViewBag.Paths = _fileGet.FilePaths(ViewBag.Offers);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TermsConditions()
        {
            return View();
        }

        public IActionResult Offers(List<OfferData> offerData, Dictionary<long, List<string>> paths)
        {
            ViewBag.OfferData = offerData;
            ViewBag.Paths = paths;
            return View();
        }

        public IActionResult OffersAll(int? page)
        {
            page ??= 1;
            int index = _itemsPerPage * ((int)page - 1);

            List<OfferData> offerData = SqlGet.OfferData();
            int itemsPerPage = Math.Min(_itemsPerPage, offerData.Count - index);
            int pagesCount = (int)Math.Ceiling(offerData.Count / (float)_itemsPerPage);

            offerData = offerData.GetRange(index, itemsPerPage);
            Dictionary<long, List<string>> paths = _fileGet.FilePaths(offerData);

            ViewBag.OfferData = offerData;
            ViewBag.Paths = paths;
            ViewBag.Page = page;
            ViewBag.PagesCount = pagesCount;
            ViewBag.JS = "location.href = '/Home/OffersAll?page=@page'";
            return View();
        }
        
        public IActionResult OffersSearch(SearchData data, int? page)
        {
            data.Format();
            Dictionary<string, string> searchData = new();
            searchData["Brand:"] = data.Brand ?? string.Empty;
            searchData["Name:"] = data.Name ?? string.Empty;
            searchData["Part type:"] = Format.PartType(data.Type);
            searchData["Price range:"] = Format.PriceRange(data.Currency, data.PriceRange);
            ViewData["search-data"] = searchData;

            page ??= 1;
            int index = _itemsPerPage * ((int)page - 1);

            List<OfferData> offerData = SqlGet.OfferData(data);
            int itemsPerPage = Math.Min(_itemsPerPage, offerData.Count - index);
            int pagesCount = (int)Math.Ceiling(offerData.Count / (float)_itemsPerPage);

            offerData = offerData.GetRange(index, itemsPerPage);
            Dictionary<long, List<string>> paths = _fileGet.FilePaths(offerData);

            ViewBag.SearchData = data;
            ViewBag.OfferData = offerData;
            ViewBag.Paths = paths;
            ViewBag.Page = page;
            ViewBag.PagesCount = pagesCount;
            ViewBag.JS = Format.GetJavascriptSearch(data);
            return View();
        }

        public IActionResult Offer(int offerId)
        {
            ViewBag.WebRootPath = _environment.WebRootPath;
            OfferData offerData = SqlGet.OfferData(offerId);
            ViewData["offer-data"] = offerData;
            ViewData["offer-paths"] = _fileGet.FilePaths(offerData);
            string userId = _userManager.GetUserId(HttpContext.User);
            ViewBag.IsByUser = userId == offerData.UserId; // Whether offer is by logged in user

            // Offers and paths are used for ads
            List<OfferData> offers = Format.Shuffle(SqlGet.OfferData());
            ViewBag.Offers = offers.GetRange(0, Math.Min(10, offers.Count));
            ViewBag.Paths = _fileGet.FilePaths(ViewBag.Offers);

            return View();
        }

        public IActionResult Checkout(string item)
        {
            ViewBag.Item = item;
            return View();
        }

        public IActionResult Pay()
        {
            return View();
        }

        public IActionResult PayResult(string res)
        {
            ViewBag.Result = res;
            return View();
        }

        [Authorize]
        public IActionResult AddOffer()
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
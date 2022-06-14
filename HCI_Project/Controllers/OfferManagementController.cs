using Microsoft.AspNetCore.Mvc;
using HCI_Project.Classes;
using Microsoft.AspNetCore.Identity;
using HCI_Project.Models;

namespace HCI_Project.Controllers
{
    public class OfferManagementController : Controller
    {
        private readonly ILogger<OfferManagementController> _logger;

        private readonly IWebHostEnvironment _environment;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly FileAdd _fileAdd;

        private readonly FileGet _fileGet;

        public OfferManagementController(ILogger<OfferManagementController> logger, IWebHostEnvironment environment, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _environment = environment;
            _logger = logger;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _fileAdd = new FileAdd(_environment);
            _fileGet = new FileGet(_environment);
        }

        [HttpPost]
        public async Task<JsonResult> AddEntry([FromForm] IFormCollection data)
        {
            Dictionary<string, string> info = new();
            Dictionary<string, IFormFile> files = new();
            foreach (var item in data)
            {
                info.Add(item.Key, item.Value);
            }
            foreach (var file in data.Files)
            {
                files.Add(file.Name, file);
            }

            info.Add("seller", _userManager.GetUserId(HttpContext.User));
            info.Add("time", DateTime.Now.ToString());

            await SqlAdd.OfferEntry(info);
            int offerId = SqlGet.OfferId(Convert.ToDateTime(info["time"]), info["seller"]);
            await _fileAdd.OfferFiles(files, info["description"], offerId);

            return Json("Success! Well, hopefully...");
        }

        [HttpPost]
        public JsonResult RemoveEntry([FromForm] IFormCollection data)
        {
            string offerId = data["offer-id"];

            SqlRemove.Offer(offerId);

            return Json("Success! Well, hopefully...");
        }
    }
}

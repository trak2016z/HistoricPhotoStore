using HistoricPhotoStore;
using HistoricPhotoStore.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HistoricPhotoStore.Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly HistoricPhotoStoreService historicPhotoStoreService;
        private readonly PathHelper pathHelper;

        public HomeController(HistoricPhotoStoreService historicPhotoStoreService, PathHelper pathHelper)
        {
            this.historicPhotoStoreService = historicPhotoStoreService;
            this.pathHelper = pathHelper;
        }
        // GET: Home
        public ViewResult Index()
        {
            var images = historicPhotoStoreService.GetImages();

            return View(images.Select(x => x.ToString()));
        }

        public FileContentResult Image(string guid)
        {
            var imageData = historicPhotoStoreService
                .GetImageDataForID(pathHelper.RootDirectoryPath, new Guid(guid));

            return File(imageData, "image/jpeg");
        }
    }
}
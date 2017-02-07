using HistoricPhotoStore;
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

        public HomeController(HistoricPhotoStoreService historicPhotoStoreService)
        {
            this.historicPhotoStoreService = historicPhotoStoreService;
        }
        // GET: Home
        public ViewResult Index()
        {
            var images = historicPhotoStoreService.GetImages();

            return View(images.Select(x => x.ToString()));
        }
    }
}
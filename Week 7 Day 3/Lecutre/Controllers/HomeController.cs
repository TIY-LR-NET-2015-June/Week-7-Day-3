using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Lecutre.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lecutre.Controllers
{
    public class HomeController : Controller
    {
        StuffDbContext db = new StuffDbContext();

        public ActionResult Movies()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var jsonString = webClient.DownloadString("https://raw.githubusercontent.com/TIY-LR-NET-2015-June/Week-7-Day-2/master/movies.json");

                var result = JsonConvert.DeserializeObject<RootObject>(jsonString);

                var shittiestMovie = result.movies.OrderBy(x => x.ratings.critics_score).FirstOrDefault();
                return Json(shittiestMovie,JsonRequestBehavior.AllowGet);
            }


        }



        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(StuffVM stuffVm)
        {
            Guid id;
            using (var ms = new MemoryStream())
            {
                stuffVm.UploadedFile.InputStream.CopyTo(ms);

                var pi = new PeopleImage
                {
                    TheirName = stuffVm.YourName,
                    Image = PeopleImage.ResizeImage(ms.ToArray(), 50, 50),
                };
                db.PeopleImages.Add(pi);
                db.SaveChanges();

                id = pi.Id;
            }


            var image = db.PeopleImages.Find(id);
            return File(image.Image, "image");

        }

    }

}

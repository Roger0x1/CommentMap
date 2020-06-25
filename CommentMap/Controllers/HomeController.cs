using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommentMap.Models;
using CommentMap.Data;

namespace CommentMap.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string lat = "32.081", string lng= "-81.09", int zoom=18)
        {
            MapViewModel Model = new MapViewModel();
            Model.lat = lat;
            Model.lng = lng;
            Model.zoom = zoom;             
            return View(Model);
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

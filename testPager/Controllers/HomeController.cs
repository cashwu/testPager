using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testPager.Models;
using X.PagedList;

namespace testPager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page)
        {
            var data = GetData();

            var pageNumber = page ?? 1;

            ViewBag.Data = data.ToPagedList(pageNumber, 20);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private List<Profile> GetData()
        {
            return Enumerable.Range(1, 100).Select(a => new Profile(a)).ToList();
        }
    }

    public class Profile
    {
        public Profile(int id)
        {
            Id = id;
            Name = Guid.NewGuid().ToString();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
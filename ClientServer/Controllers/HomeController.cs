using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientServer.Models;

namespace ClientServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly Microminer _microminer;

        public HomeController()
        {
            _microminer = new Microminer();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetSearchData(string input)
        {
            // store input
            _microminer.SetInput(input);

            // redirect to search page
            return View("Search");
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetSearchResults(string input)
        {
            var result = new MicrominerResults()
            {
                Alphabetized = _microminer.GetAlphabetized(),
                CircularlyShifted = _microminer.GetCircularlyShifted(),
                SearchResult = _microminer.GetMatches(input),
                UserInput = _microminer.GetOriginalInput()

            };

            return View("Search", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

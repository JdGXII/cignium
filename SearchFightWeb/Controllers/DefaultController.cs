using ApiClients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightWeb.Controllers
{
    public class DefaultController : Controller
    {
        private IGoogleClient _googleClient;
        public DefaultController(IGoogleClient googleClient)
        {
            _googleClient = googleClient;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _googleClient.GetResults();
            ViewBag.Results = results.Queries.Request.First().TotalResults;

            return View();
        }
    }
}

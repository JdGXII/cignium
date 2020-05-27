using ApiClients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightWeb.Controllers
{
    public class DefaultController : Controller
    {
        private ISearchService _queryService;
        public DefaultController(ISearchService queryService)
        {
            _queryService = queryService;
        }

        public async Task<IActionResult> Index()
        {
            _queryService.SearchQueries = new List<string>() { "php", "java 8 help" };
            var temp = await _queryService.PerformGoogleSearch();

            return View();
        }
    }
}

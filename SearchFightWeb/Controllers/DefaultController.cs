﻿using ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
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
            try
            {
                _queryService.SearchQueries = new List<string>() { "php", "java 8 help" };
                var temp = await _queryService.PerformGoogleSearch();
                var temp2 = await _queryService.PerformBingSearch();
            }
            catch (EmptyQueryException e)
            {
                ViewBag.Error = e.Message;
            }

            return View();
        }
    }
}

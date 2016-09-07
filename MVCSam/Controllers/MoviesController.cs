﻿using MVCSam.Models;
using MVCSam.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCSam.Controllers
{
    public class MoviesController : Controller
    {
        private string sortBy;
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("movieId = " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            this.sortBy = sortBy;
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";
            return Content(string.Format("pageid={0}&sortby={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Booked.Logic.Services;
using Booked.Logic.BOs;

namespace BookEd.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly CategoryService _catService;
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;


        public HomeController()
        {
            _catService = new CategoryService();
            _bookService = new BookService();
            _authorService = new AuthorService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }

    }
}
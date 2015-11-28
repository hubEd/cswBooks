using Booked.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookEd.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAuthors()
        {
            var data = _authorService.GetAll();
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
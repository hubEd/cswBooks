using Booked.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookEd.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _catService;

        public CategoryController()
        {
            _catService = new CategoryService();
        }
        // GET: Category
        public ActionResult GetCategories()
        {
            var data = _catService.GetAll();
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
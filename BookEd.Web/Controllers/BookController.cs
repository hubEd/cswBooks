using Booked.Logic.BOs;
using Booked.Logic.Services;
using BookEd.Transfer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookEd.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }
        // GET: Book
        public ActionResult GetBooks(BookFilter filter)
        {
            var data = _bookService.GetByFilter(1, filter);
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult GetBooksByCategory(string category)
        {
            var data = _bookService.GetByCategory(category);
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult GetBooksByAuthor(string author)
        {
            var data = _bookService.GetByAuthor(author);
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult SaveBook(BookModel book)
        {
            var msg = "Book was save";
            try
            {
                _bookService.SaveBook(book);
            }
            catch
            {
                msg = "Error";
            }
            return new JsonResult
            {
                Data = msg,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


    }
}
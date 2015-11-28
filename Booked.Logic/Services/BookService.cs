using Booked.Logic.BOs;
using Book.Data;
using BookEd.Transfer.DTOs;
using BookEd.Transfer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked.Logic.Services
{
    public class BookService : BaseService
    {
        private List<BookModel> multiResult;
        private BookModel singleResult;

        public BookService() : base() { }

        public BookModel GetBookById(int bookId)
        {
            singleResult = _rep.GetSingle<BookModel, Book.Data.Book>(x => x.BookId == bookId);
            return singleResult;
        }

        public List<BookModel> GetBooks()
        {
            multiResult = _rep.GetAll<BookModel, Book.Data.Book>();
            return multiResult;
        }

        public List<BookModel> GetByFilter(int userId, BookFilter filter)
        {
            if(filter.AuthorId == 0 && filter.CategoryId == 0)
                multiResult = _rep.GetAll<BookModel, Book.Data.Book>();
            else if(filter.AuthorId == 0)
                multiResult = _rep.GetAll<BookModel, Book.Data.Book>(x => x.CategoryId == filter.CategoryId);
            else if(filter.CategoryId == 0)
                multiResult = _rep.GetAll<BookModel, Book.Data.Book>(x => x.AuthorId == filter.AuthorId);
            else
                multiResult = _rep.GetAll<BookModel, Book.Data.Book>(x => x.AuthorId == filter.AuthorId && x.CategoryId == filter.CategoryId);
            return multiResult;
        }

        public List<BookModel> GetByCategory(string category)
        {
            multiResult = _rep.GetAll<BookModel, Book.Data.Book>(x => x.Category.Name == category);
            return multiResult;
        }

        public List<BookModel> GetByAuthor(string author)
        {
            multiResult = _rep.GetAll<BookModel, Book.Data.Book>(x => x.Author.Name == author);
            return multiResult;
        }

        public bool SaveBook(BookModel book)
        {
            try
            {
                _rep.Add<BookModel, Book.Data.Book>(book);
                return true;
            }
            catch
            {
         
                return false;
            }
        }

    }
}

//using BookEd.Data;
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
    public class AuthorService : BaseService
    {
        private List<AuthorModel> multiResult;
        private AuthorModel singleResult;

        public AuthorService() : base() { }

        public List<AuthorModel> GetAll()
        {
            multiResult = _rep.GetAll<AuthorModel, Author>();
            return multiResult;
        }
    }
}

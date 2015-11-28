using BookEd.Transfer.DTOs;
using BookEd.Transfer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Data;

namespace Booked.Logic.Services
{
    public class CategoryService : BaseService
    {
        private List<CategoryModel> multiResult;
        private CategoryModel singleResult;

        public CategoryService() : base() { }

        public List<CategoryModel> GetAll()
        {
            multiResult = _rep.GetAll<CategoryModel, Category>();
            return multiResult;
        }
    }
}

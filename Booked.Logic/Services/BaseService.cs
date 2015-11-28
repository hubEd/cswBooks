using BookEd.Transfer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked.Logic.Services
{
    public class BaseService
    {
        protected MasterRepository _rep;

        public BaseService()
        {
            _rep = new MasterRepository();
        }
    }
}

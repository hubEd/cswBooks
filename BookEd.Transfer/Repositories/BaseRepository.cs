//using BookEd.Data;
using Book.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEd.Transfer.Repositories
{
    public class BaseRepository : IDisposable
    {
        public BookscswEntities Context { get; set; }
        public BaseRepository()
        {
            Context = new BookscswEntities();
        }
        public BaseRepository(string environment)
        {
            Context = new BookscswEntities(environment);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Context.Dispose();
        }
    }
}

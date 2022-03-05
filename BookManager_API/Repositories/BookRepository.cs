using BookManager_API.Abstracts.IRepositoryEntities;
using BookManager_API.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookManager_API.Repositories
{
    class BookRepository : GenericRepository<Book, string> , IBookRepository 
    {
        public BookRepository(DbContext db) : base(db)
        {
            
        }
    }
}

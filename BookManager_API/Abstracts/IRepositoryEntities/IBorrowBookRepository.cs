using BookManager_API.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_API.Abstracts.IRepositoryEntities
{
    public interface IBorrowBookRepository : IRepository<BorrowBook, int>
    {

    }
}

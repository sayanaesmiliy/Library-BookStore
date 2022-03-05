using BookManager_API.Abstracts.IRepositoryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_API.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
    }
}

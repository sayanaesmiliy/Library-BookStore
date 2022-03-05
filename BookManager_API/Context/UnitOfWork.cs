using BookManager_API.Abstracts;
using BookManager_API.Abstracts.IRepositoryEntities;
using BookManager_API.DataModel;
using BookManager_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_API.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBookRepository _bookRepostiory;
        public IBookRepository Books { get { return _bookRepostiory ?? new BookRepository(_db); } }

        private ICategoryRepository _categoryRepostiory;
        public ICategoryRepository Categories { get { return _categoryRepostiory ?? new CategoryRepository(_db); } }

        private readonly BookCityDatabaseEntities _db;
        public UnitOfWork()
        {
            _db = new BookCityDatabaseEntities();
        }

        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

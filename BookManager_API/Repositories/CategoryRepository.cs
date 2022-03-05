using BookManager_API.Abstracts.IRepositoryEntities;
using BookManager_API.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_API.Repositories
{
    class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
            
        }
    }
}

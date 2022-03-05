﻿using BookManager_API.Abstracts.IRepositoryEntities;
using BookManager_API.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_API.Repositories
{
    public class BorrowBookRepository : GenericRepository<BorrowBook, int>, IBorrowBookRepository
    {
        public BorrowBookRepository(DbContext db) : base(db)
        {

        }

    }
}

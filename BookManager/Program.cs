using BookManager_API.Abstracts;
using BookManager_API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IUnitOfWork db = new UnitOfWork())
            {
                var a = db.Categories.GetAll();

                var cat = new BookManager_API.DataModel.Category()
                {
                    ID = 1325123,
                    Collection = "علمی"
                };
                db.Categories.Add(cat);

                db.Commit();
            }
        }
    }
}

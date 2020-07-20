﻿using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class CategoryRepository : RepositoryBase<Category>
    {
        //private MyFinanceContext _dbContext = new MyFinanceContext();

        private DatabaseFactory _db = new DatabaseFactory();
        public CategoryRepository(DatabaseFactory db)
            : base(db)
        {
            //dbContext =  new MyFinanceContext();
            _db = db;
        }
    }
    
}

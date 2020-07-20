using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data;
using Data.Infrastructure;
using Data.Repositories;

namespace Service
{
    public class ServiceProduct : EntityService<Product>
    {
        static IUnitOfWork Uok = new UnitOfWork();

        public ServiceProduct(): base()
        {

        }

        public IEnumerable<Product> GetProductByName(string Name)
        {
            return unitofwork.GetRepository<Product>().GetAll().Where(m => m.Name.ToString().ToLower().Contains(Name));
        }
        //public ServiceProduct()
        //{
        //      utOfWork = new UnitOfWork(FinancedataContext);
        //}

        //public Product GetById(int Id) {
        //    return _utOfWork.GetRepository<Product>().GetById(Id);
        //}

       public static IEnumerable<Product> GetAll()
      {
           return Uok.GetRepository<Product>().GetAll();

       }

    }
}

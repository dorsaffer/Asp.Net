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
    public class ServiceCategory: EntityService<Category>
    {
         static IUnitOfWork Uok = new UnitOfWork();

        public ServiceCategory (): base()
        {
           
        }

        public IEnumerable<Category> GetProductByName(string Name)
        {
            return unitofwork.GetRepository<Category>().GetAll().Where(m => m.Name.ToString().ToLower().Contains(Name));
        }
        //public ServiceProduct()
        //{
        //      utOfWork = new UnitOfWork(FinancedataContext);
        //}

        //public Product GetById(int Id) {
        //    return _utOfWork.GetRepository<Product>().GetById(Id);
        //}

       public static IEnumerable<Category> GetAll()
        {
           return Uok.GetRepository<Category>().GetAll();

      }

    }
}

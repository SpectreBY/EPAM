using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6ORM.Interfaces
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}

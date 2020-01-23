using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6ORM.Models;

namespace Task6ORM.Interfaces
{
    interface IService
    {
        List<BaseModel> GetAll();
        BaseModel GetById(int id);
        void Create(BaseModel model);
        void Update(BaseModel model);
        void Delete(int id);
        int GetUniqueKey(string tableName);
    }
}

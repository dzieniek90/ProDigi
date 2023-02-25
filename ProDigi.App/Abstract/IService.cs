using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAll();
        int GetLastId();
        T GetById(int id);
        int Add(T item);
        int Update(T item);
        void Remove(T item);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookService<T>
    {
        void Add(T value);
        List<T> GetAll();
        List <T> Find(T book);

        void Delete(T value);
    }
}

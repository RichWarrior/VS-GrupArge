using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExample.Interfaces
{
    public interface IDatabase
    {
        //Senkron
        bool writeData(object data);
        List<T> getData<T>();

        //Asenkron
        Task<bool> writeDataAsync(object data);
        Task<List<T>> getDataAsync<T>();
    }
}

using System.Collections.Generic;

namespace DbExample.Interfaces
{
    public interface IDatabase
    {
        bool writeData(object data);

        List<T> getData<T>();

        void readData<T>();
    }
}

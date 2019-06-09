using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTree2.Interfaces
{
    public interface IFileService<T>
    {
        T Open(string filename);
        void Save(string filename, T xmlObject);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTree2.Interfaces
{
    public interface IGetData<T>
    {
        T GetData(string folder);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTree2.Models;

namespace testTree2.Interfaces
{
    public interface IMakeRect <T>
    {
        T GetRect(List<ItemModel> itemModels);
    }
}

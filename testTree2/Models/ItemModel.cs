using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTree2.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string ItemValue { get; set; }
        public List<ItemModel> ItemList { get; set; }
    }
}

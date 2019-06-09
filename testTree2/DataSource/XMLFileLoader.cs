using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTree2.Interfaces;
using testTree2.Models;

namespace testTree2.DataSource
{
    public class XMLFileLoader : IFileService<List<ItemModel>>
    {
        private IGetData<List<ItemModel>> DataSource;
        public XMLFileLoader(IGetData<List<ItemModel>> DataSource)
        {
            this.DataSource = DataSource;
        }
        public List<ItemModel> Open(string filename)
        {
            return DataSource.GetData(filename);
        }

        public void Save(string filename, List<ItemModel> xmlObject)
        {
            throw new NotImplementedException();
        }
    }
}

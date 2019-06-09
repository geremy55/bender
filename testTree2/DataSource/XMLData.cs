using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using testTree2.Interfaces;
using testTree2.Models;

namespace testTree2.DataSource
{
    public class XMLData : IGetData<List<ItemModel>>
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public List<ItemModel> GetData(string folder)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(folder);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show("Error! Try to open file again.");
            }

            return new  List<ItemModel> { GetNode(xDoc.DocumentElement)};
        }

        private ItemModel GetNode(XmlNode node)
        {            
            ItemModel Item = new ItemModel();
            Item.Name = node.Name;
            var attrs = node.Attributes;
            if (attrs != null)
            {
                Item.ItemList = new List<ItemModel>();               

                for (int i = 0; i < attrs.Count; i++)
                {
                    if (Item.Name == "folding" && (attrs[i].Name != "rootX" && attrs[i].Name != "rootY"
                        && attrs[i].Name != "originalDocumentWidth" && attrs[i].Name != "originalDocumentHeight")) continue;                                           
                   
                    Item.ItemList.Add(new ItemModel { Name = attrs[i].Name, ItemValue = attrs[i].Value });
                }

            }            

            if (node.HasChildNodes)
            {
                if (Item.ItemList == null) Item.ItemList = new List<ItemModel>();
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    Item.ItemList.Add(GetNode(childnode));
                }
            }
            return Item;
        }
    }
}

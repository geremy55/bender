using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTree2.Enums;
using testTree2.Interfaces;
using testTree2.Models;

namespace testTree2.Services
{
    public class MakeRect: IMakeRect<RectModel>
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private ICalculateRect<RectModel> calculate;
        private readonly double scale = 1.5;
        public MakeRect(ICalculateRect<RectModel> calculate)
        {           
            this.calculate = calculate;
        }

        public RectModel GetRect(List<ItemModel> itemModels)
        {
            RectModel fstRect=null;
            try
            {
                var item = itemModels.FirstOrDefault(i => i.Name == "folding");
                fstRect = CalculateRect(item.ItemList.FirstOrDefault(x => x.Name == "panels").ItemList.FirstOrDefault());
                fstRect.X = double.Parse(item.ItemList.FirstOrDefault(x => x.Name == "rootX").ItemValue) / scale;
                fstRect.Y = double.Parse(item.ItemList.FirstOrDefault(y => y.Name == "rootY").ItemValue) / scale;                
            }            
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }
            calculate.Calculate(fstRect);

            return fstRect;
        }

        private RectModel CalculateRect(ItemModel item)
        {
            RectModel rectModel = null;
            try
            {
                rectModel = new RectModel
                {
                    Height = double.Parse(item.ItemList.FirstOrDefault(h => h.Name == "panelHeight").ItemValue) / scale,
                    Width = double.Parse(item.ItemList.FirstOrDefault(w => w.Name == "panelWidth").ItemValue) / scale,
                    Side = int.Parse(item.ItemList.FirstOrDefault(w => w.Name == "attachedToSide").ItemValue),
                    offSet = double.Parse(item.ItemList.FirstOrDefault(o => o.Name == "hingeOffset").ItemValue) / scale
                };

                var attList = item.ItemList.FirstOrDefault(a => a.Name == "attachedPanels");
                if (attList != null)
                {
                    rectModel.RectList = new List<RectModel>();
                    foreach (var atItem in attList.ItemList)
                    {
                        rectModel.RectList.Add(CalculateRect(atItem));
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }
            return rectModel;
        }
    }
}

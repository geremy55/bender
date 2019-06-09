using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTree2.Enums;

namespace testTree2.Models
{
    public class RectModel
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public int Side { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double offSet { get; set; }
        public RectSideEnum Position { get; set; } = RectSideEnum.bottom;
        public List<RectModel> RectList { get; set; }
    }
}

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
    public class CalculateRect : ICalculateRect<RectModel>
    {

        public void Calculate(RectModel RectList)
        {
            if (RectList == null) return;
            CalcPosition(RectList);            
        }

        private void CalcPosition(RectModel ParentRect)
        {
            
            if (ParentRect.RectList != null)
            {
                for (int i = 0; i < ParentRect.RectList.Count; i++)
                {
                    var item = ParentRect.RectList[i];
                    switch (item.Side)
                    {
                        case 0:
                            {
                                switch (ParentRect.Position)
                                {
                                    case RectSideEnum.bottom:
                                        {
                                            item.Position = RectSideEnum.top;
                                            item.X = ParentRect.X + ParentRect.Width / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y + ParentRect.Height;
                                        }
                                        break;
                                    case RectSideEnum.right:
                                        {
                                            item.Position = RectSideEnum.left;
                                            item.X = ParentRect.X + ParentRect.Height;
                                            item.Y = ParentRect.Y + ParentRect.Width / 2 - item.Width / 2 + item.offSet;                                            
                                        }
                                        break;
                                    case RectSideEnum.top:
                                        {
                                            item.Position = RectSideEnum.bottom;
                                            item.X = ParentRect.X + ParentRect.Width / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y - item.Height;
                                        }
                                        break;
                                    case RectSideEnum.left:
                                        {
                                            item.Position = RectSideEnum.right;
                                            item.X = ParentRect.X - item.Height;
                                            item.Y = ParentRect.Y + ParentRect.Width / 2 - item.Width / 2 + item.offSet;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 1:
                            {  
                                switch (ParentRect.Position)
                                {
                                    case RectSideEnum.bottom:
                                        {
                                            item.Position = RectSideEnum.left;
                                            item.X = ParentRect.X + ParentRect.Width;
                                            item.Y = ParentRect.Y + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                        }
                                        break;
                                    case RectSideEnum.right:
                                        {
                                            item.Position = RectSideEnum.bottom;
                                            item.X = ParentRect.X + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y - item.Height;
                                        }
                                        break;
                                    case RectSideEnum.top:
                                        {
                                            item.Position = RectSideEnum.left;
                                            item.X = ParentRect.X - item.Height;
                                            item.Y = ParentRect.Y + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                        }
                                        break;
                                    case RectSideEnum.left:
                                        {
                                            item.Position = RectSideEnum.top;
                                            item.X = ParentRect.X + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y + ParentRect.Width;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 2:
                            {
                                switch (ParentRect.Position)
                                {
                                    case RectSideEnum.bottom:
                                        {
                                            item.Position = RectSideEnum.bottom;
                                            item.X = ParentRect.X - ParentRect.Width / 2 + item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y - item.Height;
                                        }
                                        break;
                                    case RectSideEnum.right:
                                        {
                                            item.Position = RectSideEnum.right;
                                            item.X = ParentRect.X - item.Height;
                                            item.Y = ParentRect.Y + ParentRect.Width / 2 - item.Width / 2 + item.offSet;
                                        }
                                        break;
                                    case RectSideEnum.top:
                                        {
                                            item.Position = RectSideEnum.top;
                                            item.X = ParentRect.X + ParentRect.Width / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y + ParentRect.Height;
                                        }
                                        break;
                                    case RectSideEnum.left:
                                        {
                                            item.Position = RectSideEnum.left;
                                            item.X = ParentRect.X + ParentRect.Height;
                                            item.Y = ParentRect.Y + ParentRect.Width / 2 - item.Width / 2 + item.offSet;
                                        }
                                        break;
                                }
                            }
                            break;
                        case 3:
                            {                               

                                switch (ParentRect.Position)
                                {
                                    case RectSideEnum.bottom:
                                        {
                                            item.Position = RectSideEnum.right;
                                            item.X = ParentRect.X - item.Height;
                                            item.Y = ParentRect.Y + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                        }
                                        break;
                                    case RectSideEnum.right:
                                        {
                                            item.Position = RectSideEnum.top;
                                            item.X = ParentRect.X + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y + ParentRect.Width;
                                        }
                                        break;
                                    case RectSideEnum.top:
                                        {
                                            item.Position = RectSideEnum.left;
                                            item.X = ParentRect.X + ParentRect.Width;
                                            item.Y = ParentRect.Y + ParentRect.Height / 2 - item.Height / 2 + item.offSet;
                                        }
                                        break;
                                    case RectSideEnum.left:
                                        {
                                            item.Position = RectSideEnum.bottom;
                                            item.X = ParentRect.X + ParentRect.Height / 2 - item.Width / 2 + item.offSet;
                                            item.Y = ParentRect.Y - item.Height;
                                        }
                                        break;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    if (item.RectList != null)
                    {
                        CalcPosition(item);
                    }
                }
            }
        }
    }
}

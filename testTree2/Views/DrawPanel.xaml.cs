
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using testTree2.Enums;
using testTree2.Models;
using testTree2.ViewModels;

namespace testTree2.Views
{
    /// <summary>
    /// Interaction logic for DrawPanel.xaml
    /// </summary>
    public partial class DrawPanel : UserControl
    {
        public static event EventHandler<Canvas> OnGetData;
        public DrawPanel()
        {
            InitializeComponent();
            DrawPanelViewModel.OnGetData += DrawPanelViewModel_OnGetData;
        }

        private void DrawPanelViewModel_OnGetData(object sender, RectModel e)
        {
            MyCanvas.Children.Clear();
            DrawRects(e);
            OnGetData?.Invoke(this, this.MyCanvas);
        }

        private void DrawRects(RectModel model)
        {
            var height = model.Height;
            var width = model.Width;

            var myRect = new Rectangle
            {
                Stroke = Brushes.Black,
                Height = model.Position == RectSideEnum.bottom || model.Position == RectSideEnum.top ? height : width,
                Width = model.Position == RectSideEnum.bottom || model.Position == RectSideEnum.top ? width : height
            };           
           
            Canvas.SetLeft(myRect, model.X);
            Canvas.SetTop(myRect, model.Y);
            MyCanvas.Children.Add(myRect);

            if (model.RectList != null)
            {
                for (int i = 0; i < model.RectList.Count; i++)
                {
                    DrawRects(model.RectList[i]);
                }
            }

        }
    }
}

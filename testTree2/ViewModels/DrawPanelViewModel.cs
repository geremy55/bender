using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using testTree2.Interfaces;
using testTree2.Models;
using testTree2.Services;

namespace testTree2.ViewModels
{
    public class DrawPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private double myheight;
        public double myHeight
        {
            get => myheight;
            set
            {
                myheight = value;
                OnPropertyChanged("myHeight");
            }
        }

        private double mywidth;
        public double myWidth
        {
            get => mywidth;
            set
            {
                mywidth = value;
                OnPropertyChanged("myWidth");
            }
        }

        private RectModel Rects;
        IMakeRect<RectModel> makeRect;
        public static event EventHandler<RectModel> OnGetData;

        public DrawPanelViewModel(IMakeRect<RectModel> makeRect)
        {
            this.makeRect = makeRect;
            MainViewModel.OnGetData += MainViewModel_OnGetData;
        }

        private void MainViewModel_OnGetData(object sender, List<ItemModel> e)
        {
            try
            {
                myHeight = double.Parse(e.FirstOrDefault(f => f.Name == "folding").ItemList.FirstOrDefault(i => i.Name == "originalDocumentHeight").ItemValue);
                myWidth = double.Parse(e.FirstOrDefault(f => f.Name == "folding").ItemList.FirstOrDefault(i => i.Name == "originalDocumentWidth").ItemValue);
                Rects = makeRect.GetRect(e);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }
            OnGetData?.Invoke(this, Rects);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

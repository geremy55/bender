using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using testTree2.Helpers;
using testTree2.Interfaces;
using testTree2.Models;
using testTree2.Views;


namespace testTree2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static event EventHandler<List<ItemModel>> OnGetData;

        private IFileService<List<ItemModel>> fileService;
        private IFileService<Visual> pictureService;
        private IDialogService dialogService;
        private Canvas myCanvas;

        public MainViewModel(IFileService<List<ItemModel>> fileService, IFileService<Visual> pictureService, IDialogService dialogService)
        {
            this.fileService = fileService;
            this.pictureService = pictureService;
            this.dialogService = dialogService;            
            DrawPanel.OnGetData += DrawPanel_OnGetData;
        }

        private void DrawPanel_OnGetData(object sender, Canvas e)
        {
            myCanvas=e;
        }

        private RelayCommand openFileCommand;
        public RelayCommand OpenFileCommand
        {
            get
            {
                return openFileCommand ??
                  (openFileCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog("XML file (*.xml)|*.xml") == true)
                          {
                              var folding = fileService.Open(dialogService.FilePath);
                              OnGetData?.Invoke(this, folding);
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand savePictureCommand;
        public RelayCommand SavePictureCommand
        {
            get
            {
                return savePictureCommand ??
                  (savePictureCommand = new RelayCommand(obj =>
                  {
                      if (myCanvas!=null)
                      {
                          try
                          {
                              if (dialogService.SaveFileDialog("Image (*.jpg)|*.jpg") ==true)
                              {
                                  pictureService.Save(dialogService.FilePath, myCanvas);                                  
                              }
                          }
                          catch (Exception ex)
                          {
                              dialogService.ShowMessage(ex.Message);
                          }
                      }

                  }));
            }
        }

        private RelayCommand closeAppCommand;
        public RelayCommand CloseAppCommand
        {
            get
            {
                return closeAppCommand ??
                  (closeAppCommand = new RelayCommand(obj =>
                  {
                      Application.Current.Shutdown();
                  }));
            }
        }



        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

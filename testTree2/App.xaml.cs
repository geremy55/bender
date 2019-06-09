using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using testTree2.DataSource;
using testTree2.Helpers;
using testTree2.Interfaces;
using testTree2.Models;
using testTree2.Services;
using testTree2.ViewModels;

namespace testTree2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IDialogService>().To<FileDialogService>();
            kernel.Bind<IFileService<List<ItemModel>>>().To<XMLFileLoader>();
            kernel.Bind<IGetData<List<ItemModel>>>().To<XMLData>();
            kernel.Bind<ICalculateRect<RectModel>>().To<CalculateRect>();
            kernel.Bind<IMakeRect<RectModel>>().To<MakeRect>();
            kernel.Bind<IFileService<Visual>>().To<PictureSaver>();

            MainWindow mainView = new MainWindow();
            MainViewModel appVM = kernel.Get<MainViewModel>();                       
            mainView.DataContext = appVM;
            LeftPanelViewModel left = kernel.Get<LeftPanelViewModel>();
            mainView.leftPanel.DataContext = left;            
            DrawPanelViewModel drawPanel = kernel.Get<DrawPanelViewModel>();
            mainView.drawPanel.DataContext = drawPanel;
            mainView.Show();
        }
    }
}

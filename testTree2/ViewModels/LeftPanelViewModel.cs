using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using testTree2.Interfaces;
using testTree2.Models;

namespace testTree2.ViewModels
{
    public class LeftPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;        

        private ObservableCollection<TreeViewItem> _folding;
        public ObservableCollection<TreeViewItem> Folding
        {
            get => _folding;
            set
            {
                _folding = value;
                OnPropertyChanged("Folding");
            }
        }

        public LeftPanelViewModel()
        {            
            MainViewModel.OnGetData += Model_OnGetData;           
        }

        private void Model_OnGetData(object sender, List<ItemModel> e)
        {           
            ListDirectory(e);
        }

        private void ListDirectory(List<ItemModel> Model)
        {
            Folding = new ObservableCollection<TreeViewItem>
            {
                CreateDirectoryNode(Model.FirstOrDefault())
            };  
        }

        private TreeViewItem CreateDirectoryNode(ItemModel directoryInfo)
        {
            TreeViewItem directoryNode = new TreeViewItem { Header = string.IsNullOrEmpty(directoryInfo.ItemValue) ?
                directoryInfo.Name : directoryInfo.Name +" = "+ directoryInfo.ItemValue};
            if (directoryInfo.ItemList != null)
            {
                foreach (var directory in directoryInfo.ItemList)
                    directoryNode.Items.Add(CreateDirectoryNode(directory));
            }
            return directoryNode;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using testTree2.Interfaces;

namespace testTree2.Helpers
{
    public class FileDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog(string extension = "Text (*.txt)|*.txt")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = extension;
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog(string extension = "Text (*.txt)|*.txt")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = extension;

            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }     

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}

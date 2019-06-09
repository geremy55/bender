using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTree2.Interfaces
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        string FilePath { get; set; }
        bool OpenFileDialog(string extension="Text (*.txt)|*.txt");
        bool SaveFileDialog(string extension = "Text (*.txt)|*.txt");
    }
}

using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class AboutViewModel:ObservableObject
    {
        public ICommand HelpCommand { get; }

        public AboutViewModel(DocumentModel document)
        {
            HelpCommand = new RelayCommand(OpenAboutDialog);
        }
        private void OpenAboutDialog()
        {
            var AboutDialog = new About();
            AboutDialog.ShowDialog();
        }
    }
}

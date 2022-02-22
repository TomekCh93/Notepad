using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModels
{
    public class MainViewModel
    {
        private DocumentModel _document;
        public EditorViewModel Editor { get; set; }
        public FileViewModel File { get; set; }
        public AboutViewModel Help { get; set; }

        public MainViewModel()
        {
            _document = new DocumentModel();
            Help = new AboutViewModel(_document);
            Editor = new EditorViewModel(_document);
            File = new FileViewModel(_document);
        }







    }
}

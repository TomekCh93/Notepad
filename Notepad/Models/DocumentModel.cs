using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class DocumentModel: ObservableObject
    {

        private string _text;
        private string _filePath;
        private string _fileName;
        private bool _autoSaveChecked;
        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath))
                {
                    return true;
                }

                return false;
            }
        }

        public bool AutoSaveChecked
        {
            get { return _autoSaveChecked; }
            set { OnPropertyChanged(ref _autoSaveChecked, value); }

        }

        public string Text
        {
            get{return _text;}
            set{OnPropertyChanged(ref _text, value); }
            
        }
        public string FilePath 
        { 
            get{ return _filePath;}
            set { OnPropertyChanged(ref _filePath, value); }
        }
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); }
        }

        public override bool Equals(object obj)
        {
            if (obj.ToString() == string.Empty)
            {
                return true;
            }
            return false;
            
        }
    }
}

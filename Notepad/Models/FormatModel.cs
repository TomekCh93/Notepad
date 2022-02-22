using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace Notepad.Models
{
    public class FormatModel : ObservableObject
    {

        private FontStyle _style;
        private FontWeight _weigth;
        private FontFamily _family;
        private TextWrapping _wrap;
        private bool _isWrapped;
        private double _size;

        public FontStyle Style
        {
            get { return _style; }
            set { OnPropertyChanged(ref _style, value); }
        }

        public FontWeight Weigth
        {
            get { return _weigth; }
            set { OnPropertyChanged(ref _weigth, value); }
        }

        public FontFamily Family
        {
            get { return _family; }
            set { OnPropertyChanged(ref _family, value); }
        }

        public TextWrapping Wrap
        {
            get { return _wrap; }
            set
            {
                OnPropertyChanged(ref _wrap, value);
                IsWrapped = value == TextWrapping.Wrap ? true : false; 
            }
        }

        public bool IsWrapped
        {
            get { return _isWrapped; }
            set { OnPropertyChanged(ref _isWrapped, value); }
        }

        public double Size
        {
            get { return _size; }
            set { OnPropertyChanged(ref _size, value); }
        }
    }
}

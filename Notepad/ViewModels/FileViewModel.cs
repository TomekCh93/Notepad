using Microsoft.Win32;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Notepad.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        //tollbar
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand AutoSaveCommand { get; }

        DispatcherTimer timer = new DispatcherTimer();


        public FileViewModel(DocumentModel document)
        {
            Document = document;
            Document.FileName = "Untitled";
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile, () => !Document.isEmpty);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            AutoSaveCommand = new RelayCommand(AutoSaveFeature, () => Document.FilePath != null);
            OpenCommand = new RelayCommand(OpenFile);

        }

        public void NewFile()
        {
            if (Document.Text != null)
            {
                var result = MessageBox.Show($"Do you want to save changes to *{Document.FileName}", "Save file", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                else if(result == MessageBoxResult.Yes)
                {
                    SaveFileAs();
                }
            }
            Document.FileName = string.Empty;
            Document.FileName = "Untitled";
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }
        public void SaveFile()
        {
            try
            {
                File.WriteAllText(Document.FilePath, Document.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("The specified save path are required for the autosave function", "Autosave", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveFileAs();
               
            }

        }
         
        public void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);      
            }
        }


        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void DockFile<T>(T dialog) where T: FileDialog
        {
            Document.FilePath= dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }

        private void AutoSaveFeature()
        {
            if (Document.AutoSaveChecked == true)
            {

                MessageBox.Show("Autosave enabled", "Autosave", MessageBoxButton.OK, MessageBoxImage.Information);
                if (Document.FilePath == null)
                {
                    SaveFileAs();
                }
                timer.Interval = TimeSpan.FromSeconds(300);
                timer.Tick += (sender, args) => SaveFile();
                timer.Start();
            }
            else
            {
                timer.Stop();
                return;
            }
        }
    }
}

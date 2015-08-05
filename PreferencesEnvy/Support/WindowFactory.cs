using Microsoft.Win32;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PreferencesEnvy.Support
{
    public class WindowFactory : IWindowFactory
    {
        private Container _Container;

        public WindowFactory(Container container)
        {
            _Container = container;
        }

        public void OpenPreferenceFileDialog(object dataContext)
        {
            Window window = _Container.GetInstance<PreferenceTypeDialog>();
            window.DataContext = dataContext;
            window.ShowDialog();
        }

        public string OpenFileDialog()
        {
            string fileName = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == true)
            {
                fileName = fileDialog.FileName;
            }
            //TODO: Move this elsewhere
            var prefTypeWindow = App.Current.Windows.OfType<PreferenceTypeDialog>().FirstOrDefault();
            if (prefTypeWindow != null)
            {
                prefTypeWindow.Close();
            }
            return fileName;
        }
    }
}

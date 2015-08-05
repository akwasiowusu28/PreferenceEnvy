using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PreferencesEnvy.Support
{
    public interface IWindowFactory
    {
        void OpenPreferenceFileDialog(object dataContext);
        string OpenFileDialog();
    }
}

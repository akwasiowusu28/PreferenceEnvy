using PreferencesEnvy.Support;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferencesEnvy
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = new Container();
            new Bootstrapper().RegisterTypes(container);
            RunApp(container);
        }

        static void RunApp(Container container)
        {
            try
            {
                App app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch(Exception ex)
            {
                //TODO: log it
            }
            
        }
    }
}

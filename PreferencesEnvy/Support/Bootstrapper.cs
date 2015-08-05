using Entities;
using Core.SerializerService;
using PreferencesEnvy.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferencesEnvy.Support
{
    public class Bootstrapper
    {
        public void RegisterTypes(Container container)
        {
            container.Register<ISerializerService, SerializerService>();
            container.Register<IMainViewModel, MainViewModel>();
            container.Register<IPreferenceViewModel, PreferenceViewModel>();
            container.Register<IValue, Value>();
            container.Register<IEntity, Entity>();
            container.Register<IPreference, Preference>();
            container.Register<MainWindow>();
            container.Register<IPreferencesManager, PreferencesManager>();
            container.Register<IWindowFactory, WindowFactory>(); //TODO: Should use a delegate type parameter to enable some kind or conditional creation
            container.Register<PreferenceTypeDialog>();
            container.Register<IDelegateCommand, DelegateCommand>();
            container.Register<IPreferenceTypeViewModel, PreferenceTypeViewModel>();

            container.Verify();
        }
    }
}

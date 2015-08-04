using Core.Entities;
using Core.SerializerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PreferencesEnvy.ViewModels;

namespace PreferencesEnvy
{

    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }

        public MainWindow(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            Initialize();
            InitializeComponent();
        }

        private void Initialize()
        {
            MainViewModel.Initialize();
        }
    }
}

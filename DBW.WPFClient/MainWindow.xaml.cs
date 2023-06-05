using DBW.WPFClient.Models;
using DBW.WPFClient.Services;
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

namespace DBW.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AreaViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new AreaViewModel(new AreaService());
            Loaded += OnLoaded;
            DataContext = _viewModel;

        }
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAreasAsync();
        }

    }

}

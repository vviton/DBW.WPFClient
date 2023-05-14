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
            dbwDataGrid.LoadingRow += OnDataGridLoadingRow;
        }

        private void OnDataGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            var area = e.Row.DataContext as Area;
            if (area != null)
            {
                UpdateRowColor(area);
            }
        }
        private void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedArea = e.Row.Item as Area;
            MessageBox.Show(editedArea.Id.ToString());
            if (editedArea != null)
            {
                UpdateRowColor(editedArea);
            }
        }
        private void UpdateRowColor(Area area)
        {
            var row = (DataGridRow) dbwDataGrid.ItemContainerGenerator.ContainerFromItem(area);
            if (row == null) return;

            switch (area.LevelName)
            {
                case "Temat":
                    row.Background = Brushes.Green;
                    break;
                case "Zakres informacyjny":
                    row.Background = Brushes.Red;
                    break;
                case "Dziedzina":
                    row.Background = Brushes.Yellow;
                    break;
                default:
                    row.Background = Brushes.Transparent;
                    break;
            }
        }
    }
       
        }
 
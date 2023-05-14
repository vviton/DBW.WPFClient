using DBW.WPFClient.Models;
using DBW.WPFClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient
{
    public class AreaViewModel : INotifyPropertyChanged
    {
        private readonly AreaService _areaService;
        private ObservableCollection<Area> _areas;

        public AreaViewModel(AreaService areaService)
        {
            _areaService = areaService;
            _areas = new();
        }

        public ObservableCollection<Area> Areas
        {
            get { return _areas; }
            set
            {
                if (_areas != value)
                {
                    _areas = value;
                    OnPropertyChanged(nameof(Areas));
                }
            }
        }
        public async Task LoadAreasAsync()
        {
            var areas = await _areaService.GetAreasAsync();
            _areas.Clear();
            areas.ForEach(area => _areas.Add(area));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

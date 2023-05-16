using DBW.WPFClient.Converters;
using DBW.WPFClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Services
{
    public class AreaService : IAreaService
    {
        private readonly HttpClient _httpClient;
        private readonly IAreaConverter _areaConverter;
        private readonly string _apiUrl = "https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area";

        public AreaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _areaConverter = new AreaJsonConverter();
        }

        public AreaService()
        {
            _httpClient = new HttpClient();
            _areaConverter = new AreaJsonConverter();
        }
        public async Task<List<Area>> GetAreasAsync()
        {
            List<Area> areas = new List<Area>();

            HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                areas = _areaConverter.ConvertToListOfAreas(json);
            }
            return areas;
        }

    }
}

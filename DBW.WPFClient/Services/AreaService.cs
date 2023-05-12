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
    public class AreaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area";

        public AreaService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Area>> GetElementsAsync()
        {
            List<Area> elements = new List<Area>();

            HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                elements = JsonConvert.DeserializeObject<List<Area>>(json);
            }
            return elements;
        }
    }
}

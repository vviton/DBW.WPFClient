using DBW.WPFClient.Converters;
using DBW.WPFClient.Models;
using DBW.WPFClient.Repository;
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
        IRepository<Area> _repository;

        public AreaService(HttpClient httpClient)
        {
            _repository = new AreaApiRepository(httpClient);
        }

        public AreaService()
        {
            var httpClient = new HttpClient();
            _repository = new AreaApiRepository(httpClient);
        }
        public async Task<List<Area>> GetAreasAsync()
        {
            var areas = await _repository.GetAllAsync();
            return areas;
        }

    }
}

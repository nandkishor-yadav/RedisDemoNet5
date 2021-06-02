using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisDemo.Extensions;
using RedisDemo.Interface;
using RedisDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IEfRepository<City> _cityRepository;
        private readonly IDistributedCache _cache;
        public CityController(IEfRepository<City> cityRepository, IDistributedCache cache)
        {
            _cityRepository = cityRepository;
            _cache = cache;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string recordKey = "CitiesList_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

            var cities = await _cache.GetRecordAsync<List<City>>(recordKey);

            if (cities is null)
            {
                cities = (List<City>)await _cityRepository.ListAllAsync();

                await _cache.SetRecordAsync(recordKey, cities);
            }

            return Ok(cities);
        }
    }
}

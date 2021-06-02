using System;

namespace RedisDemo.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string CountryISO3 { get; set; }
        public string CountryISO2 { get; set; }
        public string Population { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}

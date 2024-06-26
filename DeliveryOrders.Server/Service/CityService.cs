using DeliveryOrders.DataAccess.Models;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Service.Interfaces;
using Mapster;
using System.Net;
using Dadata;
using Dadata.Model;

namespace DeliveryOrders.Server.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Guid> AddAsync(CityAddDTO cityDTO)
        {
            CityModel cityModel = cityDTO.Adapt<CityModel>();
            cityModel.Id = Guid.NewGuid();

            return await _cityRepository.AddAsync(cityModel);
        }
    }
}

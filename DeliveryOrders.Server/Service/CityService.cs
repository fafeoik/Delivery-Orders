﻿using DeliveryOrders.DataAccess.Models;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Service.Interfaces;
using Mapster;
using System.Net;

namespace DeliveryOrders.Server.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Guid> AddAsync(CityAddDTO city)
        {
            CityModel model = city.Adapt<CityModel>();
            model.Id = Guid.NewGuid();

            await _cityRepository.AddAsync(model);

            return model.Id;
        }
    }
}
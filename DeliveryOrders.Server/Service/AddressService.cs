using DeliveryOrders.DataAccess.Models;
using DeliveryOrders.Repository;
using DeliveryOrders.Server.DTO;
using DeliveryOrders.Server.Service.Interfaces;
using Mapster;

namespace DeliveryOrders.Server.Service
{
    public class AddressService : IAddressService
    {
        private readonly ICityService _cityService;
        private readonly IAddressRepository _addressRepository;

        public AddressService(ICityService cityService, IAddressRepository addressRepository)
        {
            _cityService = cityService;
            _addressRepository = addressRepository;
        }

        public async Task<Guid> AddAsync(AddressAddDTO address)
        {
            AddressModel model = address.Adapt<AddressModel>();
            CityAddDTO city = new CityAddDTO() { Name = address.CityName };

            model.CityId = await _cityService.AddAsync(city);
            model.Id = Guid.NewGuid();
            return await _addressRepository.AddAsync(model);
        }
    }
}

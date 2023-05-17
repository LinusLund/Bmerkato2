using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Entities;
using Bmerkato2.Models.Identity;

namespace Bmerkato2.Helpers.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepository)
        {
            _addressRepo = addressRepo;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x => 
            x.StreetName == addressEntity.StreetName &&
            x.PostalCode == addressEntity.PostalCode &&
            x.City == addressEntity.City 
            );

            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;
        }

        public async Task AddAddressAsync(AppUser user,AddressEntity addressEntity)
        {
            await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }
    }
}

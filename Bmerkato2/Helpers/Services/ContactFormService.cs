using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;
using Bmerkato2.Models.ViewModels;

namespace Bmerkato2.Helpers.Services
{
    public class ContactFormService
    {
        private readonly ContactFormRepository _contactFormRepository;

        public ContactFormService(ContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public async Task<ContactFormEntity> AddAsync(ContactFormEntity entity)
        {
            var _entity = await _contactFormRepository.GetAsync(x => x.Id == entity.Id);
            if (_entity == null)
            {
                _entity = await _contactFormRepository.AddAsync(entity);
                if (_entity != null)
                    return entity;
            }
            return null!;
        }
    }
}

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

        public async Task<ContactFormData> AddAsync(ContactFormVM viewModel)
        {
            var entity = new ContactFormEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Company = viewModel.Company,
                Comment = viewModel.Comment,
                RememberMe = viewModel.SaveMyData,
                DateTime = DateTime.UtcNow
            };

            var result = await _contactFormRepository.AddAsync(entity);
            return result;
        }
    }
}

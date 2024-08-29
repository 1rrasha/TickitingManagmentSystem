using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class ServiceMapping
    {
        public static Service ToEntity(this ServiceModel model) =>
            new Service
            {
                Id = model.Id,
                Name = model.Name,
                CompanyId = model.CompanyId
            };

        public static ServiceResource ToResource(this Service entity) =>
            new ServiceResource
            {
                Id = entity.Id,
                Name = entity.Name,
                Company = entity.Company != null
                    ? new CompanyResource
                    {
                        Id = entity.Company.Id,
                        Name = entity.Company.Name,
                        Phone = entity.Company.Phone,
                        Email = entity.Company.Email,
                        Address = entity.Company.Address,
                        ProfilePicture = entity.Company.ProfilePicture,
                        IsCustomer = entity.Company.IsCustomer
                    }
                    : null,
            };

        public static ServiceModel ToModel(this Service entity) =>
            new ServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                CompanyId = entity.CompanyId
            };
    }
}

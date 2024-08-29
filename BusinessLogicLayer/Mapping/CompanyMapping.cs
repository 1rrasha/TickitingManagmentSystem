using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class CompanyMapping
    {
        public static Company ToEntity(this CompanyModel model) =>
            new Company
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                ProfilePicture = model.ProfilePicture,
                IsCustomer = model.IsCustomer,
            };

        public static CompanyResource ToResource(this Company entity) =>
            new CompanyResource
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                Address = entity.Address,
                ProfilePicture = entity.ProfilePicture,
                IsCustomer = entity.IsCustomer

            };

        public static CompanyModel ToModel(this Company entity) =>
            new CompanyModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                Address = entity.Address,
                ProfilePicture = entity.ProfilePicture,
                IsCustomer = entity.IsCustomer,
            };
    }
}



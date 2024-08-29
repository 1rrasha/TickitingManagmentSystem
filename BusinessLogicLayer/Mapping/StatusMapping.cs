using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class StatusMapping
    {
        public static Status ToEntity(this StatusModel model) =>
            new Status
            {
                Id = model.Id,
                StatusesName = model.StatusesName
            };

        public static StatusResource ToResource(this Status entity) =>
            new StatusResource
            {
                Id = entity.Id,
                StatusName = entity.StatusesName
            };

        public static StatusModel ToModel(this Status entity) =>
            new StatusModel
            {
                Id = entity.Id,
                StatusesName = entity.StatusesName
            };
    }
}



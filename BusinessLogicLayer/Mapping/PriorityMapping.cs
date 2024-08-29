using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class PriorityMapping
    {
        public static Priority ToEntity(this PriorityModel model) =>
            new Priority
            {
                Id = model.Id,
                PriorityName = model.PriorityName
            };

        public static PriorityResource ToResource(this Priority entity) =>
            new PriorityResource
            {
                Id = entity.Id,
                PriorityName = entity.PriorityName
            };

        public static PriorityModel ToModel(this Priority entity) =>
            new PriorityModel
            {
                Id = entity.Id,
                PriorityName = entity.PriorityName
            };
    }
}

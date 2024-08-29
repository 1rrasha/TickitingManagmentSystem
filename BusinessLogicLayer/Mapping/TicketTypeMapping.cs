using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class TicketTypeMapping
    {
        public static TicketType ToEntity(this TicketTypeModel model) =>
            new TicketType
            {
                Id = model.Id,
                TypeName = model.TypeName
            };

        public static TicketTypeModel ToModel(this TicketType entity) =>
            new TicketTypeModel
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };

        public static TicketTypeResource ToResource(this TicketType entity) =>
            new TicketTypeResource
            {
                Id = entity.Id,
                TypeName = entity.TypeName
            };
    }
}



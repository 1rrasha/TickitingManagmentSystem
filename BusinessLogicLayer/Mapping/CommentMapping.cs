using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class CommentMapping
    {
        public static Comment ToEntity(this CommentModel model) =>
            new Comment
            {
                Id = model.Id,
                CommentText = model.CommentText,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.CreatedBy,
                UpdatedOn = model.UpdatedOn,
                UpdatedBy = model.UpdatedBy,
                TicketId = model.TicketId
            };

        public static CommentResource ToResource(this Comment entity) =>
            new CommentResource
            {
                Id = entity.Id,
                TicketId = entity.TicketId,
                CommentText = entity.CommentText,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                UpdatedOn = entity.UpdatedOn,
                UpdatedBy = entity.UpdatedBy
            };

        public static CommentModel ToModel(this Comment entity) =>
            new CommentModel
            {
                Id = entity.Id,
                CommentText = entity.CommentText,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                UpdatedOn = entity.UpdatedOn,
                UpdatedBy = entity.UpdatedBy,
                TicketId = entity.TicketId
            };
    }
}



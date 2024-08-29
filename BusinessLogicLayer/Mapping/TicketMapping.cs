using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Resoures;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappings
{
    public static class TicketMapping
    {
        public static Ticket ToEntity(this TicketModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Ticket
            {
                PriorityId = model.PriorityId,
                ServiceId = model.ServiceId,
                Description = model.Description,
                StatusId = model.StatusId,
                TicketTypeId = model.TicketTypeId,
                Deadline = model.Deadline,
                Title = model.Title,
                UserTickets = (model.TicketUserIds ?? new List<int>()).Select(userId => new UserTicket { UserId = userId }).ToList()
            };
        }

        public static TicketResource ToResource(this Ticket entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new TicketResource
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Status = entity.Status != null ? new StatusResource
                {
                    Id = entity.Status.Id,
                    StatusName = entity.Status.StatusesName
                } : null,
                priority = entity.Priority != null ? new PriorityResource
                {
                    Id = entity.Priority.Id,
                    PriorityName = entity.Priority.PriorityName
                } : null,
                company = entity.Service?.Company != null ? new CompanyResource
                {
                    Id = entity.Service.Company.Id,
                    Name = entity.Service.Company.Name
                } : null,
                ticketType = entity.TicketType != null ? new TicketTypeResource
                {
                    Id = entity.TicketType.Id,
                    TypeName = entity.TicketType.TypeName
                } : null,
                service = entity.Service != null ? new ServiceResource
                {
                    Id = entity.Service.Id,
                    Name = entity.Service.Name
                } : null,
                Deadline = entity.Deadline,
                CreatedOn = entity.CreatedOn,
                CreatedBy = entity.CreatedBy,
                UpdatedOn = entity.UpdatedOn,
                UpdatedBy = entity.UpdatedBy,
                Comments = entity.Comments?.Select(c => new CommentResource
                {
                    Id = c.Id,
                    CommentText = c.CommentText,
                    CreatedOn = c.CreatedOn,
                    CreatedBy = c.CreatedBy,
                    UpdatedOn = c.UpdatedOn,
                    UpdatedBy = c.UpdatedBy
                }).ToList() ?? new List<CommentResource>()
            };
        }

        public static TicketModel ToModel(this Ticket entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new TicketModel
            {
                Id = entity.Id,
                PriorityId = entity.PriorityId,
                ServiceId = entity.ServiceId,
                Description = entity.Description,
                StatusId = entity.StatusId,
                Deadline = entity.Deadline,
                Title = entity.Title,
                TicketUserIds = (entity.UserTickets?.Select(ut => ut.UserId) ?? Enumerable.Empty<int>()).ToList()
            };
        }
    }
}

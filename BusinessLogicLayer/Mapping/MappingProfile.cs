//using AutoMapper;
//using BusinessLogicLayer.Models;
//using BusinessLogicLayer.Resources;
//using DataAccessLayer.Entites;

//public static class MappingConfig
//{
//    public static void ConfigureMappings(IMapperConfigurationExpression cfg)
//    {
//        // Entity to Resource
//        cfg.CreateMap<Comment, CommentResource>();
//        cfg.CreateMap<Company, CompanyResource>();
//        cfg.CreateMap<Priority, PriorityResource>();
//        cfg.CreateMap<Service, ServiceResource>();
//        cfg.CreateMap<Status, StatusResource>();
//        cfg.CreateMap<Ticket, TicketResource>();
//        cfg.CreateMap<TicketType, TicketTypeResource>();
//        cfg.CreateMap<User, UserResource>();
//        cfg.CreateMap<UserTicket, UserTicketResource>();

//        // Resource to Entity
//        cfg.CreateMap<CommentResource, Comment>();
//        cfg.CreateMap<CompanyResource, Company>();
//        cfg.CreateMap<PriorityResource, Priority>();
//        cfg.CreateMap<ServiceResource, Service>();
//        cfg.CreateMap<StatusResource, Status>();
//        cfg.CreateMap<TicketResource, Ticket>();
//        cfg.CreateMap<TicketTypeResource, TicketType>();
//        cfg.CreateMap<UserResource, User>();
//        cfg.CreateMap<UserTicketResource, UserTicket>();

//        // Model to Resource
//        cfg.CreateMap<CommentModel, CommentResource>();
//        cfg.CreateMap<CompanyModel, CompanyResource>();
//        cfg.CreateMap<PriorityModel, PriorityResource>();
//        cfg.CreateMap<ServiceModel, ServiceResource>();
//        cfg.CreateMap<StatusModel, StatusResource>();
//        cfg.CreateMap<TicketModel, TicketResource>();
//        cfg.CreateMap<TicketTypeModel, TicketTypeResource>();
//        cfg.CreateMap<UserModel, UserResource>();
//        cfg.CreateMap<UserTicketModel, UserTicketResource>();

//        // Resource to Model
//        cfg.CreateMap<CommentResource, CommentModel>();
//        cfg.CreateMap<CompanyResource, CompanyModel>();
//        cfg.CreateMap<PriorityResource, PriorityModel>();
//        cfg.CreateMap<ServiceResource, ServiceModel>();
//        cfg.CreateMap<StatusResource, StatusModel>();
//        cfg.CreateMap<TicketResource, TicketModel>();
//        cfg.CreateMap<TicketTypeResource, TicketTypeModel>();
//        cfg.CreateMap<UserResource, UserModel>();
//        cfg.CreateMap<UserTicketResource, UserTicketModel>();
//    }
//}

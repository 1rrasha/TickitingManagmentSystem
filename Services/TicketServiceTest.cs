using Xunit;using Moq;using BusinessLogicLayer.Services;using BusinessLogicLayer.Models;using DataAccessLayer.Entities;using DataAccessLayer.Repository;namespace Test.Services{    public class TicketServiceTest    {        private readonly Mock<ITicketRepository> _ticketRepositoryMock;        private readonly TicketService _ticketService;        public TicketServiceTest()        {            _ticketRepositoryMock = new Mock<ITicketRepository>();            _ticketService = new TicketService(_ticketRepositoryMock.Object);        }        [Fact]        public async Task GetTicketByIdAsync_ShouldReturnTicketResource_WhenTicketExists()        {
            // Arrange
            var ticketId = 1;            var ticket = new Ticket { Id = ticketId, Title = "Sample Ticket" };            _ticketRepositoryMock.Setup(repo => repo.GetTicketByIdAsync(ticketId))                                 .ReturnsAsync(ticket);

            // Act
            var result = await _ticketService.GetTicketByIdAsync(ticketId);

            // Assert
            Assert.NotNull(result);            Assert.Equal(ticketId, result.Id);            Assert.Equal("Sample Ticket", result.Title);        }        [Fact]        public async Task GetAllTicketsAsync_ShouldReturnListOfTicketResources()        {
            // Arrange
            var tickets = new List<Ticket>            {                new Ticket { Id = 1, Title = "Ticket 1" },                new Ticket { Id = 2, Title = "Ticket 2" }            };            _ticketRepositoryMock.Setup(repo => repo.GetAllTicketsAsync())                                 .ReturnsAsync(tickets);

            // Act
            var result = await _ticketService.GetAllTicketsAsync();

            // Assert
            Assert.NotNull(result);            Assert.Equal(2, result.Count());        }        [Fact]        public async Task AddTicketAsync_ShouldReturnTicketResource_AfterAddingTicket()        {
            // Arrange
            var ticketModel = new TicketModel { Title = "New Ticket" };            var ticket = new Ticket { Id = 1, Title = "New Ticket" };            _ticketRepositoryMock.Setup(repo => repo.AddTicketAsync(It.IsAny<Ticket>()))                                 .ReturnsAsync(ticket);            _ticketRepositoryMock.Setup(repo => repo.GetTicketByIdAsync(ticket.Id))                                 .ReturnsAsync(ticket);

            // Act
            var result = await _ticketService.AddTicketAsync(ticketModel);

            // Assert
            Assert.NotNull(result);            Assert.Equal(ticket.Id, result.Id);            Assert.Equal(ticket.Title, result.Title);        }        [Fact]        public async Task UpdateTicketAsync_ShouldCallUpdateTicketAsync_WhenTicketIsUpdated()        {
            // Arrange
            var ticketModel = new TicketModel            {                Id = 1,                Title = "Updated Ticket",                PriorityId = 2,                ServiceId = 2,                StatusId = 2,                Deadline = DateTime.Now.AddDays(1),                TicketUserIds = new List<int> { 2, 3 } // Ensure this is not null
            };            var ticket = new Ticket { Id = 1, Title = "Original Ticket" };            _ticketRepositoryMock.Setup(repo => repo.GetTicketByIdAsync(ticketModel.Id))                                 .ReturnsAsync(ticket);            _ticketRepositoryMock.Setup(repo => repo.UpdateTicketAsync(It.IsAny<Ticket>()))                                 .Returns(Task.CompletedTask)                                 .Verifiable();

            // Act
            await _ticketService.UpdateTicketAsync(ticketModel);

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.UpdateTicketAsync(It.Is<Ticket>(t =>
t.Id == ticketModel.Id &&
t.Title == ticketModel.Title &&
t.PriorityId == ticketModel.PriorityId &&
t.ServiceId == ticketModel.ServiceId &&
t.StatusId == ticketModel.StatusId &&
t.Deadline == ticketModel.Deadline &&
t.UserTickets.Count == ticketModel.TicketUserIds.Count &&
t.UpdatedOn != null)), Times.Once);        }        [Fact]        public async Task DeleteTicketAsync_ShouldCallDeleteTicketAsync_WhenTicketExists()        {
            // Arrange
            var ticketId = 1;            var ticket = new Ticket { Id = ticketId };            _ticketRepositoryMock.Setup(repo => repo.GetTicketByIdAsync(ticketId))                                 .ReturnsAsync(ticket);            _ticketRepositoryMock.Setup(repo => repo.DeleteTicketAsync(ticketId))                                 .Returns(Task.CompletedTask)                                 .Verifiable();

            // Act
            await _ticketService.DeleteTicketAsync(ticketId);

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.DeleteTicketAsync(ticketId), Times.Once);        }    }}
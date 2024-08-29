
using Moq;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Resoures;
using BusinessLogicLayer.Models;
using PresentationLayer.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Controllers
{
    public class TicketControllerTest
    {
        private readonly Mock<ITicketService> _ticketServiceMock;
        private readonly TicketController _ticketController;

        public TicketControllerTest()
        {
            _ticketServiceMock = new Mock<ITicketService>();
            _ticketController = new TicketController(_ticketServiceMock.Object);
        }

        [Fact]
        public async Task GetAllTickets_ShouldReturnOkObjectResult_WithListOfTickets()
        {
            // Arrange
            var tickets = new List<TicketResource>
            {
                new TicketResource { Id = 1, Title = "Ticket 1" },
                new TicketResource { Id = 2, Title = "Ticket 2" }
            };
            _ticketServiceMock.Setup(service => service.GetAllTicketsAsync())
                              .ReturnsAsync(tickets);

            // Act
            var result = await _ticketController.GetAllTickets();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTickets = Assert.IsAssignableFrom<IEnumerable<TicketResource>>(okResult.Value);
            Assert.Equal(2, returnedTickets.Count());
        }

        [Fact]
        public async Task GetTicketById_ShouldReturnOkObjectResult_WhenTicketExists()
        {
            // Arrange
            var ticketId = 1;
            var ticket = new TicketResource { Id = ticketId, Title = "Sample Ticket" };
            _ticketServiceMock.Setup(service => service.GetTicketByIdAsync(ticketId))
                              .ReturnsAsync(ticket);

            // Act
            var result = await _ticketController.GetTicketById(ticketId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTicket = Assert.IsType<TicketResource>(okResult.Value);
            Assert.Equal(ticketId, returnedTicket.Id);
        }

        [Fact]
        public async Task GetTicketById_ShouldReturnNotFound_WhenTicketDoesNotExist()
        {
            // Arrange
            var ticketId = 1;
            _ticketServiceMock.Setup(service => service.GetTicketByIdAsync(ticketId))
                              .ReturnsAsync((TicketResource)null);

            // Act
            var result = await _ticketController.GetTicketById(ticketId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddTicket_ShouldReturnCreatedAtActionResult_WhenTicketIsCreated()
        {
            // Arrange
            var ticketModel = new TicketModel { Id = 1, Title = "New Ticket" };
            var ticketResource = new TicketResource { Id = 1, Title = "New Ticket" };

            _ticketServiceMock.Setup(service => service.AddTicketAsync(ticketModel))
                              .ReturnsAsync(ticketResource);

            // Act
            var result = await _ticketController.AddTicket(ticketModel);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(_ticketController.GetTicketById), createdAtActionResult.ActionName);
            Assert.Equal(ticketModel.Id, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(ticketResource, createdAtActionResult.Value);
        }

        [Fact]
        public async Task UpdateTicket_ShouldReturnNoContentResult_WhenTicketIsUpdated()
        {
            // Arrange
            var ticketId = 1;
            var ticketModel = new TicketModel { Id = ticketId, Title = "Updated Ticket" };

            _ticketServiceMock.Setup(service => service.UpdateTicketAsync(ticketModel))
                              .Returns(Task.CompletedTask);

            // Act
            var result = await _ticketController.UpdateTicket(ticketId, ticketModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTicket_ShouldReturnNoContentResult_WhenTicketIsDeleted()
        {
            // Arrange
            var ticketId = 1;
            var ticketResource = new TicketResource { Id = ticketId, Title = "Ticket to be deleted" };

            _ticketServiceMock.Setup(service => service.GetTicketByIdAsync(ticketId))
                              .ReturnsAsync(ticketResource);
            _ticketServiceMock.Setup(service => service.DeleteTicketAsync(ticketId))
                              .Returns(Task.CompletedTask);

            // Act
            var result = await _ticketController.DeleteTicket(ticketId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}


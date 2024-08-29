﻿using Xunit;
            // Arrange
            var ticketId = 1;

            // Act
            var result = await _ticketService.GetTicketByIdAsync(ticketId);

            // Assert
            Assert.NotNull(result);
            // Arrange
            var tickets = new List<Ticket>

            // Act
            var result = await _ticketService.GetAllTicketsAsync();

            // Assert
            Assert.NotNull(result);
            // Arrange
            var ticketModel = new TicketModel { Title = "New Ticket" };

            // Act
            var result = await _ticketService.AddTicketAsync(ticketModel);

            // Assert
            Assert.NotNull(result);
            // Arrange
            var ticketModel = new TicketModel
            };

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
t.UpdatedOn != null)), Times.Once);
            // Arrange
            var ticketId = 1;

            // Act
            await _ticketService.DeleteTicketAsync(ticketId);

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.DeleteTicketAsync(ticketId), Times.Once);
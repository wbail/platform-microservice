using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PlatformService.AsyncDataServices;
using PlatformService.Controllers;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Profiles;
using PlatformService.SyncDataServices.Http;
using System;
using System.Collections.Generic;
using Xunit;

namespace PlatformService.UnitTests
{
    public class PlatformControllerTests
    {
        public PlatformControllerTests()
        {
            
            _platformRepositoryMock = new Mock<IPlatformRepository>();
            _commandDataClientMock = new Mock<ICommandDataClient>();
            _messageBusClientMock = new Mock<IMessageBusClient>();

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new PlatformProfile());
            });

            var mapper = config.CreateMapper();

            _platformController = new PlatformController(_platformRepositoryMock.Object, mapper, _commandDataClientMock.Object, _messageBusClientMock.Object);

        }

        private readonly PlatformController _platformController;
        private readonly Mock<IPlatformRepository> _platformRepositoryMock;
        private readonly Mock<ICommandDataClient> _commandDataClientMock;
        private readonly Mock<IMessageBusClient> _messageBusClientMock;

        [Fact]
        public void PlatformController_GetAllPlatforms_ReturnOk()
        {
            // Arrange
            // Act
            var platforms = _platformController.GetAllPlatforms();

            // Assert
            platforms.Should().NotBeNull();
            platforms.Should().BeOfType<ActionResult<IEnumerable<PlatformReadDto>>>();
        }

        [Fact]
        public void PlatformController_GetPlatformById_ReturnOk()
        {
            // Arrange
            var id = Guid.Parse("00DFD1F7-1833-4E4F-A912-FD4759412505");

            // Act
            var platform = _platformController.GetPlatformById(id);

            // Assert
            platform.Should().NotBeNull();
            platform.Should().BeOfType<ActionResult<PlatformReadDto>>();
        }

        [Fact]
        public void PlatformController_CreatePlatform_SaveSuccessfully()
        {
            // Arrange
            var newPlatformDto = new PlatformCreateDto("Test", "Test Publisher", "Free");
            
            // Act
            var result = _platformController.CreatePlatform(newPlatformDto);

            // Assert
            _platformRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}

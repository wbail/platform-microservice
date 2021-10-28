using System;
using Xunit;
using Moq;
using FluentAssertions;
using CommandService.Data;
using CommandService.Controllers;
using AutoMapper;
using CommandService.Profiles;
using CommandService.Models;
using System.Collections.Generic;
using CommandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.UnitTests
{
    public class CommandControllerTests
    {
        public CommandControllerTests()
        {
            _commandRepositoryMock = new Mock<ICommandRepository>();

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new CommandProfile());
            });

            var mapper = config.CreateMapper();

            _commandController = new CommandController(_commandRepositoryMock.Object, mapper);
        }

        private readonly Mock<ICommandRepository> _commandRepositoryMock;
        private readonly CommandController _commandController; 

        [Fact]
        public void CommandController_GetCommandsForPlatform_ReturnsOk()
        {
            // Arrange

            var platformId = Guid.Parse("A282FBAC-0BEC-4513-B4B4-C4AABBC3DAD8");

            var commands = new List<Command>
            {
                new Command
                {
                    Id = Guid.Parse("750021EF-D78F-4347-9D2B-055015E36863"),
                    CommandLine = "",
                    HowTo = "",
                    PlatformId = platformId
                },
                new Command
                {
                    Id = Guid.Parse("DC8BD5AC-366A-4493-9AA7-C4F5855873A9"),
                    CommandLine = "",
                    HowTo = "",
                    PlatformId = platformId
                },
                new Command
                {
                    Id = Guid.Parse("530CC8D9-996F-4DD4-8092-F4B803F4C4EB"),
                    CommandLine = "",
                    HowTo = "",
                    PlatformId = platformId
                }
            };

            _commandRepositoryMock.Setup(x => x.GetCommandsForPlatform(It.IsAny<Guid>())).Returns(commands);

            // Act

            var result = _commandController.GetCommandsForPlatform(platformId);

            // Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<IEnumerable<CommandReadDto>>>();
        }

        // TODO: Finish the test
        [Fact]
        public void CommandController_GetCommandsForPlatform_ReturnsNotFound()
        {
            // Arrange

            var platformId = Guid.Parse("61DEC482-3CF0-4C91-ABC0-6A8B5E71DBA1");

            var commands = new List<Command> { };

            _commandRepositoryMock.Setup(x => x.GetCommandsForPlatform(It.IsAny<Guid>())).Returns(commands);

            // Act

            var result = _commandController.GetCommandsForPlatform(platformId);

            // Assert

            result.Should().NotBeNull();
        }
    }
}

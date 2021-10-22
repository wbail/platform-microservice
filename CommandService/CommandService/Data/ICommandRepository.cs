using CommandService.Models;
using System;
using System.Collections.Generic;

namespace CommandService.Data
{
    public interface ICommandRepository
    {
        bool SaveChanges();

        // Platforms
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlaformExits(Guid platformId);
        bool ExternalPlatformExists(Guid externalPlatformId);

        // Commands
        IEnumerable<Command> GetCommandsForPlatform(Guid platformId);
        Command GetCommand(Guid platformId, Guid commandId);
        void CreateCommand(Guid platformId, Command command);
    }
}

using PlatformService.Models;
using System;
using System.Collections.Generic;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(Guid id);
        void CreatePlatform(Platform platform);
    }
}

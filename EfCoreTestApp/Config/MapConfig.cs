
using EfCoreTestApp.Dto;
using EfCoreTestApp.Models;
using Mapster;
namespace EfCoreTestApp.Config
{
    public static class MapConfig
    {
        static MapConfig()
        {
            TypeAdapterConfig<Folder, FolderDto>
                .NewConfig();
        }


    }
}

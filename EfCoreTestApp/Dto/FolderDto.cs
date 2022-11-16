using EfCoreTestApp.Models;

namespace EfCoreTestApp.Dto
{
    public class FolderDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ParentId { get; set; }
        public ICollection<Folder> SubFolders { get; } = new List<Folder>();

    }
}

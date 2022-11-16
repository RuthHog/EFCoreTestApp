namespace EfCoreTestApp.Models
{
    public class Folder
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual Folder Parent { get; set; }
        public string? ParentId { get; set; }
        public virtual ICollection<Folder> SubFolders { get; } = new List<Folder>();
    }
}

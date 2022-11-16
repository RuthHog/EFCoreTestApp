using EfCoreTestApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfCoreTestApp.Respitory
{

    public interface IItemRespitory
    {
        public Task<Item?> GetParent(string itemNo);

        public Task<int> AddItem(Item item);

        public Task<int> AddChild(Item item);

        public Task<List<Item>?> GetAllParents();
    }

    public class ItemRespitory : IItemRespitory
    {
        private readonly FolderContext _db;

        public ItemRespitory(FolderContext db)
        {
            _db = db;
        }

        public async Task<int> AddItem(Item item)
        {
            _db.items.Add(item);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> AddChild(Item item)
        {
            _db.items.Add(item);
            return await _db.SaveChangesAsync();
        }
        public async Task<Item?> GetParent(string itemNo)
        {
            return await _db.items.Where(x => x.ItemNo == itemNo)
                .Include(x => x.Children)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Item>?> GetAllParents()
        {
            return await _db.items
                .Include(x => x.Children)
                .ThenInclude(x => x.Children)
                .ToListAsync();
        }
    }
}

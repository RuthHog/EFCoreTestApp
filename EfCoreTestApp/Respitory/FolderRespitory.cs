using Aardvark.VRVis;
using EfCoreTestApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;

namespace EfCoreTestApp.Respitory
{

    public interface IFolderRespitory
    {
        public Task<int> AddFolder(Folder folder);

        public Task<List<Folder>?> GetFoldersAndSubFolder(string folderId);

        public Task<List<Folder>?> GetAllParentFolders();

        public Task<Folder?> GetFolder(string folderId);
        public Task<int> UpdateFolder(string folderId, string name);
        public Task<int> DeleteFolder(string folderId);
        public Task<int> MoveFolder(string folderId, string parentid);
    }

    public class FolderRespitory : IFolderRespitory
    {
        private readonly FolderContext _db;

        public FolderRespitory(FolderContext db)
        {
            _db = db;
        }

        public async Task<int> AddFolder(Folder folder)
        {
            _db.folder.Add(folder);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Folder>?> GetFoldersAndSubFolder(string folderId)
        {
            return await _db.folder.Where(x => x.Id == folderId)
                    .Include(x => x.SubFolders)
                        .ThenInclude(x => x.SubFolders)
                .ToListAsync();
        }

        public async Task<Folder?> GetFolder(string folderId)
        {
            return await _db.folder.Where(x => x.Id == folderId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteFolder(string folderId)
        {
            var folder = await _db.folder.Where(x => x.Id == folderId)
                .Include(x => x.SubFolders)
                .ToListAsync();

            _db.folder.RemoveRange(folder);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateFolder(string folderId, string name)
        {
            var folder = await _db.folder.Where(x => x.Id == folderId)
                .FirstOrDefaultAsync();
            folder.Name = name;

            _db.folder.Update(folder);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> MoveFolder(string folderId, string parentid)
        {
            var parent = await GetFolder(parentid);

            var folder = await GetFolder(folderId);

            folder.Parent = parent;
            folder.ParentId = parent?.Id ?? null;

            _db.folder.Update(folder);
            return await _db.SaveChangesAsync();
        }


        public async Task<List<Folder>?> GetAllParentFolders()
        {
            List<Folder> folders = await _db.folder.Where(x => x.ParentId == null)
                .ToListAsync();
            return folders;
        }

    }
}

using EfCoreTestApp.Models;
using EfCoreTestApp.Respitory;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderRespitory _folder;

        public FolderController(IFolderRespitory folder)
        {
            _folder = folder;
        }
        // GET: api/<FolderController>
        [HttpGet("AllFolders")]
        public async Task<IEnumerable<Folder>?> Get()
        {
            var folders = await _folder.GetAllParentFolders();

            return folders;
        }

        // GET api/<FolderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var test = await _folder.GetFoldersAndSubFolder(id);

            return Ok(test);
        }

        // POST api/<FolderController>
        [HttpPost("Folder", Name = "Folder")]
        public async Task<IEnumerable<Folder>?> PostFolder([FromBody] string title)
        {
            var folder = new Folder();
            folder.Name = title;
            folder.Id = Guid.NewGuid().ToString();

            await _folder.AddFolder(folder);

            return await _folder.GetFoldersAndSubFolder(folder.Id);
        }

        // POST api/<FolderController>
        [HttpPost("subFolder", Name = "SubFolder")]
        public async Task<Folder?> PostSubFolder([FromBody] string name, string folderid)
        {
            var folder = await _folder.GetFolder(folderid);

            var subfolder = new Folder();
            subfolder.Name = name;
            subfolder.Id = Guid.NewGuid().ToString();
            subfolder.Parent = folder;
            subfolder.ParentId = folder.Id;

            await _folder.AddFolder(subfolder);

            return await _folder.GetFolder(subfolder.Id);

        }

        // PUT api/<FolderController>/5
        [HttpPut("{folderId}")]
        public async Task<IActionResult> Put(string folderId, [FromBody] string name)
        {
            var update = await _folder.UpdateFolder(folderId, name);
            return Ok(update);
        }

        // PUT api/<FolderController>/5
        [HttpPut("{folderId}/movefolder/{parentId}")]
        public async Task<IActionResult> MoveFolder(string folderId, string parentId)
        {
            var update = await _folder.MoveFolder(folderId, parentId);
            return Ok(update);
        }

        // DELETE api/<FolderController>/5
        [HttpDelete("{folderId}")]
        public async Task<IActionResult> Delete(string folderId)
        {
            var delete = await _folder.DeleteFolder(folderId);
            return Ok(delete);
        }
    }
}

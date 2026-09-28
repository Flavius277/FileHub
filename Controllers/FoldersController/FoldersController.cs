using FileHub.Database.Classes;
using Microsoft.AspNetCore.Mvc;

namespace FileHub.Controllers;

[ApiController]
[Route("folders")]
public class FoldersController : ControllerBase
{
    private readonly FoldersService _foldersService;

    public FoldersController(FoldersService foldersService)
    {
        _foldersService = foldersService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Folders>>> GetFolders()    
    {
        var result = await _foldersService.GetFolders();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Folders?>> GetFolderById(int id)
    {
        var folderFound = await _foldersService.GetFolderById(id);
        return folderFound is null ? NotFound() : Ok(folderFound);
    }

    [HttpPost]
    public async Task<ActionResult<Folders>> CreateFolder([FromBody] string name)
    {
        return Ok(await _foldersService.CreateFolder(name));
        
    }

    [HttpPut("{id:int}/{newName}")]
    public async Task<ActionResult<Folders>> UpdateFolder(int id, string newName)
    {
        var folder = await _foldersService.UpdateFolder(id, newName);

        if(folder is null)
        {
            return NotFound();
        }

        return Ok(folder);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Folders>> DeleteFolder(int id)
    {
        return Ok(await _foldersService.DeleteFolder(id));
        
    }

    [HttpDelete]
    public async Task<ActionResult<int>> DeleteAllRecords()
    {
        return await _foldersService.DeleteAllRecords();
    }
}

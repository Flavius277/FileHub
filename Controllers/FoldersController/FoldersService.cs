using FileHub.Database.Classes;
using FileHub.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FileHub.Controllers;

public class FoldersService
{
    private readonly FileHubDb _dbContext;
    public FoldersService(FileHubDb dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Folders>> GetFolders()
    {
        return await _dbContext.Folders.ToListAsync();
    }

    public async Task<Folders?> GetFolderById(int id)
    {
        return await _dbContext.Folders.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<bool> DeleteFolder(int id)
    {
            var affectedRow = await _dbContext.Folders.Where(f => f.Id == id).ExecuteDeleteAsync();
            return affectedRow > 0;
    }

    public async Task<Folders> UpdateFolder(int id, string newName)
    {
        try
        {
            await _dbContext.Folders.Where(f => f.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(f => f.Name, newName));
            return await _dbContext.Folders.FirstAsync(f => f.Id == id);
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public async Task<Folders> CreateFolder(string name)
    {
        Folders newFolder = new Folders { Name = name };
        await _dbContext.Folders.AddAsync(newFolder);
        await _dbContext.SaveChangesAsync();
        return newFolder;
    }

    public async Task<int> DeleteAllRecords()
    {
        return await _dbContext.Folders.ExecuteDeleteAsync();
    }
}

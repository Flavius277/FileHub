using FileHub.Database.Classes;
using FileHub.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FileHub.Controllers.DocumentsController
{
    public class DocumentsService
    {
        private readonly FileHubDb _dbContext;

        public DocumentsService(FileHubDb dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<Documents> GetAllDocuments()
        {
            return _dbContext.Documents.ToList();
        }

        public Documents? GetDocument(int id)
        {
            return _dbContext.Documents.FirstOrDefault(d => d.Id == id);
        }

        public Documents CreateNewDocument(string name)
        {
            var newDocument = new Documents { Name = name };
            var saveResult = _dbContext.Documents.Add(newDocument);
            _dbContext.SaveChanges();
            return newDocument;
        }

        public int? UpdateDocument(int id, string name)
        {
            var existsDocument = _dbContext.Documents.FirstOrDefault(d => d.Id == id);

            if (existsDocument is not null)
            {
                var document = _dbContext.Documents.Where(d => d.Id == id).ExecuteUpdate(setter => setter.SetProperty(d => d.Name, name));
                _dbContext.SaveChanges();
                return document;
            }
            return 0;
        }

        public bool DeleteDocument(int id)
        {
            var existsDocument = _dbContext.Documents.FirstOrDefault(d => d.Id == id);

            if (existsDocument is null) return false;

            _dbContext.Documents.Where(d => d.Id == id).ExecuteDelete();

            return true;
        }
    }
}

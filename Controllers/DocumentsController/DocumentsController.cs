using FileHub.Database.Classes;
using Microsoft.AspNetCore.Mvc;

namespace FileHub.Controllers.DocumentsController
{
    [Route("documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentsService _documentsService;

        public DocumentsController(DocumentsService documentsService)
        {
            _documentsService = documentsService;
        }

        [HttpGet]
        public ActionResult GetAllDocuments()
        {
            return Ok(_documentsService.GetAllDocuments());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetDocument(int id)
        {
            var document = _documentsService.GetDocument(id);

            if (document is null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpPost]
        public ActionResult CreateNewDocument([FromBody] string name)
        {
            return Ok(_documentsService.CreateNewDocument(name));
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateDocument(int id, [FromBody] string name)
        {
            var isUpdated = _documentsService.UpdateDocument(id, name);

            if (isUpdated == 0) return NotFound();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteDocument(int id)
        {
            var isDeleted = _documentsService.DeleteDocument(id);

            if (isDeleted is false) return NotFound();

            return Ok();
        }
    }
}

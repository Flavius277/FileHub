namespace FileHub.Controllers;

public class FoldersModels
{
    public class CreateFolderModel 
    { 
        public string Name { get; set; }
    }

    public class UpdateFolderModel : CreateFolderModel;

}

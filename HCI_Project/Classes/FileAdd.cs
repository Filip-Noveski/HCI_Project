namespace HCI_Project.Classes;

public class FileAdd
{
    private readonly IWebHostEnvironment _environment;

    public FileAdd(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<FileFinishState> OfferFiles(Dictionary<string, IFormFile> files, string description, int offerId)
    {
        string webRootPath = _environment.WebRootPath;
        string finalPath = Path.Combine(webRootPath, "offerData", offerId.ToString());
        Directory.CreateDirectory(finalPath);

        foreach (KeyValuePair<string, IFormFile> file in files)
        {
            string fileName = file.Key + Path.GetExtension(file.Value.FileName);
            string filePath = Path.Combine(finalPath, fileName);

            using var stream = File.Create(filePath);
            await file.Value.CopyToAsync(stream);
        }

        string descPath = Path.Combine(finalPath, "description.txt");
        File.WriteAllText(descPath, description);

        return FileFinishState.Success;
    }
}

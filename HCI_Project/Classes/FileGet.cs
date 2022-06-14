using HCI_Project.Models;

namespace HCI_Project.Classes;

public class FileGet
{
    private readonly IWebHostEnvironment _environment;

    public FileGet(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public List<string> FilePaths(OfferData offer)
    {
        string webRootPath = _environment.WebRootPath;
        string finalPath = Path.Combine(webRootPath, "offerData", offer.Id.ToString());
        
        List<string> files = Directory.GetFiles(finalPath).ToList();
        for (int k = 0; k <= files.Count - 1; k++)
            files[k] = Path.Combine("~/", files[k].Split("wwwroot")[1]).Replace('\\', '/');

        return files;
    }
    
    public Dictionary<long, List<string>> FilePaths(List<OfferData> offers)
    {
        string webRootPath = _environment.WebRootPath;
        string offersPath = Path.Combine(webRootPath, "offerData");
        Dictionary<long, List<string>> ret = new();
        for (int i = 0; i <= offers.Count - 1; i++)
        {
            string finalPath = Path.Combine(offersPath, offers[i].Id.ToString());
            List<string> files = Directory.GetFiles(finalPath).ToList();
            for (int k = 0; k <= files.Count - 1; k++)
                files[k] = Path.Combine("~/", files[k].Split("wwwroot")[1]).Replace('\\', '/');

            if (!ret.ContainsKey(offers[i].Id))
                ret.Add(offers[i].Id, files);
        }
        return ret;
    }

    public Dictionary<string, string> Countries(string continent)
    {
        Dictionary<string, string> ret = new();
        string path = Path.Combine(_environment.WebRootPath, $"countries/{continent}.txt");
        string[] countries = File.ReadAllLines(path);
        foreach (string country in countries)
        {
            string[] pair = country.Split(":");
            ret.Add(pair[0], pair[1]);
        }

        return ret;
    }
}

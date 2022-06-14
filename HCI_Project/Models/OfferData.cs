using HCI_Project.Classes;

namespace HCI_Project.Models;

public class OfferData
{
    public long Id { get; set; }
    public string? Brand { get; set; }
    public string? Name { get; set; }
    public Pair<Currency, decimal>? Price { get; set; }
    public SearchDataPartType PartType { get; set; }
    public SearchDataAge Age { get; set; }
    public DateTime PublishTime { get; set; }
    public bool Available { get; set; }
    public string? UserId { get; set; }
}

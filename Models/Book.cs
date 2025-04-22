namespace KnjiskiMoljac.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ImageUrl { get; set; }
    public bool IsFinished { get; set; }
}

using KinoGigant;

public class ShowCatalog
{
  private readonly List<Show> _shows = new();
  public IReadOnlyList<Show> Shows => _shows;


  public void SeedSampleShows()
  {
    Add(new Show(
      title: "Matrix",
      dateTime: new DateTime(2026,3,16),
      hour: new DateTime(2026,3,16,18,0,0),
      numberOfSeats: 40
    ));
    Add(new Show(
      title: "Inception",
      dateTime: new DateTime(2026,3,17),
      hour: new DateTime(2026,3,17,21,0,0),
      numberOfSeats: 20
    ));
    
    Add(new Show(
      title: "Django",
      dateTime: new DateTime(2026,3,20),
      hour: new DateTime(2026,3,20,20,0,0),
      numberOfSeats: 30
    ));
  }

  public void Add(Show show) => _shows.Add(show);
}
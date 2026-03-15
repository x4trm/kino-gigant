namespace KinoGigant
{
  public class Show : IShow
  {
    public string Title { get;set;}
    public DateTime ShowDate {get;set;}
    public DateTime ShowHour {get;set;}
    public List<Seat> Seats {get;set;}
    public int ReservedCount => Seats?.Count(s=>!s.IsReserved) ?? 0;

    public Show() {}

    public Show(string title, DateTime dateTime, DateTime hour, int numberOfSeats)
    {
      Title = title;
      ShowDate = dateTime;
      ShowHour = hour;
      Seats = new List<Seat>();
      InitializeSeats(numberOfSeats);
    }
    public void InitializeSeats(int numberOfSeats)
    {
      for(int i = 1; i<= numberOfSeats; i++)
      {
        Seats.Add(new Seat(i));
      }
    }
  }
}
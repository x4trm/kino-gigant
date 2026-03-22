namespace KinoGigant
{
  public class Program
  {
    public static ShowCatalog catalog = new ShowCatalog();
    public static void Main()
    {
      catalog.SeedSampleShows();
      while (true)
      {
        // MENU
          // CONSOLE.WRITELINE COS TAM
        // petla ktora wyswietla wszystkie fiflmy ktore sa w bazie,
        // dodaje nowy film,
        // przerwanie petli jak wpiszemy jakis numer (Exit)

        string choice = Console.ReadLine();
        Console.WriteLine();
        switch (choice)
        {
          case "1":
            DisplayShows();
            break;
          case "2":
            AddShow();
            break;
          case "3":
            ReserveSeat();
            break;
          case "4":
            Console.WriteLine("Exiting the app....");
            return;
          default:
            Console.WriteLine("Invalid option. Try again.");
            break;
        }
        Console.WriteLine();
      }
    }
    static void ReserveSeat()
    {
      // 1. Sprawdzamy ktory to film
      // 2. Wyswietlamy liste wolnych miejsc
      // 3. Pytamy uzytkowniak o numer miejsca
      // 4. Bierzemy miejsce na podstawie numeru
      // 5. Rezerwujemy miejsce 
      DisplayShows();
      Console.Write("Select show index: ");
      int index = int.Parse(Console.ReadLine());
      var selectedShow = catalog.Shows[index];
      var freeSeats = selectedShow.Seats.Where(s => !s.IsReserved).ToList();
      if(freeSeats.Count == 0)
      {
        Console.WriteLine("No free seats available for this show.");
        return;
      }
      Console.WriteLine("Free seats: ");
      foreach(var seat in freeSeats)
      {
       Console.Write(seat.SeatNumber + " ");
      }  
      Console.WriteLine();
      Console.Write("Choose seat number: ");
      int seatNumber = int.Parse(Console.ReadLine());

      var seatToReseve = selectedShow.Seats.FirstOrDefault( s => s.SeatNumber == seatNumber);
      if(seatToReseve != null && !seatToReseve.IsReserved)
      {
        seatToReseve.Reserve();
        Console.WriteLine($"Seat {seatNumber} reserved!");
      }
      else
      {
        Console.WriteLine("Invalid seat or seat alredy reserved");
      }
    }
    static void DisplayShows()
    {
      foreach(var show in catalog.Shows)
      {
        Console.WriteLine($"{show.Title} -- {show.ShowDate.ToShortDateString()} {show.ShowHour.ToShortTimeString()}");
      }
    }
    static void AddShow()
    {
      Console.WriteLine("Add title: ");
      string title = Console.ReadLine();
      Console.Write("Enter the show date (yyyy-MM-dd): ");
      string dateInput = Console.ReadLine();
      if(!DateTime.TryParse(dateInput, out DateTime showDate))
      {
        Console.WriteLine("Invalid date format.");
        return;
      }
      Console.Write("Eneter the show time (HH:mm): ");
      string timeInput = Console.ReadLine();
      if(!DateTime.TryParse(timeInput, out DateTime tempDateTime))
      {
        Console.WriteLine("Invalid time format.");
        return;
      }
      DateTime showHour = new DateTime(
        showDate.Year,
        showDate.Month,
        showDate.Day,
        tempDateTime.Hour,
        tempDateTime.Minute,
        0
      );
      Console.Write("Enter the number of sets: ");
      if(!int.TryParse(Console.ReadLine(),out int numberOfSeats) || numberOfSeats <= 0)
      {
        Console.WriteLine("Invalid number of setes. Show not added.");
      }
      catalog.Add(new Show(title, showDate, showHour, numberOfSeats));
      Console.WriteLine("New show added successfully!");
    }
  }
}
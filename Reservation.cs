namespace KinoGigant
{
  public class Reservation
  {
    public int ReservationId { get;set;}
    public string ClientName {get;set;}
    public int SeatNumber { get;set;}
    public DateTime ReservedOn { get;set;}
    public string ShowTitle {get;set;}
  }
}
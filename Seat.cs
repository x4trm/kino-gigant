namespace KinoGigant
{
  public class Seat
  {
    public int SeatNumber {get;set;}
    public bool IsReserved { get;set;}

    public Seat(){}

    public Seat(int seatNumber)
    {
      SeatNumber = seatNumber;
      IsReserved = false;
    }
    public void Reserve()
    {
      IsReserved = true;
    }
    public void CancelReservation()
    {
      IsReserved = false;
    }
  }
}
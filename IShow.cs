public interface IShow
{
  string Title {get;set;}
  DateTime ShowDate { get;set;}
  void InitializeSeats(int numberOfSeats);
}
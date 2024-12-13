namespace DoMain.Models;

public class Rental
{
    public int Id { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CustomerId { get; set; }
}
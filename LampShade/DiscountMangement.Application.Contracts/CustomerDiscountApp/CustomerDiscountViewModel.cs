namespace DiscountManagement.Application.Contracts.CustomerDiscountApp;

public class CustomerDiscountViewModel
{
    public long Id { get; set; }
    public string Product { get; set; }
    public int DiscountRate { get; set; }
    public string StartDate { get; set; }
    public DateTime StartDateGr { get; set; }
    public DateTime EndTimeGr { get; set; }
    public string EndDate { get; set; }
    public string DiscountReason { get; set; }
    public long ProductId { get; set; }
    public string CreationDate { get; set; }



}
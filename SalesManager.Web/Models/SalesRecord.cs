using SalesManager.Web.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalesManager.Web.Models;

public class SalesRecord
{
    public int Id { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Date { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Amount { get; set; }
    public SalesStatus Status { get; set; }
    public Seller Seller { get; set; }

    public SalesRecord()
    {
    }

    public SalesRecord(int id, DateTime date, decimal amount, SalesStatus status, Seller seller)
    {
        Id  = id;
        Date = date;
        Amount = amount;
        Status = status;
        Seller = seller;
    }
}
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SalesManager.Web.Models;

public class Seller
{
    public int Id { get; set; }
    
    [Required (ErrorMessage = "Name is required")]
    [StringLength(60), MinLength(3)]
    public string Name { get; set; } = string.Empty;
    
    [DataType(DataType.EmailAddress)]
    [Required (ErrorMessage = "Name is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string Email { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Name is required")]
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    [Required (ErrorMessage = "Name is required")]
    [Display(Name = "Base Salary")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal BaseSalary { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

    public Seller()
    {
    }

    public Seller(int id, string name, string email, DateTime birthDate, decimal baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddSales(SalesRecord salesRecord) => Sales.Add(salesRecord);
    
    public void RemoveSales(SalesRecord salesRecord) => Sales.Remove(salesRecord);
    
    public decimal TotalSales(DateTime initial, DateTime final) => 
        Sales.Where(s => s.Date >= initial && s.Date <= final)
            .Sum(s => s.Amount);
    
} 
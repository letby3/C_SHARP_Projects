using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Users 
{
    [Key]
    public string? fullName { get; set; }

    public DateTime dateBirth { get; set; } 

    public char gender { get; set; }
    
}
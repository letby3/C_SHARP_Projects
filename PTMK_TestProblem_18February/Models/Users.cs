using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Users
{
    [Key]
    public int? id { get; set; }

    public string? fullName { get; set; }

    public DateTime dateBirth { get; set; }

    public char gender { get; set; }


    ~Users()
    {
        fullName = null;        
    }
}
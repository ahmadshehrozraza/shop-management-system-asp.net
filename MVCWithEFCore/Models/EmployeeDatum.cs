using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWithEFCore.Models;

public partial class EmployeeDatum
{
    public int Id { get; set; }

    public byte[]? AImage { get; set; }

    [DisplayName ("Name")]
    [Required]
    public string EName { get; set; } = null!;
    [DisplayName ("Email")]
    [Required]
    public string EEmail { get; set; } = null!;
    [DisplayName ("Phone")]
    [Required]

    public string EPhone { get; set; } = null!;
    [DisplayName ("Job Title")]
    [Required]

    public string EJobTitle { get; set; } = null!;
    [DisplayName ("Joining Date")]
    [Required]

    public DateOnly EJoinDate { get; set; }
    [DisplayName ("Salary")]
    [Required]

    public decimal ESalary { get; set; }
    [DisplayName ("Shift")]
    [Required]

    public string EShift { get; set; } = null!;
}

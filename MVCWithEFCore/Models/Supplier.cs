using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWithEFCore.Models;

public partial class Supplier
{
    public int SupId { get; set; }
    [DisplayName("Name")]
    [Required]
    public string SupName { get; set; } = null!;
    [DisplayName("Phone")]
    [Required]
    public string SupPhone { get; set; } = null!;
    [DisplayName("Email")]
    [Required]
    public string SupEmail { get; set; } = null!;
    [DisplayName("Address")]
    [Required]
    public string SupAddress { get; set; } = null!;
}

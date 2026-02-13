using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCWithEFCore.Models;

public partial class Invenotry
{
    public int ProId { get; set; }
    [Required]
    [DisplayName("Name")]
    public string? ProName { get; set; }

    [Required]
    [DisplayName("Supplier")]
    public string ProSupplier { get; set; } = null!;
    [DisplayName("Category")]
    [Required]
    public string ProCategory { get; set; } = null!;
    [DisplayName("Sub Category")]
    [Required]
    public string ProSubCat { get; set; } = null!;
    [DisplayName("Price Per Item")]
    [Required]
    public decimal ProPricePerItem { get; set; }
    [DisplayName("Quantity")]
    [Required]

    public int ProQuantity { get; set; }
    [DisplayName("Order Price")]
    [Required]
    public decimal ProOrderPrice { get; set; }
    
    


}

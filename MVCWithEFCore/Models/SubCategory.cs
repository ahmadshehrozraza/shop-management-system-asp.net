using System;
using System.Collections.Generic;

namespace MVCWithEFCore.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public virtual Category CategoryNameNavigation { get; set; } = null!;
}

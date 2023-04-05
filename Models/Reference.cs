using System;
using System.Collections.Generic;

namespace cv_fresher_api.Models;

public partial class Reference
{
    public int ReferenceId { get; set; }

    public string EmployerName { get; set; } = null!;

    public string? EmployerCellNumber { get; set; }

    public string EmployerJobTitle { get; set; } = null!;

    public string EmployerCompany { get; set; } = null!;

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace cv_fresher_api.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public string NameOfInstitution { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public int? QualificationDuration { get; set; }

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}

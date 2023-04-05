using System;
using System.Collections.Generic;

namespace cv_fresher_api.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string JobName { get; set; } = null!;

    public DateTime? JobDuration { get; set; }

    public string JobDescription { get; set; } = null!;

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}

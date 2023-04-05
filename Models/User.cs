using System;
using System.Collections.Generic;

namespace cv_fresher_api.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string CellNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string ResidentialAddress { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string Ethinicity { get; set; } = null!;

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();

    public virtual ICollection<Reference> References { get; } = new List<Reference>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}

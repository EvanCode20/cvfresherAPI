using System;
using System.Collections.Generic;

namespace cv_fresher_api.Models;

public partial class Skill
{
    public int SkillsId { get; set; }

    public string SkillsType { get; set; } = null!;

    public string SkillsDescription { get; set; } = null!;

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace KPZ_Lab04.Models;

public partial class Teacher
{
    public int TId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}

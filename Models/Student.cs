using System;
using System.Collections.Generic;

namespace KPZ_Lab04.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public double? AverageMath { get; set; }

    public double? AverageEnglish { get; set; }

    public double? AveragePhilosophy { get; set; }

    public int? TId { get; set; }

    public virtual Teacher? TIdNavigation { get; set; }
}

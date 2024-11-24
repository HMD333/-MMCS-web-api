using System;
using System.Collections.Generic;

namespace HPF_2.Models;

public partial class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public int Salary { get; set; }
    public bool IsLogged { get; set; }

}

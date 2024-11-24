using System;
using System.Collections.Generic;

namespace HPF_2.Models;

public partial class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }

}

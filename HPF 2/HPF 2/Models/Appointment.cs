using System;
using System.Collections.Generic;

namespace HPF_2.Models;

public partial class Appointment
{
    public int Id { get; set; }
    public int PatientHistoryId { get; set; }
    public int Visits { get; set; }
    public int Duration { get; set; }

}

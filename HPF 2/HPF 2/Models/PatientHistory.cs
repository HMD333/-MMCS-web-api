using System;
using System.Collections.Generic;

namespace HPF_2.Models;

public partial class PatientHistory
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public bool TreatmentStat { get; set; }
    public DateTime Time { get; set; }

    

}

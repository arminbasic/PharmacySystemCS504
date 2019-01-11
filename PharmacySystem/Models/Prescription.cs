using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacySystem.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int PatientID { get; set; }
        public virtual Patient patient { get; set; }

        public int MedicineID { get; set; }
        public virtual Medicine medicine{ get; set; }

        public DateTime DateOfPrescription { get; set; }

    }
}
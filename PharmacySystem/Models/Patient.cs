using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacySystem.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string DateOfBirth { get; set; }
        public string InsuranceNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmacySystem.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public int NumberAvailable { get; set; }

        [Required]
        public int MedicinegroupID { get; set; }
        public virtual MedicineGroup MedicineGroup { get; set; }

        [Required]
        public int MedicineFactoryID  { get; set; }
        public virtual MedicineFactory MedicineFactory { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }


        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}

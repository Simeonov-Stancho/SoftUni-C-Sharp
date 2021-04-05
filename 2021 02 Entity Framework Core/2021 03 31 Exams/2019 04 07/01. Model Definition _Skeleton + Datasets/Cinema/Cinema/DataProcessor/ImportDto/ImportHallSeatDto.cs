using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportHallSeatDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        [Required]
        [Range(1, 2147483647)]
        public int Seats { get; set; }
    }
}

//•	Name – text with length [3, 20] (required)
//•	Is4Dx - bool
//•	Is3D - bool
//•	Projections - collection of type Projection
//•	Seats - collection of type Seat

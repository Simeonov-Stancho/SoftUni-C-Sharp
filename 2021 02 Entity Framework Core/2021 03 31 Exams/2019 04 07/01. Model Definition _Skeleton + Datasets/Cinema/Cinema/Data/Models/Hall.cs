﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    public class Hall
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        public virtual ICollection<Projection> Projections { get; set; } = new HashSet<Projection>();

        public virtual ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}

//•	Id – integer, Primary Key
//•	Name – text with length [3, 20] (required)
//•	Is4Dx - bool
//•	Is3D - bool
//•	Projections - collection of type Projection
//•	Seats - collection of type Seat

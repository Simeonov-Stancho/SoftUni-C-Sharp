using Cinema.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportMovieDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]       // check it
        public string Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range (1.00, 10.00)]
        public double Rating { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Director { get; set; }
    }
}

//•	Title – text with length [3, 20] (required)
//•	Genre – enumeration of type Genre, with possible values (Action, Drama, Comedy, Crime, Western, Romance, Documentary, Children, Animation, Musical) (required)
//•	Duration – TimeSpan(required)
//•	Rating – double in the range[1, 10] (required)
//•	Director – text with length [3, 20] (required)

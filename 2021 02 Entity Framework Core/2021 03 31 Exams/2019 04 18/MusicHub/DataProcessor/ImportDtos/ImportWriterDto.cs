using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportWriterDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }
    }
}

//•	Name– text with min length 3 and max length 20 (required)
//•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters (Example: "Freddie Mercury")


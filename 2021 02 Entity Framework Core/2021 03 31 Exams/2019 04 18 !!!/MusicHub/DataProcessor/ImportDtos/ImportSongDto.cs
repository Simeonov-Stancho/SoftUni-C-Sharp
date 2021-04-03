using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public int WriterId { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}

//Name – text with min length 3 and max length 20 (required)
//•	Duration – TimeSpan(required)
//•	CreatedOn – Date(required)
//•	Genre ¬– Genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz"(required)
//•	AlbumId– integer foreign key
//•	WriterId - integer, foreign key (required)
//•	Price – decimal (non-negative, minimum value: 0) (required)

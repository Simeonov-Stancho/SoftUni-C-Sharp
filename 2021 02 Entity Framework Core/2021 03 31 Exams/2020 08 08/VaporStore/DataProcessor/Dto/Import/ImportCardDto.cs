using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}")]
        public string CVC { get; set; }

        [Required]
        //[EnumDataType(typeof(CardType))]
        public string Type { get; set; }

    }
}
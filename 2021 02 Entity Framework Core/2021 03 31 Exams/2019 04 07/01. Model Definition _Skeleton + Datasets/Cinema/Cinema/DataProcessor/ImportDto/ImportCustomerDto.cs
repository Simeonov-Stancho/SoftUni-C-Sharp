using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [Required]
        [XmlElement("FirstName")]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [XmlElement("LastName")]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [XmlElement("Age")]
        [Range(12, 110)]
        public int Age { get; set; }

        [Required]
        [XmlElement("Balance")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [Required]
        [XmlArray("Tickets")]
        public virtual List<ImportTicketDto> Tickets { get; set; }
    }
}

//•	FirstName – text with length [3, 20] (required)
//•	LastName – text with length [3, 20] (required)
//•	Age – integer in the range[12, 110] (required)
//•	Balance - decimal(non - negative, minimum value: 0.01)(required)
//•	Tickets - collection of type Ticket

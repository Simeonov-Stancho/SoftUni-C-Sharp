using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ExportDto
{
    [XmlType("Customer")]
    public class ExportCustomerDto
    {
        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlElement]
        public string SpentMoney { get; set; }

        [XmlElement]
        public string SpentTime { get; set; }
    }
}

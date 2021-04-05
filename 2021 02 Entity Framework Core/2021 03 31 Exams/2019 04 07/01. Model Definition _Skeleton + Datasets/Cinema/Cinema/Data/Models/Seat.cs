using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	HallId – integer, foreign key (required)
//•	Hall – the seat’s hall 

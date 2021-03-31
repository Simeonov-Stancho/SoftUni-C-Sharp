using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
        public int GameId { get; set; }
        [Required]
        public Game Game { get; set; }

        public int TagId { get; set; }
        [Required]
        public Tag Tag { get; set; }
    }
}

//•	GameId – integer, Primary Key, foreign key (required)
//•	Game – Game
//•	TagId – integer, Primary Key, foreign key (required)
//•	Tag – Tag

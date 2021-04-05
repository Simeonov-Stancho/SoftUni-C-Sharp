using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => this.Songs.Sum(s => s.Price);

        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();

    }
}

//•	Id – integer, Primary Key
//•	Name – text with min length 3 and max length 40 (required)
//•	ReleaseDate – Date(required)
//•	Price – calculated property(the sum of all song prices in the album)
//•	ProducerId – integer foreign key
//•	Producer – the album’s producer
//•	Songs – collection of all songs in the album 

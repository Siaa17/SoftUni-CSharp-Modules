﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price => Songs.Sum(x => x.Price);

        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

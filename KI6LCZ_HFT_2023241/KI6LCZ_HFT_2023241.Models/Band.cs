﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Models
{
    public class Band
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BandName { get; set; }
        public int Year { get; set; }
        [NotMapped]
        public virtual ICollection<Album> Albums { get; set; }

        public int AlbumCounter { get => Albums.Count; }

        public Band()
        {
             Albums = new List<Album>();
        }

    }
}

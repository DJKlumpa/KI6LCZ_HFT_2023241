﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KI6LCZ_HFT_2023241.Models
{
    public class Music
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public double Length { get; set; }
        public string Genre { get; set; }

        [NotMapped]
        public string AllData => $"[{Id}] => {Title} - {Album} - {Length} - {Genre}";

    }
}

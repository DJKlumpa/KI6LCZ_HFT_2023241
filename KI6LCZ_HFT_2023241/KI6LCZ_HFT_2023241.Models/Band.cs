using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }

        public int AlbumCounter;

        public string AllData => $"[{Id}] => {BandName} - {Year} - {Albums} - {AlbumCounter}";
        public Band()
        {
             Albums = new List<Album>();
        }

    }
}

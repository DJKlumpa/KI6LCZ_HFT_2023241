using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KI6LCZ_HFT_2023241.Models
{
    public class Album
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AlbumName { get; set; }
        [ForeignKey(nameof(Band))]
        public int BandId { get; set;}
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public virtual Band Band { get; set; }
        [NotMapped]
        public virtual ICollection<Music> Musics { get; set; }

        [NotMapped]
        public string AllData => $"[{Id}] => {AlbumName} - {BandId} - {Year} - {Genre}";

        public Album()
        {
            Musics = new List<Music>();
        }
        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as Music).Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Year, AlbumName);
        }
    }
}

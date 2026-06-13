using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Game :BaseEntity
    {

        [MaxLength(length: 3000)]
        public string Description { get; set; } = string.Empty;


        [MaxLength(length: 250)]
        public string Cover { get; set; } = string.Empty;

        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        public Category Categorie { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}

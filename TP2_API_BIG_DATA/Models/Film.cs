using NpgsqlTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2_API_BIG_DATA.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int RentalDuration { get; set; }
        public Decimal  RentalRate { get; set; }
        public int Length { get; set; }
        public  Decimal ReplacementCost { get; set; }

        public String Rating { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<String> SpecialFeatures { get; set; }
        public NpgsqlTsVector Fulltext { get; set; }
    }
}

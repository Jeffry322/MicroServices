using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public sealed class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Director { get; set; }
    }
}

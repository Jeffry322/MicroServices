using System.ComponentModel.DataAnnotations;

namespace MovieService.DTOs
{
    public sealed class MovieWriteDTO
    {
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

﻿using System.ComponentModel.DataAnnotations;

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

        public Movie(string title, DateTime year, string genre, string director)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Director = director;
        }
    }
}

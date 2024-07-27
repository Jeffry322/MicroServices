namespace MovieService.DTOs
{
    public sealed class MovieDTO
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        public MovieDTO(string title, DateTime year, string genre, string director)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Director = director;
        }
    }
}

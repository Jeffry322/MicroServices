namespace MovieService.DTOs
{
    public sealed class MovieReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
    }
}

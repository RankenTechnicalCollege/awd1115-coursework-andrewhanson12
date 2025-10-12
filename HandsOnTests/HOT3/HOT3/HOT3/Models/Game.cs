using System.ComponentModel.DataAnnotations;

namespace HOT3.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        public string? Genre { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        [Range(1950, 2100, ErrorMessage = "Year must be between 1980 and 2026.")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Developer is required.")]
        public string? Developer { get; set; }
        [Required(ErrorMessage = "Publisher is required.")]
        public string? Publisher { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal? Price { get; set; }
        public string? ImageFileName { get; set; }
        public string Slug => $"{Name}-{Genre}-{Year}".ToLower().Replace(' ', '-');
    }
}

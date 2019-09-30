using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class Bench
    {
        public int Id { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }

        public int PosterId { get; set; }
        public User Poster { get; set; }
    }
}
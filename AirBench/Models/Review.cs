using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirBench.Models
{
    public class Review
    {
        public Review() { }

        public Review(int id, decimal rating, string description)
        {
            Id = id;
            Rating = rating;
            Description = description;
        }

        public int Id { get; set; }
        public decimal Rating { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }

        public int BenchId { get; set; }
        public Bench Bench { get; set; }

        public int PosterId { get; set; }
        public User Poster { get; set; }
    }
}
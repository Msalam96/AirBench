using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }

        public int BenchId { get; set; }
        public Bench Bench { get; set; }
    }
}
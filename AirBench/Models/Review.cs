using System;
using System.ComponentModel.DataAnnotations;

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
            postDate = DateTimeOffset.Now;
        }

        public int Id { get; set; }
        public decimal Rating { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        public DateTimeOffset postDate { get; set; }

        public int BenchId { get; set; }
        public Bench Bench { get; set; }

        public int PosterId { get; set; }
        public User Poster { get; set; }
    }
}
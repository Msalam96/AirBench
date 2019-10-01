using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class Bench
    {
        public Bench()
        {
            Reviews = new List<Review>();
        }

        public Bench(int id, decimal rating, string description, 
            int seats, decimal latitude, decimal longitude) : this()
        {
            Id = id;
            Rating = rating;
            Description = description;
            Seats = seats;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Id { get; set; }
        public decimal Rating { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        public int Seats { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int PosterId { get; set; }
        public User Poster { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
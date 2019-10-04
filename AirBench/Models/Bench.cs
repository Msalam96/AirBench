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

        public Bench(int id, string description, 
            int seats, decimal latitude, decimal longitude) : this()
        {
            Id = id;
            Description = description;
            Seats = seats;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Id { get; set; }
        public decimal? Rating { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        public int Seats { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int PosterId { get; set; }
        public User Poster { get; set; }

        public List<Review> Reviews { get; set; }

        public void CalculateRating(List<Review> reviews)
        {
            decimal total = 0;
            for(int i = 0; i < reviews.Count; i++)
            {
                total += reviews[i].Rating;
            }

            Rating = total / reviews.Count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
      
        public string ShortDescription
        {
            get
            {
                string description = Description;
                string shortDescription = string.Empty;

                // Make sure that we have a description...
                if (!string.IsNullOrWhiteSpace(description))
                {
                    // Get a collection of the words in the description.
                    var words = description
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // If we have more than 10 words
                    // then take the first 10 and add "..." to the end
                    // otherwise just use the description as is. 
                    if (words.Length > 10)
                    {
                        shortDescription = string.Join(" ", words.Take(10)) + "...";
                    }
                    else
                    {
                        shortDescription = description;
                    }                    
                }

                return shortDescription;
            }
    }
}
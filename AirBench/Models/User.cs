using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirBench.Models
{
    public class User
    {
        public User() {
            Benches = new List<Bench>();
            Reviews = new List<Review>();
        }

        public User(int id, string email, string lastName, string firstName, string hashedPassword)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            HashedPassword = hashedPassword;
        }
  
        public int Id { get; set; }
        [Required, MaxLength(255)]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string FirstName { get; set; }
        [Required, MaxLength(255)]
        public string LastName { get; set; }
        [Required, MaxLength(255)]
        public string HashedPassword { get; set; }

        public List<Bench> Benches { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
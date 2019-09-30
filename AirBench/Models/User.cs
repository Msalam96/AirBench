using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class User
    {
        public User() { }

        public User(int id, string userName, string hashedPassword)
        {
            Id = id;
            UserName = userName;
            HashedPassword = hashedPassword;
        }

        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string UserName { get; set; }
        [Required, MaxLength(255)]
        public string HashedPassword { get; set; }
    }
}
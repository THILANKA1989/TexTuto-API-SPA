using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Follower
    {
        public int id {get;set;}

        [ForeignKey("User")]
        public int user_id {get;set;}

        [ForeignKey("User")]
        public int follower_id {get;set;}
        public DateTime followed_date {get;set;}

        public User User {get;set;}
    }
}
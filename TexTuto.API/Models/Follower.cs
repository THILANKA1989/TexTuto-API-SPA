using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Follower
    {

        [ForeignKey("User")]
        public int user_id {get;set;}

        [ForeignKey("UFollower")]
        public int follower_id {get;set;}

        public virtual User User {get;set;}
        public virtual User UFollower {get;set;}
        
    }
}
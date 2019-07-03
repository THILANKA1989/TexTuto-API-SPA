using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Comment
    {
        public int id {get;set;}
        public Boolean is_enabled {get;set;}
        public DateTime created_date {get;set;}
        public DateTime updated_date {get;set;}
        [Column(TypeName = "text")]
        public string content { get; set; }

        [ForeignKey("User")]
        public int user_id {get;set;}
        public User User {get;set;}

        [ForeignKey("Article")]
        public int article_id {get;set;}
        public Article Article {get;set;}
        public ICollection<Reply> Replies { get; set; }

    }
}
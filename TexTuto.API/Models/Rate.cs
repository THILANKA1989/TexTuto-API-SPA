using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Rate
    {
        public int id {get;set;}
        public string description {get;set;}
        public float rate {get;set;}
        public DateTime created_date {get;set;}
        public DateTime updated_date {get;set;}
        [ForeignKey("User")]
        public int user_id {get;set;}
        [ForeignKey("Article")]
        public int article_id {get;set;}
        public User User {get;set;}
        public Article Article {get;set;}
        
    }
}
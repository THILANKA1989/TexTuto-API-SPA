using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Step
    {
        public int id {get;set;}
        [Column(TypeName = "text")]
        public string content {get;set;}
        public DateTime created_date {get;set;}
        public DateTime updated_date {get;set;}
        public Boolean is_enabled {get;set;}
        
        [ForeignKey("Article")]
        public int article_id {get;set;}
        public Article Article {get;set;}
    }
}
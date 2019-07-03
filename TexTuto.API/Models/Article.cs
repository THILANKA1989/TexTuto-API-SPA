using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Article
    {
        public int id {get;set;}
        public string title {get;set;}
        public DateTime created_date  {get;set;}
        public DateTime updated_date {get;set;}
        public Boolean is_enabled {get;set;}
        public int sub_category {get;set;}

        [ForeignKey("User")]
        public int user_id {get;set;}
        public User User {get;set;}
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Step> Steps { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<FollowsArticle> FollowsArticles { get; set; }
    }
}
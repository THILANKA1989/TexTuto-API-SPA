using System;
using System.Collections.Generic;

namespace TexTuto.API.Models
{
    public class User
    {
        public int id {get;set;}
        public string firstname {get;set;}
        public string lastname {get;set;}
        public string job {get;set;}
        public DateTime joined_date {get;set;}
        public DateTime modified_date {get;set;}
        public Boolean is_activated {get;set;}
        public int role {get;set;}
        public ICollection<Article> Articles {get;set;}
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Follower> Following { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<FollowsArticle> FollowsArticles { get; set; }

    }
}
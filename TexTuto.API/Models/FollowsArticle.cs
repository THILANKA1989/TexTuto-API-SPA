using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class FollowsArticle
    {
        public int id {get;set;}
       [ForeignKey("User")]
        public int user_id {get;set;}
        public User User {get;set;}

        [ForeignKey("Article")]
        public int article_id {get;set;}
        public Article Article {get;set;}
    }
}
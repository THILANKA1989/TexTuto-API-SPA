using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class Reply
    {
        public int id {get;set;}
        [Column(TypeName = "text")]
        public string content { get; set; }
        public DateTime created_date {get;set;}
        public DateTime updated_date {get;set;}
        [ForeignKey("User")]
        public int user_id {get;set;}
        [ForeignKey("Comment")]
        public int comment_id {get;set;}
        public User User {get;set;}
        public Comment Comment {get;set;}
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexTuto.API.Models
{
    public class SubCategory
    {
        public int id {get;set;}
        public string description {get;set;}
        public Boolean is_enabled {get;set;}

        [ForeignKey("Category")]
        public int category_id {get;set;}
        public Category Category {get;set;}
    }
}
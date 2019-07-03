using System;
using System.Collections.Generic;

namespace TexTuto.API.Models
{
    public class Category
    {
        public int id {get;set;}
        public int description {get;set;}
        public Boolean is_enabled {get;set;}
        public ICollection<SubCategory> SubCategories {get;set;}
    }
}
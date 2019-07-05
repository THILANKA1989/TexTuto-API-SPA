using Microsoft.EntityFrameworkCore;
using TexTuto.API.Models;

namespace TexTuto.API.Data
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Follower>()
            .HasKey(x => new { x.user_id,x.follower_id });

            modelBuilder.Entity<Follower>()
            .HasOne(e => e.User)
            .WithMany(e => e.Followers);

            modelBuilder.Entity<Follower>()
            .HasOne(e => e.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Value> Values { get;set; }
        public DbSet<User> Users {get;set;}
        public DbSet<Article> Articles {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Comment> Comments {get;set;}
        public DbSet<FollowsArticle> FollowsArticles {get;set;}
        public DbSet<Rate> Rates {get;set;}
        public DbSet<Follower> Followers {get;set;}
        public DbSet<Reply> Replies {get;set;}
        public DbSet<Step> Steps {get;set;}
        public DbSet<SubCategory> SubCategories {get;set;}
        
    }
}
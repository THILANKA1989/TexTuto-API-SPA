using Microsoft.EntityFrameworkCore;
using TexTuto.API.Models;

namespace TexTuto.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Value> Values { get;set; }
        
    }
}
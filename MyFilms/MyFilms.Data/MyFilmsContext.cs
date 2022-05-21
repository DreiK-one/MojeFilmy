using Microsoft.EntityFrameworkCore;
using MyFilms.Data.Entities;


namespace MyFilms.Data
{
    public class MyFilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public MyFilmsContext(DbContextOptions<MyFilmsContext> options) 
            : base(options)
        {
             
        }
    }
}

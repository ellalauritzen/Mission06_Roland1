using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mission06_Roland1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Roland1.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options)
        {
        }
        public DbSet<AddMovie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}

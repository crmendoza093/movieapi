using System;
using Microsoft.EntityFrameworkCore;

namespace movieapi.models
{
    public class FilmsContext : DbContext
    {
        public FilmsContext(DbContextOptions<FilmsContext> options) : base(options)
        {
        }

        public DbSet<FilmsItem> filmsItems { get; set; }
    }
}

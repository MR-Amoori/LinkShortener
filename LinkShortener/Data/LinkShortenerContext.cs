using LinkShortener.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data
{
    public class LinkShortenerContext : DbContext
    {

        public LinkShortenerContext(DbContextOptions<LinkShortenerContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<ShortUrl> ShortUrl { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => new { u.UserId });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    Email = "mohamad.reza.amoori99@gmail.com",
                    IsAdmin = true,
                    NumberPhone = "09035170373",
                    Password = "mohamad021",
                    RegisterDate = System.DateTime.Now,
                    UserName = "محمدرضاعموری"
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
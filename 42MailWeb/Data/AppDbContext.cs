using Microsoft.EntityFrameworkCore;
using _42MailLibray.Entities;

namespace _42MailWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Mail> Mails { get; set; } 
    }
}

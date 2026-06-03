using Microsoft.EntityFrameworkCore;
using web_fullstack_aspnetcore_mvc.Models;

namespace web_fullstack_aspnetcore_mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
                
        public DbSet<Customer> Customers { get; set; }
    }
}
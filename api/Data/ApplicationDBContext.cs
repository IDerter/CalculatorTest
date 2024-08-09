using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {
        
    }        

    public DbSet<Calculator> Calculations { get; set; }
}

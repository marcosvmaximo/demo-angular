using CarrocinhaDoBem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CarrocinhaDoBem.Api.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Adoption> Adoptions { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Sponsorship> Sponsorships { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}
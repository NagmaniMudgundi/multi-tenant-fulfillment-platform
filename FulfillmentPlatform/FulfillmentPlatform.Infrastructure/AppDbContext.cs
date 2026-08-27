using Microsoft.EntityFrameworkCore;
using FulfillmentPlatform.Domain;

namespace FulfillmentPlatform.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tenant> Tenants => Set<Tenant>();
}
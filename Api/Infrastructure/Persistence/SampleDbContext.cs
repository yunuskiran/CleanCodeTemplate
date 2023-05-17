using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Persistence;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options)
       : base(options)
    {
    }
}

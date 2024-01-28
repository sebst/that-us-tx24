using Microsoft.EntityFrameworkCore;

namespace that_us_tx24.Models;

public class ConferenceContext : DbContext
{
    public ConferenceContext(DbContextOptions<ConferenceContext> options)
        : base(options)
    {
    }

    public DbSet<SessionItem> SessionItems { get; set; } = null!;
    public DbSet<MemberItem> MemberItems { get; set; } = null!;
}
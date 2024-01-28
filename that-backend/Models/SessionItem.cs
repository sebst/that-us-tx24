namespace that_us_tx24.Models;

public class SessionItem
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public DateTime StartTime { get; set; }
    public MemberItem[] Speakers { get; set; } = null!;
}
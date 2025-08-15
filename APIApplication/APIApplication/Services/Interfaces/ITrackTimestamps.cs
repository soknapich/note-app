namespace APIApplication.Services.Interfaces
{
    public interface ITrackTimestamps
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}

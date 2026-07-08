namespace AndrewTech.Domain.Modules;

public record IssueDetails()
{
    public List<File> Files { get; private set; }
}
using AndrewTech.Domain.Shared;

namespace AndrewTech.Domain.Modules;

public sealed class Module : Shared.Entity<ModuleId>
{
    private readonly List<Issue> _issues = [];
    
    //ef core
    private Module(ModuleId id): base(id)//constructo gol
    {
        
    }
    
    private Module(ModuleId moduleId, string title, string description) 
        : base(moduleId)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; private set; } = default!; //aici nu va fi valoare niciodata null

    public string Description { get; private set; } = default!;

    public IReadOnlyList<Issue> Issues => _issues;

    public int GetNumberOfIssues() => _issues.Count;

    public void AddIssue(Issue issue)
    {
        //validation
        _issues.Add(issue);
    }

    public static Result<Module> Create(ModuleId moduleId, string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            return "Title can not to empty";
        
        if (string.IsNullOrWhiteSpace(description))
            return "Description can not to empty";

        var module = new Module(moduleId, title, description);
        return module;
    }
}


namespace AOC.Models;

public class DirectoryDaySeven : INodeDaySeven
{
    private readonly List<INodeDaySeven> _children; 
    public DirectoryDaySeven(string name, DirectoryDaySeven? parent)
    {
        Name = name;
        Size = 0;
        Parent = parent;
        
        _children = new List<INodeDaySeven>();
    }

    public string Name { get; }
    public long Size { get; set; }
    public IReadOnlyCollection<INodeDaySeven> Children => _children;
    
    public DirectoryDaySeven? Parent { get; } 
    
    public void AddChild(INodeDaySeven node)
    {
        if (_children.Contains(node))
        {
            return;
        }
        _children.Add(node);
    }

    protected bool Equals(DirectoryDaySeven other)
    {
        return Name == other.Name && Equals(Parent, other.Parent);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DirectoryDaySeven)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Parent);
    }
}
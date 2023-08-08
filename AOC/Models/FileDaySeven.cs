namespace AOC.Models;

public class FileDaySeven : INodeDaySeven, IEquatable<FileDaySeven>
{
    public FileDaySeven(int size, string name)
    {
        Name = name;
        ByteSize = size;
    }
    public string Name { get; }
    public int ByteSize { get; }

    public bool Equals(FileDaySeven? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && ByteSize == other.ByteSize;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FileDaySeven)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ByteSize);
    }
}
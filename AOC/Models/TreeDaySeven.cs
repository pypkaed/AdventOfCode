namespace AOC.Models;

public class TreeDaySeven
{
    public TreeDaySeven(DirectoryDaySeven root)
    {
        Root = root;
    }
    public DirectoryDaySeven Root { get; set; }

    public int CalculateDirSize(DirectoryDaySeven node)
    {
        int res = 0;

        foreach (var child in node.Children)
        {
            if (child is DirectoryDaySeven)
            {
                var dir = child as DirectoryDaySeven;
                if (dir.Size == 0)
                {
                    res += CalculateDirSize(dir);
                }
                else
                {
                    res += dir.Size;
                }
            }
            else
            {
                res += (child as FileDaySeven).ByteSize;
            }
        }

        node.Size = res;
        return res;
    }
    public void CalculateDirSizes()
    {
        CalculateDirSize(Root);
    }
}

using UtilityLibrary.Classes;
[System.Serializable]
public abstract class Node
{
    /// <summary>
    /// Node's coordinates
    /// </summary>
    public Position pos;

    public Node()
    {
    }

    protected Node(Position pos)
    {
        this.pos = pos;
    }

    public override string ToString()
    {
        return "Node " + pos.ToString();
    }

}

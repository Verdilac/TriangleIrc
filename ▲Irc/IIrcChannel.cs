namespace TriangleIrc
{
    public interface IIrcChannel
    {
        string Name { get; set; }

        void Print(string message);
        void PrintLine(string message);
    }
}

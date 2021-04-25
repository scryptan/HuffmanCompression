namespace HuffmanCompression
{
    public class Node
    {
        public char? Symbol { get; set; }
        public bool Code { get; set; }
        public int Frequency { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }

        public static bool operator >(Node first, Node other) => first.Frequency > other.Frequency;
        public static bool operator <(Node first, Node other) => first.Frequency < other.Frequency;
        public static bool operator >=(Node first, Node other) => first.Frequency >= other.Frequency;
        public static bool operator <=(Node first, Node other) => first.Frequency <= other.Frequency;
    }
}
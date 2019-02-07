namespace DataStructuresAndAlgorithms.Graphs
{
    internal class Subset<T>
    {

        public Node<T> Parent { get; set; }
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"Subset with rank {Rank}, parent: {Parent.Data}  (index: { Parent.Index})"; 
        }
    }
}
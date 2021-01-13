using System.Drawing;

namespace ShenAlgorithms.RedBlackTree
{
    public class RBNode<T> : BaseNode
    {
        public int Key { get; set; }
        public T mainObject { get; set; }
        public RBNode<T> Parent { get; set; }        
        public RBNode<T> LeftBranch { get; set; }
        public RBNode<T> RightBranch { get; set; }      
        public RBNode()
        {
            
        }  
        public RBNode(RBNode<T> parentNode, T o, int key, Color color)
        {
            Key = key;
            mainObject = o;
            Parent = parentNode;
            LeftBranch = new RBNode<T>();
            RightBranch = new RBNode<T>();
            NodeColor = color;
        }
    }
}
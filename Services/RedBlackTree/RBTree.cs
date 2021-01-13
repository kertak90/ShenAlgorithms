using System.Drawing;

namespace ShenAlgorithms.RedBlackTree
{
    public class RBTree<T> : object
    {
        public RBNode<T> rootNode;
        private int NodeCount;
        public RBTree(T obj)
        {
            rootNode = new RBNode<T>(null, obj, NodeCount++, Color.Black);
        }
        public void AddNewKey(int key, T obj)
        {
            AddNodeInTree(rootNode, key, obj);
        }
        private void AddNodeInTree(RBNode<T> parent, int key, T obj)
        {
            //Если ключ меньше ключа этой ноды, то добавляем в левую ветку
            if(key < parent.Key)
            {
                if(parent.LeftBranch == null)
                {
                    parent.LeftBranch = new RBNode<T>(parent, obj, key, CalculateColor(parent));
                }
                else
                {
                    AddNodeInTree(parent.LeftBranch, key, obj);
                }
            }
            //если ключ больше ключа этой ноды, то добавляем в правую ветку
            else if(key > parent.Key)
            {
                if(parent.RightBranch == null)
                {
                    parent.LeftBranch = new RBNode<T>(parent, obj, key, CalculateColor(parent));
                }
                else
                {
                    AddNodeInTree(parent.RightBranch, key, obj);
                }
            }
            //если ключ совпал, то в дерево не добавляем его
            else
            {
                return;
            }
        }
        private Color CalculateColor(RBNode<T> node)
        {
            //у ноды имеющей красный цвет, потомки будут черные
            if(node.NodeColor == Color.Red)
                return Color.Black;
            //у ноды имеющей черный цвет, потомки могут быть и красные и черные
            else
            {
                return Color.Red;   //пока цвет будет красный
            }
        }
        public void PrintTree()
        {

        }
    }
}
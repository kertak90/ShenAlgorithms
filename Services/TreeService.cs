using ShenAlgorithms.RedBlackTree;

namespace ShenAlgorithms.Services
{
    public class TreeService
    {
        public TreeService()
        {
            
        }
        public void CreateRBTree(int n = 10)
        {
            var tree = new RBTree<int>(1);
            for(int i = 1; i < n; i++)
            {
                tree.AddNewKey(i, i);
            }
            System.Console.ReadLine();
        }
    }
}
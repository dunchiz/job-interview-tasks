//c# task:
//Expression modelule consists of teo type on nodes
//• Terminal nodes (variable names)
//• Binary arithmetical operations (+ - * /)
//Having expression tree as input, you need to convert it to an infix notation text entry.
//In this case, it is necessary to use the minimum number of brackets
//(brackets are used only when necessary to preserve the order of calculations according to arithmetic rules).





using System.Linq.Expressions;

namespace InfixNotationTaskNS
{
    public class Program
    {
        public static void Main()
        {
            ExpressionTreeNode root = new ExpressionTreeNode("*");
            ExpressionTreeNode left = root.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode right = root.AddRightNode(NodeTypeEnum.Operation, "*");
            left.AddLeftNode(NodeTypeEnum.Variable, "a");
            left.AddRightNode(NodeTypeEnum.Variable, "b");
            right.AddLeftNode(NodeTypeEnum.Variable, "c");
            right.AddRightNode(NodeTypeEnum.Variable, "d");

            string s = root.ToString();
            Console.WriteLine(s);


            ExpressionTreeNode root1 = new ExpressionTreeNode("*");

            ExpressionTreeNode rl = root1.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode rr = root1.AddRightNode(NodeTypeEnum.Operation, "+");

            ExpressionTreeNode rll = rl.AddLeftNode(NodeTypeEnum.Operation, "*");
            ExpressionTreeNode rlr = rl.AddRightNode(NodeTypeEnum.Operation, "/");

            ExpressionTreeNode rrl = rr.AddLeftNode(NodeTypeEnum.Operation, "/");
            ExpressionTreeNode rrr = rr.AddRightNode(NodeTypeEnum.Operation, "*");

            ExpressionTreeNode rlll = rll.AddLeftNode(NodeTypeEnum.Operation, "+");
            ExpressionTreeNode rllr = rll.AddRightNode(NodeTypeEnum.Operation, "-");

            ExpressionTreeNode rlrl = rlr.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode rlrr = rlr.AddRightNode(NodeTypeEnum.Operation, "+");

            ExpressionTreeNode rrll = rrl.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode rrlr = rrl.AddRightNode(NodeTypeEnum.Operation, "+");

            ExpressionTreeNode rrrl = rrr.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode rrrr = rrr.AddRightNode(NodeTypeEnum.Operation, "+");

            rlll.AddRightNode(NodeTypeEnum.Variable, "a");
            rlll.AddLeftNode(NodeTypeEnum.Variable, "b");
            rllr.AddRightNode(NodeTypeEnum.Variable, "c");
            rllr.AddLeftNode(NodeTypeEnum.Variable, "d");
            rlrl.AddRightNode(NodeTypeEnum.Variable, "e");
            rlrl.AddLeftNode(NodeTypeEnum.Variable, "f");
            rlrr.AddRightNode(NodeTypeEnum.Variable, "g");
            rlrr. AddLeftNode(NodeTypeEnum.Variable, "h");
            rrll.AddRightNode(NodeTypeEnum.Variable, "i");
            rrll.AddLeftNode(NodeTypeEnum.Variable, "j");
            rrlr.AddRightNode(NodeTypeEnum.Variable, "k");
            rrlr.AddLeftNode(NodeTypeEnum.Variable, "l");
            rrrl.AddRightNode(NodeTypeEnum.Variable, "m");
            rrrl.AddLeftNode(NodeTypeEnum.Variable, "n");
            rrrr.AddRightNode(NodeTypeEnum.Variable, "o");
            rrrr.AddLeftNode(NodeTypeEnum.Variable, "p");


            string s1 = root1.ToString();
            Console.WriteLine(s1);
        }
    }


}
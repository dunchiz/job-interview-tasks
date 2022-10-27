using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixNotationTaskNS
{

    /// <summary>
    /// Expression tree node types
    /// </summary>
    public enum NodeTypeEnum { Variable, Operation }
    /// <summary>
    /// Expression tree node
    /// </summary>
    public class ExpressionTreeNode
    {
        /// <summary>
        /// Initiaalizes expression tree node
        /// </summary>
        /// <param name="value"></param>
        public ExpressionTreeNode(string value)
        {
            this.value = value;
            this.NodeType = NodeTypeEnum.Operation;
        }
        private ExpressionTreeNode(NodeTypeEnum nt, string value)
        {
            this.NodeType = nt;
            this.value = value;
        }

        /// <summary>
        /// Adding left son
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ExpressionTreeNode AddLeftNode(NodeTypeEnum type, string value)
        {
            ExpressionTreeNode etn = new ExpressionTreeNode(type, value);
            etn.Parent = this;
            this.Left = etn;
            return etn;
        }


        /// <summary>
        /// Adding right son
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ExpressionTreeNode AddRightNode(NodeTypeEnum type, string value)
        {
            ExpressionTreeNode etn = new ExpressionTreeNode(type, value);
            etn.Parent = this;
            this.Right = etn;
            return etn;
        }

        public NodeTypeEnum NodeType;
        public ExpressionTreeNode Parent;
        public ExpressionTreeNode Left;
        public ExpressionTreeNode Right;
        public string value;

        /// <summary>
        /// Returns string representation of expressiont tree
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.NodeType == NodeTypeEnum.Variable)
            {
                //checking for the father of a node to be of type variable
                if (this.Parent == null) throw new Exception("Incorrect tree (variable node must have a parent)");
                //checking for the father of a variable node to be of type opearation (a node of type variable must have a father node type operation)
                if (this.Parent.NodeType != NodeTypeEnum.Operation) throw new Exception("Incorrect tree (variable node must have parent node of type operation)");
                //checking for the presence of children (a variable type node must not have children)
                if (this.Left != null || this.Right != null) throw new Exception("Incorrent tree (variable node has child leaves)");
                //checking for the validity of variable names
                foreach (char c in value) if (!Char.IsLetter(c)) throw new Exception("Incorrect tree (Incorrect variable name)");

                return this.value;
            }
            else if (this.NodeType == NodeTypeEnum.Operation)
            {
                //checking for the type of the parent (if there is a parent, then node must be an operation type)
                if (this.Parent != null) if (this.Parent.NodeType != NodeTypeEnum.Operation) throw new Exception("Incorrect tree (operation type node must have operation type parent)");
                //checking for the presence of children (a node of type operation must have two children)
                if (this.Left == null || this.Right == null) throw new Exception("Incorrect tree (operation node must have two child leaves)");

                //Brackets are places if:
                //parent has priority operation (*/), and a child has not (+-)
                //if parent requires brackets then adding them
                if (this.Parent != null && "*/".Contains(Parent.value) && "+-".Contains(this.value))
                    return "(" + Left.ToString() + this.value + Right.ToString() + ")";
                else
                    return Left.ToString() + this.value + Right.ToString();
            }
            else throw new Exception("Unknown node type");
        }
    }

}

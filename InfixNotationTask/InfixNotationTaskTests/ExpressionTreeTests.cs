using InfixNotationTaskNS;

namespace InfixNotationTaskTests
{
    [TestClass]
    public class ExpressionTreeTests
    {
        /// <summary>
        /// ��������� ���������� ������ ������
        /// </summary>
        [TestMethod]
        public void TestSimpleTree()
        {
            // Arrange
            ExpressionTreeNode root = new ExpressionTreeNode("*");
            ExpressionTreeNode left = root.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode right = root.AddRightNode(NodeTypeEnum.Operation, "*");
            left.AddLeftNode(NodeTypeEnum.Variable, "a");
            left.AddRightNode(NodeTypeEnum.Variable, "b");
            right.AddLeftNode(NodeTypeEnum.Variable, "c");
            right.AddRightNode(NodeTypeEnum.Variable, "d");


            // Act
            string res = root.ToString();


            // Assert
            string expected = "(a-b)*c*d";
            Assert.AreEqual(expected, res, "Simple tree result incorrect");
        }


        /// <summary>
        /// ��������� ������ � ������������� ��������� ���� ���� ����������
        /// </summary>
        [TestMethod]
        public void TestBrokenTreeVN()
        {
            // Arrange
            ExpressionTreeNode root = new ExpressionTreeNode("*");
            ExpressionTreeNode left = root.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode right = root.AddRightNode(NodeTypeEnum.Operation, "*");
            left.AddLeftNode(NodeTypeEnum.Variable, "a");
            left.AddRightNode(NodeTypeEnum.Variable, "+");
            right.AddLeftNode(NodeTypeEnum.Variable, "c");
            right.AddRightNode(NodeTypeEnum.Variable, "d");

            // Act
            try
            {
                string res = root.ToString();

                // Assert
                Assert.Fail();
            }
            catch (Exception exc)
            {
                Assert.AreEqual(exc.Message, "Incorrect tree (Incorrect variable name)");
            }
        }


        /// <summary>
        /// ��������� ������ � ������������� �������, ���� ������ �� ������ ����
        /// </summary>
        [TestMethod]
        public void TestBrokenTreeLoneRoot()
        {
            // Arrange
            ExpressionTreeNode root = new ExpressionTreeNode("*");

            // Act
            try
            {
                string res = root.ToString();

                // Assert
                Assert.Fail();
            }
            catch (Exception exc)
            {
                Assert.AreEqual(exc.Message, "Incorrect tree (operation node must have two child leaves)");
            }
        }


        /// <summary>
        /// ��������� ������ � ������������� �������, ����� � �������� ��� �����
        /// </summary>
        [TestMethod]
        public void TestBrokenTreeWrongNodeType()
        {
            // Arrange
            ExpressionTreeNode root = new ExpressionTreeNode("*");
            ExpressionTreeNode left = root.AddLeftNode(NodeTypeEnum.Operation, "-");
            ExpressionTreeNode right = root.AddRightNode(NodeTypeEnum.Operation, "*");
            left.AddLeftNode(NodeTypeEnum.Variable, "a");
            left.AddRightNode(NodeTypeEnum.Operation, "+");
            right.AddLeftNode(NodeTypeEnum.Variable, "c");
            right.AddRightNode(NodeTypeEnum.Variable, "d");

            // Act
            try
            {
                string res = root.ToString();

                // Assert
                Assert.Fail();
            }
            catch (Exception exc)
            {
                Assert.AreEqual(exc.Message, "Incorrect tree (operation node must have two child leaves)");
            }
        }
    }
}
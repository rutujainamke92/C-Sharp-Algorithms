using RutujaLeetCode.Tree;
using Xunit;

namespace UnitTest.Rutuja.LeetCode.Tests
{
    public class TreeUnitTests
    {
        [Fact]
        public static void IsSymmetric ()
        {

            int [] arr = { 1,2,2,3,4,4,3};
            int n = arr.Length;
            var root = LearningTree.createTree (arr, n);

            //Calling IsSymmetric function
            LearningTree tree = new LearningTree ();                    
          
            var result = tree.IsSymmetric (root);
            Assert.True (result);
        }
    }
}

//2*i+1
// 2*i+2
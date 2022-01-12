using System;
namespace RutujaLeetCode
{
    public static class Recursion
    {
        public static int KthGrammar (int n, int k)
        {
            if (n == 1)
                return 0;

            // since we can present this recursion as tree with
            // when 0 is parent then child will be 0 and 1 
            // when 1 is parent then child will be 1 and 0
            int kInternal = (k % 2 == 0 ? k / 2 : k / 2 + 1);
            int resAtK = KthGrammar (n - 1, kInternal); // call previous parent

            //resAtK gives prev parent, using parent's property we return child 
            if (k % 2 == 0) //this means it is right child
                return (resAtK == 0) ? 1 : 0;
            else
                return (resAtK == 0) ? 0 : 1;
        }
    }
}

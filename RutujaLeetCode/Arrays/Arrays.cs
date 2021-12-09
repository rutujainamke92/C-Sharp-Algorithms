using System;
using System.Collections.Generic;
using System.Text;

namespace RutujaLeetCode.Arrays
{
    public static class Arrays
    {
        /// <summary>
        ///https://leetcode.com/problems/build-array-from-permutation/
        /// Given a zero-based permutation nums (0-indexed), build an array ans of the same length
        /// where ans[i] = nums[nums[i]] for each 0 <= i < nums.length and return it.
        ///A zero-based permutation nums is an array of distinct integers from 0 to nums.length - 1 (inclusive).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int [] BuildArrayFromPermutation (int [] nums)
        {
            int [] ans = new int [nums.Length];
            for (int i = 0; i < nums.Length; i++) {
                ans [i] = nums [nums [i]];
            }
            return ans;
        }


        /// <summary>
        ///https://leetcode.com/problems/running-sum-of-1d-array/submissions/
        /// Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
        ///Return the running sum of nums
        ///Input: nums = [1,2,3,4]
        ///Output: [1,3,6,10]
        ///Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int [] RunninSum (int [] nums)
        {
            int [] ans = new int [nums.Length];
            ans [0] = nums [0];
            for (int i = 1; i < nums.Length; i++) {
                ans [i] = ans [i - 1] + nums [i];

            }
            return ans;

            //Option 2
            //for (int i = 1; i < nums.Length; i++) {
            //    nums [i] = nums [i - 1] + nums [i];

            //}
            //return nums;
        }

        /// <summary>
        ///https://leetcode.com/problems/defanging-an-ip-address/
        ///Given a valid (IPv4) IP address, return a defanged version of that IP address.
        ///A defanged IP address replaces every period "." with "[.]".
        /// <param name="address"></param>
        /// <returns></returns>
        public static string DefangingIPAddress (string address)
        {
            StringBuilder sb = new StringBuilder ("", address.Length);

            foreach (char item in address) {
                if (item == '.') {
                    sb.Append ("[.]");
                } else {
                    sb.Append (item);
                }
            }
            return sb.ToString ();
        }

        /// <summary>
        ///https://leetcode.com/problems/palindrome-number/solution/
        // Given an integer x, return true if x is palindrome integer.
        //An integer is a palindrome when it reads the same backward as forward.For example, 121 is palindrome while 123 is not.
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome (int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;
            int rev = 0;
            int y = x;
            while (y != 0) {
                rev = rev * 10 + y % 10;
                y = y / 10;
            }
            if (x == rev)
                return true;

            else
                return false;
        }

        public static IList<bool> GreatestCandies (int [] nums, int extra)
        {
            LinkedListNode<int> abc;
            LinkedList<int> anc = new LinkedList<int> ();
            IList<bool> ans = new List<bool> ();
            Array.Sort<int> (nums);
            int max = nums [nums.Length - 1];

            for (int i = 0; i < nums.Length; i++) {
                if ((nums [i] + extra >= max))
                    ans.Add (true);
                else
                    ans.Add (false);
            }
            return ans;
        }

        public static int NumIdenticalPairs (int [] nums)
        {
            if (nums.Length == 0)
                return 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if (nums [i] == nums [j])
                        count++;
                }
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/decode-xored-array/
        /// </summary>
        /// <param name="encoded"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static int [] DecodeXORArray (int [] encoded, int first)
        {
            //int x=1; int y=2;
            //int z = x ^ y;
            //IMP encode[0] = Arr[0] XOR Arr[1];
            //Arr[1] = en[0] XOR Arr[0];
            int [] arr = new int [encoded.Length + 1];
            arr [0] = first;
            for (int i = 0; i < encoded.Length; i++) {
                arr [i + 1] = (encoded [i] ^ arr [i]);
            }
            return arr;
        }

        /// <summary>
        /// https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SubtractProductAndSum (int n)
        {
            //My Solution
            //string s = Convert.ToString (n);
            //int [] input = new int [s.Length];
            //int i = 0;
            //while (n != 0) {
            //    input [i] = n % 10;
            //    n = n / 10;
            //    i++;
            //}
            //int sum = 0; int mul = 1;
            //foreach (var item in input) {
            //    sum = sum + item;
            //    mul = mul * item;
            //}

            //return mul - sum;

            //Optimized solution online
            string s = Convert.ToString (n);
            int sum = 0; int mul = 1;
            while (n > 0) {
                sum = sum + n % 10;
                mul = mul * n % 10;
                n = n / 10;
            }

            return mul - sum;
        }

        /// <summary>
        /// https://leetcode.com/problems/third-maximum-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ThridMax (int [] nums)
        {
            long max = long.MinValue;
            long sec = long.MinValue;
            long third = long.MinValue;
            for (int i = 0; i < nums.Length; i++) {
                if (nums [i] == max || nums [i] == sec || nums [i] == third)
                    continue;

                if (nums [i] > max) {
                    third = sec;
                    sec = max;
                    max = nums [i];
                } else if (nums [i] > sec) {
                    third = sec;
                    sec = nums [i];
                } else if (nums [i] > third) {
                    third = nums [i];
                }
            }
            //third = sec;
            //sec = max;
            if (third > long.MinValue)
                return (int)third;
            else return (int)max;
        }

        /*Very IMP Microsoft, Amazon, LinkedIn*/
        /// <summary>
        /// https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <returns></returns>
        public static int MaxSubArray (int [] nums)
        {
            //We can also do it using two for loops-->O(n^2)
            //And find easy sub array and compare max out of it. 
            //Linear soln -- TC-> O(n) --Easy explanation
            //https://www.youtube.com/watch?v=5WZl3MMT0Eg&ab_channel=NeetCode
            //if CurrSum is negative scratch that and start array from next. 

            /*int currSum = nums[0];
            int maxSum = nums[0];

            foreach(int i in nums) {
                if (currSum < 0)
                    currSum = 0;
                currSum = currSum + i;
                maxSum = Math.Max (currSum, maxSum);
            }
            return maxSum;*/

            //Another way to do it --> Nick WHite Vid

            int currSum = nums [0];
            int maxSum = nums [0];
            for (int i = 1; i < nums.Length; i++) {
                currSum = Math.Max (currSum + nums [i], nums [i]);
                maxSum = Math.Max (currSum, maxSum);
            }
            return maxSum;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-pivot-index/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int PivotIndex (int [] nums)
        {
            int sumRight = 0, sumLeft = 0;
            for (int i = 0; i < nums.Length; i++) {
                sumRight = sumRight + nums [i];
            }
            if (sumRight - nums [0] == 0)
                return 0;
            sumRight = sumRight - nums [0];

            for (int i = 1; i < nums.Length; i++) {
                sumLeft = sumLeft + nums [i - 1];
                sumRight = sumRight - nums [i];
                if (sumLeft == sumRight)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/contains-duplicate/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate (int [] nums)
        {
            HashSet<int> hash = new HashSet<int> ();
            foreach (var item in nums) {
                hash.Add (item);
            }
            if (hash.Count < nums.Length)
                return true;
            else return false;
        }

        public static bool ValidMountainArray (int [] arr)
        {
            if (arr.Length < 3)
                return false;
            int n = 0, current = arr [0];
            bool flag1 = false, flag2 = false;
            for (int i = 1; i < arr.Length; i++) {
                if (current < arr [i]) {
                    current = arr [i];
                    n = i;
                    flag1 = true;
                } else break;
            }

            current = arr [n];
            for (int i = n + 1; i < arr.Length; i++) {
                if (current > arr [i]) {
                    current = arr [i];
                    flag2 = true;
                    n = i;
                } else break;
            }

            if (n == arr.Length - 1 && flag1 == true && flag2 == true)

                return true;
            else return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int [] TwoSum (int [] nums, int target)
        {
            //int a;
            //for (int i = 0; i < nums.Length; i++) {
            //    a = nums [i];
            //    for (int j = 0; j < nums.Length; j++) {
            //        if ((nums [j] == (target - a)) && i != j) {
            //            return new int [] { i, j };
            //        }
            //    }
            //}

            Dictionary<int, int> dict = new Dictionary<int, int> ();
            for (int i = 0; i < nums.Length; i++) {
                if (!dict.ContainsKey (nums [i]))
                    dict.Add (nums [i], i);
            }

            for (int i = 0; i < nums.Length; i++) {

                if (dict.ContainsKey (target - nums [i])) {
                    int a = 0;
                    dict.TryGetValue (target - nums [i], out a);
                    if (a != i)
                        return new int [] { i, a };
                }
            }
            return new int [] { 0, 0 };
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        /// I had to look for answer
        public static void Merge (int [] nums1, int m, int [] nums2, int n)
        {
            //nums1 = [1,2,3,0,0,0] length= m+n
            //nums2 = [2,5,6]
            int j = n - 1;
            int i = m - 1;
            int final = m + n - 1;
            while (i >= 0 && j >= 0) {
                if (nums2 [j] > nums1 [i]) {
                    nums1 [final] = nums2 [j];
                    j--;
                    final--;
                } else {
                    nums1 [final] = nums1 [i];
                    i--;
                    final--;
                }
            }
            while (j >= 0) {
                nums1 [final] = nums2 [j];
                final--; j--;
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int [] Intersect (int [] nums1, int [] nums2)
        {
            List<int> output = new List<int> ();
            for (int i = 0; i < nums1.Length; i++) {
                for (int j = 0; j < nums2.Length; j++) {
                    if (nums2 [j] == nums1 [i] && nums1 [i] > -1) {
                        output.Add (nums1 [i]);
                        nums2 [j] = -1;
                        nums1 [i] = -1;
                        j++;
                    }
                }
            }

            return (int [])output.ToArray ();
        }

        /// <summary>
        ///https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int MaxProfit (int [] prices)
        {
            ///Had to look for code.
            int maxProfit = 0;
            int min = prices [0];

            for (int i = 1; i < prices.Length; i++) {
                if (prices [i] < min) {
                    min = prices [i];

                }
                if (prices [i] - min > maxProfit) {
                    maxProfit = prices [i] - min;
                }


            }
            return maxProfit;

        }

        /// <summary>
        /// TWO POINTER PROBLEMS
        /// koko eating bananas
        /// </summary>
        /// <returns></returns>
        public static int MinEatingSpeed (int [] piles, int h)
        {

            int right = int.MinValue, left = 1; int ans = 0;
            for (int i = 0; i < piles.Length; i++) {
                if (piles [i] > right)
                    right = piles [i];
            }
            int mid = 0;
            int kValue = 0;
            while (right >= left) {
                mid = left + (right - left) / 2;
                kValue = 0;
                for (int i = 0; i < piles.Length; i++) {
                    kValue = kValue + (piles [i] / mid);
                    if (piles [i] % mid > 0)
                        kValue = kValue + 1;
                }
                if (kValue > h) {
                    left = mid + 1;
                } else if (kValue <= h) {
                    ans = mid;
                    right = mid - 1;
                }

            }
            return ans;
        }


        /// <summary>
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int [] TwoSumII (int [] numbers, int target)
        {
            int [] ans = new int [2];
            for (int i = 0; i < numbers.Length; i++) {
                var a = numbers [i];

                for (int j = 0; j < numbers.Length && j != i; j++) {
                    if (a + numbers [j] == target) {
                        return new int [] { i + 1, j + 1 };
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// https://leetcode.com/problems/4sum/solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> FourSum (int [] nums, int target)
        {
            IList<IList<int>> answer = new List<IList<int>> ();

            if (nums.Length == 0 || nums == null)
                return answer;
            int n = nums.Length;
            int left, right;
            //First need to sort array
            Array.Sort (nums);

            //loop i, j, left and right
            for (int i = 0; i < n; i++) {

                if (i > 0 && nums [i] == nums [i - 1])
                    continue;

                for (int j = i + 1; j < n; j++) {

                    if (j > i + 1 && nums [j] == nums [j - 1])
                        continue;

                    int twosum = target - (nums [i] + nums [j]);
                    left = j + 1; right = n - 1;

                    while (left < right) {
                        if (nums [left] + nums [right] == twosum) {
                            answer.Add (new List<int> () { nums [i], nums [j], nums [left], nums [right] });
                            left++; right--;
                        } else if (nums [left] + nums [right] < twosum)
                            left++;
                        else if (nums [left] + nums [right] > twosum)
                            right--;

                        //we want to skip the duplicate numbers
                        if (right < n - 1)
                            while (nums [right] == nums [right + 1] && right > left)
                                right--;

                        if (left > j + 1)
                            while (nums [left] == nums [left - 1] && right > left)
                                left++;
                    }
                }
            }
            return answer;

        }

        public static int [] SortedSquares (int [] nums)
        {

            int n = nums.Length - 1;

            int [] ans = new int [n + 1];


            for (int i = 0; i < n; i++) {
                nums [i] = nums [i] * nums [i];
            }
            for (int i = 0; i < nums.Length && n > -1; i++) {
                if (nums [i] > ans [n]) {
                    ans [n - 1] = ans [n];
                    ans [n] = nums [i];
                } else {
                    n--;
                    ans [n] = nums [i];

                }

            }
            return ans;


        }

        /// <summary>
        /// Checkout Code on LC 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAnagram (string s, string t)
        {

            if (s.Length != t.Length)
                return false;
            Dictionary<char, int> s1 = new Dictionary<char, int> ();
            Dictionary<char, int> t1 = new Dictionary<char, int> ();


            for (int i = 0; i < s.Length; i++) {
                if (s1.ContainsKey (s [i])) {
                    int val = 0;
                    s1.TryGetValue (s [i], out val);
                    s1.Add (s [i], val + 1);
                } else
                    s1.Add (s [i], 1);
            }
            for (int i = 0; i < s.Length; i++) {
                if (t1.ContainsKey (t [i])) {
                    int val = 0;
                    t1.TryGetValue (t [i], out val);
                    t1.Add (t [i], val + 1);
                } else
                    t1.Add (t [i], 1);
            }

            foreach (var item in s1) {
                int val; int val2;
                s1.TryGetValue (item.Key, out val);
                t1.TryGetValue (item.Key, out val2);
                if (!(t1.ContainsKey (item.Key) && val == val2))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IList<int> FindAnagrams (string s, string p)
        {
            Dictionary<char, int> pCount = new Dictionary<char, int> ();
            Dictionary<char, int> sCount = new Dictionary<char, int> ();

            IList<int> ans = new List<int> ();


            for (int i = 0; i < p.Length; i++) {
                if (!pCount.ContainsKey (p [i]))
                    pCount.Add (p [i], 1);

                else
                    //dict[key] ==> gives its value 
                    pCount [p [i]] = pCount [p [i]] + 1;

            }


            int r = pCount.Count;
            int l;
            for ( l = 0; l < s.Length && r < s.Length;) {

                sCount.TryGetValue (s [l], out int val);
                if (sCount.ContainsKey (s [l]) && val > 1)
                    sCount [s [l]] = sCount [s [l]] - 1;

                else
                    sCount.Remove (s [l]);

                if (!sCount.ContainsKey (s [r]))
                    sCount.Add (s [r], 1);
                else
                    sCount [s [r]] = sCount [s [r]] + 1;

                if (IsEqual (pCount, sCount)) {
                    ans.Add (l);
                }
                l++;
                r++;

            }
            if (IsEqual (pCount, sCount)) {
                ans.Add (l);
            }
            return ans;

        }
        private static bool IsEqual (Dictionary<char, int> freq1, Dictionary<char, int> freq2)
        {
            foreach (var item in freq1) {
                int val; int val2;
                freq1.TryGetValue (item.Key, out val);
                freq2.TryGetValue (item.Key, out val2);
                if (!(freq2.ContainsKey (item.Key) && val == val2))
                    return false;
            }
            return true;

        }

        /// <summary>
        /// https://leetcode.com/problems/kth-missing-positive-number/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int FindKthPositive (int [] arr, int m)
        {

            Dictionary<int, int> dic = new Dictionary<int, int> ();
            for (int r = 0; r < arr.Length; r++) {
                dic.Add (arr [r], 1);
            }

            int [] result = new int [m+1];
            int n = arr.Length;
            int i = 1; 
            int p = 0;
            while ( i < n)
                {
                if (!dic.ContainsKey (i)) {
                    result [p] = i;
                    p++;
                }
                 
                i++;
            }
            while(p <= m) {
                result [p++] =i ++;
            }
            return result [m-1];
        }
    }

}

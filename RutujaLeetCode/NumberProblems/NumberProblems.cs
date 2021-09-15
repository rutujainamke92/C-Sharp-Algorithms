using System;
namespace RutujaLeetCode.IntProblems
{
    public class NumberProblems
    {
        /// <summary>
        /// https://leetcode.com/problems/count-primes/
        /// //Count the number of prime numbers less than a non-negative number, n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountPrimesAccepted (int n)
        {
            //Please see code explanation on Leetcode
            Boolean [] isPrime = new Boolean [n];
            for (int i = 2; i < n; i++) {
                isPrime [i] = true;
            }
            // Loop's ending condition is i * i < n instead of i < sqrt(n)
            // to avoid repeatedly calling an expensive function sqrt().
            for (int i = 2; i * i < n; i++) {
                if (!isPrime [i]) continue;
                for (int j = i * i; j < n; j += i) {
                    isPrime [j] = false;
                }
            }
            int count = 0;
            for (int i = 2; i < n; i++) {
                if (isPrime [i]) count++;
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/count-primes/
        /// Count the number of prime numbers less than a non-negative number, n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountPrimes (int n)
        {
            int count = 0;
            int inside = 0;
            for (int i = 1; i < n; i++) {
                int breakVal = 0;
                for (int j = 2; j <= (i / 2); j++) {
                    inside++;
                    if (i % j == 0) {
                        breakVal++;
                        break;
                    }
                }
                if ((breakVal == 0 && inside > 0 && i > 1) || i == 2 || i == 3) {
                    count++;
                }
            }
            return count;
        }


        /// <summary>
        /// https://leetcode.com/problems/remove-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement (int [] nums, int val)
        {
            int n = nums.Length;
            int begin = 0;
            for (int i = 0; i < n; i++) {
                if (nums [i] != val) {
                    nums [begin] = nums [i];
                    begin++;
                }
            }
            return begin;
            //int k = 1;
            //for (int i = 0; i < nums.Length-k; i++) {
            //    if (nums [i] == val ) {
            //        if(nums[nums.Length - k]==val) {

            //        }
            //        int a = 0;
            //        a = nums [nums.Length -k];
            //        nums [nums.Length - k] = nums [i];
            //        nums [i] = a;
            //        k++;
            //    }
            //     else
            //        i++;
            //}

            //return (nums.Length - k-1);
        }

        public static bool CanBeIncreasing (int [] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length; i++) {
                if (nums [i - 1] >= nums [i]) {
                    count++;

                    if (i > 1 && nums [i - 2] >= nums [i]) {
                        nums [i] = nums [i - 1];
                    }
                }
            }
            return count < 2;
        }

        /// <summary>
        /// https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int [] SmallerNumbersThanCurrent (int [] nums)
        {
            //the Time complexity is O(n*n)

            //int [] ans = new int [nums.Length];

            //for (int i = 0; i < nums.Length; i++) {

            //    int count = 0;

            //    for (int j = 0; j < nums.Length; j++) {

            //        if (i != j && nums [j] < nums [i]) {
            //            count++;
            //        }
            //    }
            //    ans[i]=count; 
            //}

            //return ans;

            //better solution is below-- TC ==> O(n)
            //Leetcode solution
            int [] bucket = new int [101];
            for (int i = 0; i < nums.Length; i++)
                bucket [nums [i]]++;

            for (int i = 1; i < bucket.Length; i++)
                bucket [i] = bucket [i - 1] + bucket [i];

            for (int i = 0; i < nums.Length; i++)
                nums [i] = bucket [nums [i] - 1];

            return nums;
        }

        /// <summary>
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert (int [] nums, int target)
        {
            //runtime complexity should be O(log n)
            //Use Binary Search
            //use left right to change start end using binary search 
            int left = 0; int right = nums.Length;
            while (left < right) {
                int mid = left + ((right - left) / 2);
                if (target == nums [mid])
                    return mid;
                else {
                    if (target < nums [mid]) {
                        right = mid - 1;
                        continue;
                    } else if (target > nums [mid]) {
                        left = mid + 1;
                        continue;
                    }
                }
            }
            return left;
        }

        /// <summary>
        /// https://leetcode.com/problems/plus-one/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int [] PlusOne2 (int [] digits)
        {
            long num = 0;
            long count = 0;
            for (long i = 0; i < digits.Length; i++) {
                num = num * 10 + digits [i];
                if (digits [i] == 9)
                    count++;
            }
            num = num + 1;
            int [] output;
            if (count == (digits.Length))
                output = new int [digits.Length + 1];
            else
                output = new int [digits.Length];
            int j = output.Length - 1;
            while (num > 0) {
                output [j] = (int)(num % 10);
                num = num / 10;
                j--;
            }
            return output;
        }

        /// <summary>
        /// https://leetcode.com/problems/sqrtx/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int SquareRoot (int x)
        {
            if (x == 1)
                return 1;
            for (long i = 1; i <= x / 2; i++) {
                if (i * i <= x && x < ((i + 1) * (i + 1))) {
                    return (int)i;
                }
            }
            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int NumberOfSteps (int num)
        {
            int count = 0;
            while(num!=0) {
                if(num%2==0) {
                    num = num / 2;
                    count++;
                }
                else {
                    num = num - 1;
                    count++;
                }
            }
            return count;
        }
    }
}
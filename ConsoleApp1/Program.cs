using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var leader = new Leader();
            var nums = new int[] { 4, 3,4,4,4,2};
            leader.EquiLeader(nums);
            
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public int[] Rotate(int[] A, int K)
        {
            var lst = A.ToList();
            if (A.Length == 0)
            {
                return A;
            }
                
            for(var i = 0; i < K; i++)
            {
                lst.Insert(0, A[A.Length - i%A.Length - 1]);
            }

            return lst.Take(A.Length).ToArray();
        }

        public int FindLeft(int[] A)
        {
            var set = new HashSet<int>();
            foreach(var a in A)
            {
                if(set.Contains(a))
                {
                    set.Remove(a);
                }else
                {
                    set.Add(a);
                }
            }

            return set.First();
        }


        public int func2(int[] ranks)
        {
            var dict = new Dictionary<int, int>();
            foreach(var r in ranks)
            {
                if(dict.ContainsKey(r+1))
                {
                    dict[r + 1] += 1;
                }else
                {
                    dict.Add(r + 1, 1);
                }
            }

            var ret = 0;
            foreach(var r in ranks)
            {
                if(dict.ContainsKey(r))
                {
                    ret += dict[r];
                    dict[r] = 0;
                }
            }

            return ret;

        }

        public int func(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Array.Sort(A);
            var ret = 1;
            foreach(var a in A)
            {
                if(a == ret)
                {
                    ret++;
                    continue;
                }
            }

            return ret;
        }
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    return new int[] { i, dict[nums[i]] };
                } else
                {
                    if (!dict.ContainsKey(target - nums[i]))
                    {
                        dict.Add(target - nums[i], i);
                    }
                }
            }

            return null;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var borrow = 0;
            var start = new ListNode(0);
            while(l1.next != null && l2.next != null)
            {
                var sum = l1.val + l2.val + borrow;

            }

            return start;
        }

        //public int LengthOfLongestSubstring2(string s)
        //{
        //    var len = 0;
        //    //build dictionary
        //    var dict = new OrderedDictionary();

        //    var l = 0;
        //    for(var i = 0; i < s.Length; i++)
        //    {
        //        if(dict.(s[i]) == false)
        //        {
        //            l++;
        //            dict[s[i]] = true;
        //        }
        //        else
        //        {
        //            dict = new Dictionary<char, bool>();
        //            len = (l > len) ? l : len;
        //            l = 1;
        //            dict[s[i]] = true;
        //        }
        //    }

        //    return len > l ? len : l;
        //}
        public int LengthOfLongestSubstring(string s)
        {
            var len = 0;
            //build dictionary
            var dict = new Dictionary<char, bool>();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            foreach (var a in alphabet)
            {
                dict.Add(a, false);
            }
            
            var l = 0;
            for(var i = 0; i < s.Length; i++)
            {
                if(dict[s[i]] == false)
                {
                    l++;
                    dict[s[i]] = true;
                }else
                {
                    foreach (var a in alphabet)
                    {
                        dict[a] = false;
                    }

                    len = (l > len) ? l : len;

                    l = 1;
                    dict[s[i]] = true;
                }
            }

            return len;
        }
    };
}

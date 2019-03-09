using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public class Codility
    {
        
    }

    public sealed class PrimeAndCompositeNumbers
    {
        public int MinPerimeterRectangle(int A)
        {
            int s = (int)Math.Floor(Math.Sqrt(A));
            while(A % s != 0)
            {
                s--;
                if (s == 0) throw new Exception();
            }

            return 2 * (s + A / s);
        }

        public int Peaks(int[] A)
        {
            var ret = 0;
            var peaks = new List<int>();
            //get all peaks
            for(var i = 1; i < A.Length -1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1]) peaks.Add(i);
            }

            for(var size = 2; size < A.Length; size++)
            {
                if((A.Length-1) % size == 0)
                {
                    var ok = true;
                    // if peaks in all groups then return 
                    for(var g = 0; g < (A.Length-1)/size; g++)
                    {
                        if(A.Skip(g*size).Take(size).Intersect(peaks).Count() == 0)
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok) return (A.Length - 1) / size;
                }
            }

            return ret;
        }

        //public int Flags(int[] A)
        //{
        //    var ret = 0;

        //    for(var i = 0; i < A.Length; i++)
        //    {
        //        if (ret == 0 && i < A.Length - 1 && A[i + 1] < A[i])
        //        {
        //            ret++;
        //        }
        //        else if(ret > 0)
        //        {

        //        }
        //    }

        //    return ret;
        //}
    }

    public sealed class MaxSliceSum
    {
        public int MaxSlice1(int[] A)
        {

            //the time complex is O(n*n),too slow
            var ret = int.MinValue;
            for(var i = 0; i < A.Length; i++)
            {
                var sum = 0;
                for(var j = i; j < A.Length; j++)
                {
                    sum += A[j];
                    ret = Math.Max(ret, sum);
                }
            }

            return ret;
        }

        public int MaxSlice2(int[] A)
        {
            //it is tricky but important method
            var ret = A[0];
            var lastMax = A[0];
            for(var i = 1; i < A.Length; i++)
            {
                lastMax = Math.Max(A[i], lastMax + A[i]);
                ret = Math.Max(ret, lastMax);
            }

            return ret;
        }


    }

    public class Leader
    {
        public int Dominator(int[] A)
        {
            //three methods for this question
            // 1. O(n*n) : calcualte each elements counts, if it is bigger than n/2, return the number
            // 2. O(nlogn) : Sort it first, return the middle elements
            // 3. O(n) : very clever way. Use a stack. if stack is number, put element on it. If it is same with peek element, push it. If it not, pop the top one. 

            var stack = new Stack<int>();

            if (A.Length == 0) return -1;

            var ret = -1;
            for(var i = 0; i < A.Length; i ++)
            {
                if(stack.Count == 0)
                {
                    stack.Push(A[i]);
                    ret = i;
                }
                else if(stack.Peek() == A[i])
                {
                    stack.Push(A[i]);
                    ret = i;
                }
                else
                {
                    stack.Pop();
                }
            }
            if (stack.Count == 0) return -1;
            var dominator = stack.Peek();
            var num = 0;
            foreach(var a in A)
            {
                if (a == dominator) num++;
            }
            if (num > A.Length / 2) return ret;

            return -1;
        }
    }

    public class StackAndQueue
    {
        
        public int Fish2(int[] A, int[] B)
        {
            //this version pass with 100%
            var stack = new Stack<int>();

            var ret = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if(B[i] == 1)
                {
                    stack.Push(A[i]);
                }

                if(B[i] == 0 && stack.Count > 0)
                {
                    while(stack.Count > 0 && A[i] > stack.Peek())
                    {
                        stack.Pop();
                    }
                }

                if(stack.Count == 0 && B[i] == 0)
                {
                    ret++;
                }
            }

            return ret + stack.Count;

        }
        public int Fish(int[] A, int[] B)
        {
            //this version pass with 70%， not sure why
            var upStack = new Stack<int>();
            var downQueue = new Queue<int>();
            var ret = 0;
            for(var i = 0; i < A.Length; i++)
            {
                if(upStack.Count == 0 && B[i] == 0)
                {
                    ret++;
                    continue;
                }
                if(B[i] == 1)
                {
                    upStack.Push(A[i]);
                }
                else
                {
                    downQueue.Enqueue(A[i]);
                }

                while(upStack.Count != 0 && downQueue.Count != 0)
                {
                    if(upStack.Peek() > downQueue.Peek())
                    {
                        downQueue.Dequeue();
                    }else
                    {
                        upStack.Pop();
                    }
                }
            }

            return ret + downQueue.Count + upStack.Count;
        }
    }

    public class Sorting
    {
        public int NumberOfDiscIntersections(int[] A)
        {
            //not 100% pass, bad performance
            var ret = 0;
            if (A.Length < 2) return 0;

            for(var i = 0; i < A.Length -1; i++)
            {
                for(var j = i+1; j < A.Length; j++)
                {
                    if(j - i <= A[i] + A[j])
                    {
                        ret += 1;
                    }
                }
            }

            return ret;
        }
        //public int NumberOfDiscIntersections2(int[] A)
        //{


        //}
    }

    public class PrefixSums
    {
        public int MinAvgTwoSlice2(int[] A)
        {
            /*https://github.com/daotranminh/playground/blob/master/src/codibility/MinAvgTwoSlice/proof.pdf
            * only need to consider the length of slice is 2 or 3
            * so it is O(n)
            */
            var curMin = float.MaxValue;
            var ret = 0;
            for(var i = 0; i < A.Length -1; i++)
            {
                var min = float.MaxValue;
                float sum = A[i];
                for(var j = i+1; j < A.Length; j++)
                {
                    if (j - i > 2) break;
                    sum += A[j];
                    var m = sum / (j - i + 1);
                    if (m < min) min = m;
                }

                if(min < curMin)
                {
                    curMin = min;
                    ret = i;
                }

            }

            return ret;
        }

        public int MinAvgTwoSlice(int[] A)
        {
            /* it is O(n*n) */
            var curMin = float.MaxValue;
            var ret = 0;
            for(var i = 0; i < A.Length -1; i++)
            {
                var min = float.MaxValue;
                float sum = A[i];
                for(var j = i+1; j < A.Length; j++)
                {
                    sum += A[j];
                    var m = sum / (j - i + 1);
                    if (m < min) min = m;
                }

                if(min < curMin)
                {
                    curMin = min;
                    ret = i;
                }

            }

            return ret;
        }
    }

    public class CountingElement
    {
        public int MissingInteger2(int[] A)
        {
            //solution with bitmap
            var max = 1;
            var bitmap = new bool[A.Length];
            foreach(var a in A)
            {
                if(a > 0 && a <= A.Length) //**** a<= A.Length is important
                {
                    bitmap[a-1] = true;
                }
                if (a > max) max = a;
            }

            for(var i = 0; i < A.Length; i++) 
            {
                if(bitmap[i] == false)
                {
                    return i + 1;
                }
            }

            return max + 1;

        }

        public int MissingInteger1(int[] A)
        {
            //solution with Set
            var set = new HashSet<int>();
            foreach(var a in A)
            {
                if(a > 0)
                {
                    set.Add(a);
                }
            }

            var ret = 1;
            while(true)
            {
                if(set.Contains(ret))
                {
                    ret++;
                }
                else
                {
                    return ret;
                }
            }
        }
    }

    public class TimeComplexity
    {
        public int TapeEquilibrium(int[] A)
        {
            if (A.Length == 0) return 0;

            var leftSum = A[0];
            var rightSum = 0;
            for(var i = 1; i < A.Length; i++)
            {
                rightSum += A[i];
            }

            var ret = 1;
            var curMin = int.MaxValue;
            for(var P = 1; P < A.Length; P++)
            {
                if(Math.Abs(leftSum - rightSum) < curMin)
                {
                    ret = P;
                    curMin = Math.Abs(leftSum - rightSum);
                }

                leftSum += A[P];
                rightSum -= A[P];
            }

            return curMin;

        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Codility
    {
        private EuclideanAlgorithm _algo;
        public Codility(EuclideanAlgorithm algo)
        {
            _algo = algo;
        }

        public int check()
        {
            return _algo.Count;
        }
    }

    public sealed class DynamicProgramming
    {
        private int getValue(int[] max, int index)
        {
            if (index < 0) return -10000;
            if (index >= max.Length) return 0;
            if (max[index] >= -10000*max.Length) return max[index];

            return 0;
        }

        private int getMax(int[] array)
        {
            return array.Max();
        }

        //100% pass
        public int NumberSolitaire(int[] A)
        {
            var maxArray = Enumerable.Repeat(int.MinValue, A.Length).ToArray();
            maxArray[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                maxArray[i] = getMax(new int[] { getValue(maxArray, i - 1), getValue(maxArray, i - 2), getValue(maxArray, i - 3), getValue(maxArray, i - 4), getValue(maxArray, i - 5), getValue(maxArray, i - 6)}) + A[i];
            }

            return maxArray[A.Length-1];
        }
    }

    public sealed class Greedy
    {
        //only 25% correctness for this solution
        public int TieRopes(int K , int[] A)
        {
            Array.Sort(A);
            var ret = 0;
            var sum = 0;
            foreach(var a in A)
            {
                sum += a;
                if(sum >= K)
                {
                    sum = 0;
                    ret++;
                }
            }

            return ret;
        }
    }

    public sealed class CaterPillarMethod
    {
        //time complexity is O(n*n)
        public int DistinctSlice(int M, int[] A)
        {
            var ret = 0;
            for(int i = 0; i < A.Length; i++)
            {
                ret++; //only one item in slice
                var set = new HashSet<int>();
                set.Add(A[i]);

                for(int j = i+1; j < A.Length; j++)
                {
                    if(set.Contains(A[j]))
                    {
                        break;
                    }
                    set.Add(A[j]);
                    ret++;
                }
            }

            return ret;
        }

        //time complexity is O(n), this method only pass 10%, need to modified
        public int DistinctSlice2(int M, int[] A)
        {
            var ret = 0;
            for(int i = 0; i < A.Length; i++)
            {
                ret++; //only one item in slice
                var set = new HashSet<int>();
                set.Add(A[i]);

                for(int j = i+1; j < A.Length; j++)
                {
                    if(set.Contains(A[j]))
                    {
                        ret += set.Count() * (set.Count() + 1) / 2;
                        i = j - 1;
                        break;
                    }
                    set.Add(A[j]);
                }
            }

            return ret;
        }
    }

    public sealed class BinarySearchAlgo
    {
        //mid is max of sum of block
        private int getBlocks(int[] A, int mid)
        {
            var blocks = 1;
            var curSum = 0;
            foreach(var a in A)
            {
                if(curSum+a > mid)
                {
                    blocks += 1;
                    curSum = a;
                }
                else
                {
                    curSum += a;
                }
            }

            return blocks;
        }

        public int MinMaxDivision(int K, int M, int[] A)
        {
            int max = A.Sum();
            int min = max / K;
            while(min <= max)
            {
                var mid = (min + max) / 2;
                var blocks = getBlocks(A, mid);
                if(blocks > K)
                {
                    min = mid+1;
                }else
                {
                    max = mid-1;
                }
            }

            return min;
        }
    }

    public sealed class FibonacciNumbers
    {
        private List<int> Fib(int max)
        {
            var ret = new List<int>() { 1, 1 };
            var n = 2;
            while(n <= max)
            {
                ret.Add(n);
                n = ret.TakeLast(2).Sum();
            }

            return ret;
        }

        public int FibCount(int max)
        {
            return Fib(max).Count();
        }

        public int FibFrog(int[] A)
        {
            var fibs = this.Fib(100000);
            var leafs = new List<int>();
            leafs.Add(0);
            for(var i = 0; i < A.Length; i++)
            {
                if (A[i] == 1) leafs.Add(i+1);
            }
            leafs.Add(A.Length+1);

            var steps = new int[A.Length + 2];
            var canReach = new List<int>();
            canReach.Add(0);

            for (var s = 0; s < leafs.Count(); s++) 
            {
                var curPos = leafs[s];
                if (canReach.Contains(curPos) == false) continue;

                for(int i = s; i < leafs.Count(); i++)  
                {
                    if (fibs.Contains(leafs[i] - curPos))
                    {
                        if (steps[leafs[i]]== 0)
                        {
                            steps[leafs[i]] = steps[curPos] + 1;
                            canReach.Add(leafs[i]);
                        }

                        if(i == leafs.Count() - 1)
                        {
                            return steps[curPos] + 1;
                        }
                    }
                }
            }

            return -1;
        }
    }

    public sealed class EuclideanAlgorithm
    {
        public int Count { get; set; }
        //O(n) time complex
        public int NumberOfChocolate(int N, int M)
        {
            var set = new HashSet<int>();
            if (N == 0) return 0;

            var a = 0;
            set.Add(a);
            while(set.Contains((a+M)%N) == false)
            {
                set.Add((a + M) % N);
                a = a + M;
            }

            return set.Count();
        }

        public int NumberOfChocolate2(int N, int M)
        {
            var g = gcd(N, M);
//            throw new FormatException();
            return N / g;
        }

        private int gcd(int N, int M)
        {
            if (N % M == 0) return M;
            return gcd(M, N % M);
        }
    }

    public sealed class SieveOfEratosthenes
    {
        //https://app.codility.com/demo/results/demoQFK5R5-YGD/ this is a C++ solution using Sieve method

        // the O(n*n) is too slow   
        public int[] CountOfNonDivisor(int[] A)
        {
            
            var ret = new int[A.Length];
            for(var i = 0; i < A.Length; i++)
            {
                var c = 0;
                for(var j = 0; j < A.Length; j++)
                {
                    if (A[j] > A[i])
                    {
                        c++;
                    }
                    else if(A[i] % A[j] != 0) 
                    {
                        c++;
                    }
                }
                ret[i] = c;
            }

            return ret;
        }

        public int[] CountSemiprimes(int N, int[] P, int[] Q)
        {
            var semiPrimes = this.SemiPrimes(N);
            int[] ret = new int[P.Length];
            int[] semiCounts = new int[semiPrimes.Length];
            semiCounts[0] = 0;
            for(var i = 1; i < semiPrimes.Length; i++)
            {
                semiCounts[i] = semiCounts[i - 1];
                if(semiPrimes[i])
                {
                    semiCounts[i] += 1;
                }
            }


            for(var i = 0; i <P.Length; i++)
            {
                ret[i] = semiCounts[Q[i]] - semiCounts[P[i]];
            }

            return ret;
        }

        public bool[] Primes(int N)
        {
            var ret = new bool[N+1];
            for(int i = 2; i < N+1; i++)
            {
                ret[i] = true;
            }
            for(int i = 2; i*i <= N; i++)
            {
                if(ret[i])
                {
                    var ite = i * 2;
                    while(ite < N+1)
                    {
                        ret[ite] = false;
                        ite += i;
                    }
                }
            }

            return ret;
        }

        public int[] FindFourPrimes2(int N)  {
            var primes = Primes(N);
            var lstPrimes = new List<int>();
            for(var i = 0; i < N; i++) {
                if(primes[i]) {
                    lstPrimes.Add(i);
                }
            }

            for(var a = lstPrimes.Count()-1; a >= 0; a--) {
                for(var b = a-1; b >= 0; b--) {
                    for(var c = b-1; c >= 0; c--) {
                        for(var d = c-1; d >= 0; d--) {
                            if(IsSeqInt((long)lstPrimes[a]*lstPrimes[b] * lstPrimes[c] *lstPrimes[d])) {
                                return new int[] {lstPrimes[a],lstPrimes[b],lstPrimes[c],lstPrimes[d]};
                            }
                        }
                    }
                }
            }

            return null;
        }
        public int[] FindFourPrimes(int N) 
        {
            var primes = Primes(N);

            for(var a = N-1; a >= N; a--) 
            {
                for(var b = a; b >= N; b--) 
                {
                    for(var c = b; c >= N; c--) 
                    {
                        for (var d = c; d >= N; d--) 
                        {
                            if(primes[a] && primes[b] && primes[c] && primes[d]) 
                            {
                                if(IsSeqInt(a*b*c*d)) {
                                    return new int[] {a,b,c,d};
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public bool IsSeqInt(long n)
        {
            var str = n.ToString();
           if(str.Length != 12) return false;

            for(var i = 0; i < str.Length-1; i++) {
                if(str[i] != str[i+1] && Math.Abs(str[i]-str[i+1]) != 1) {
                    return false;
                }
            }

            return true;
        }

        public bool[] SemiPrimes(int N)
        {
            var ret = new bool[N+1];
            var primes = Primes(N / 2);

            for(int i = 2; i < primes.Length; i++)
            {
                for(int j = i; j<primes.Length; j++)
                {
                    if(i * j < N+1 && primes[i] && primes[j])
                    {
                        ret[i * j] = true;
                    }
                }
            }

            return ret;
        }

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

        /*
            It is an interview question I met before. 
            Given a list of temperature, find out the point where min of right part is larger than max of left part.
            There are several solutions to resolve this problem:
                1. Iterate from the left side of the list, say i is current point. get the max of i's left.
                    use it compare with the right of i, if no element is smaller than i. It is the position.
                2. Obviously, the 1st solution is too slow because it is O(n*n). It can be optimized by using O(n) space
                    to save the largest temperature of right of each element thus we don't need to iterate the inner loop.
         */
         public int FindChangePoint_Better(int[] T) {
             var maxLeft = Int32.MinValue;
             var minRight = Int32.MaxValue;
             var len = T.Length;
             var minsRight = new int[len];
             //build minsRight array from right to left
             for(var i = T.Length-1; i >= 0; i--) {
                 minsRight[i] = Math.Min(minsRight[i], minRight);
                 minRight = minsRight[i];
             }

             for(var i = 0; i < T.Length -1; i++) {
                 maxLeft = Math.Max(T[i], maxLeft);
                 if(maxLeft == minsRight[i]) {
                     return i;
                 }
             }

             return -1;
         }
         public int FindChangePoint(int[] T) 
         {
             var maxLeft = Int32.MinValue;
             var minRight = Int32.MaxValue;

             for(var i = 0; i < T.Length-1; i++) {
                 maxLeft = Math.Max(maxLeft, T[i]);
                 for(var j = i + 1; j < T.Length; j++) {
                     minRight = Math.Min(minRight, T[j]);
                     if(minRight > maxLeft) {
                         return i;
                     }
                 }
             }

             return -1; //no solution
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

        /*
            0   1   2   3   4
            ->      ->
                <-      <-  <-
            So, (0,1)   (0,3)   (0,4)   (2,3)   (2,4) will meet with each other
         */
        public int CountPassingCars(int[] A) {
            var nums = 0;
            var eastCars = 0;
            foreach(var a in A) {
                eastCars += a;
            }
            foreach(var a in A) {
                if(a == 0) {
                    nums += eastCars;
                } else {
                    eastCars -= 1;
                }
            }
            return nums > 1000000000 ? -1 : nums;
        }
    }

    public class CountingElement
    {
        public int Check_Perm(int[] A)
        {
            var bitmap = new bool[A.Length];
            foreach(var a in A)
            {
                if(a > 0 && a <= A.Length)
                {
                    bitmap[a - 1] = true;
                }
            }

            foreach(var b in bitmap)
            {
                if (!b) return 0;
            }

            return 1;
        }

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

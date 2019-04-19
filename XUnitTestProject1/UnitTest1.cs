using ConsoleApp1;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void Test1()
        {
            var solution = new Solution();
            var nums = new int[] { 1, 0, 2, 3 };

            Assert.Equal(new int[] { 3,2 }, solution.TwoSum(nums, 5));
        }

        [Fact]
        public void Test2()
        {
            var solution = new Solution();
            Assert.Equal(3, solution.LengthOfLongestSubstring("pwwkew"));
        }
        [Fact]
        public void TestFindLeft()
        {
            var solution = new Solution();
            var nums = new int[] { 3, 9, 3, 9, 7 };
            Assert.Equal(7, solution.FindLeft(nums));
        }
    }

    public class TimeComplexityTest
    {
        [Fact]
        public void TapeEquilibriumTest()
        {
            var timeComplexity = new TimeComplexity();
            var nums = new int[] { 3,1,2,4,3 };

            Assert.Equal(1, timeComplexity.TapeEquilibrium(nums));
        }
    }


    public sealed class CountingElementTest
    {
        [Fact]
        public void Is_Perm()
        {
            var counting = new CountingElement();
            var nums = new int[] { 1,2,4,3 };
            Assert.Equal(1, counting.Check_Perm(nums));
        }

        [Fact]
        public void Not_Perm_When_duplicate_exist()
        {
            var counting = new CountingElement();
            var nums = new int[] { 3,1,2,4,3 };
            Assert.Equal(0, counting.Check_Perm(nums));
        }

        [Fact]
        public void MissingIntegerTest1()
        {
            var counting = new CountingElement();
            var nums = new int[] { 3,1,2,4,3 };

            Assert.Equal(5, counting.MissingInteger1(nums));
            Assert.Equal(5, counting.MissingInteger2(nums));
            
        }
    }

    public sealed class PrefixSumsTest
    {
        [Fact]
        public void MinAvgTwoSliceTest1()
        {
            var prefixSums = new PrefixSums();
            var nums = new int[] { 4, 2, 2, 2, 5, 1, 5 };

            Assert.Equal(1, prefixSums.MinAvgTwoSlice(nums));
        }
    }
    public sealed class StackAndQueueTest
    {
        [Fact]
        public void FishTest()
        {
            var stackAndQueue = new StackAndQueue();
            var nums = new int[] { 4, 3, 2, 1, 5 };
            var nums2 = new int[] {0, 1, 0, 0, 0 };

            Assert.Equal(2, stackAndQueue.Fish(nums, nums2));
        }
    }

    public sealed class LeaderTest
    {
        [Fact]
        public void DominatorTest()
        {
            var leader = new Leader();
            var nums = new int[] { 4, 3, 3,3,3,3,3,2, 1, 5 };
            var nums2 = new int[] { 1,2,3,3 };
            Assert.Equal(6, leader.Dominator(nums));
            Assert.Equal(-1, leader.Dominator(nums2));

        }
    }

    public sealed class MaxSliceSumTest
    {
        [Fact]
        public void MaxSliceTest()
        {
            var maxSlice = new MaxSliceSum();
            var nums = new int[] { 2,3,-3,2};
            var nums2 = new int[] { -2,-3,-1};
            Assert.Equal(5, maxSlice.MaxSlice1(nums));
            Assert.Equal(5, maxSlice.MaxSlice2(nums));
            Assert.Equal(-1, maxSlice.MaxSlice2(nums2));
        }
    }
    public sealed class PrimeAndCompositeTest
    {
        [Fact]
        public void MinPerimeterTest()
        {
            Assert.Equal(22, new PrimeAndCompositeNumbers().MinPerimeterRectangle(30));
        }
    }

    public sealed class SieveOfEratosthenesTest
    {
        [Fact]
        public void IsSeqIntTest()
        {
            var sieve = new SieveOfEratosthenes();
            Assert.Equal(sieve.IsSeqInt(1000), true);
            Assert.Equal(sieve.IsSeqInt(889), false);
        }

        [Fact]
        public void FourPrimesTest()
        {
            var sieve = new SieveOfEratosthenes();
            //Assert.Equal(sieve.FindFourPrimes(1000), new int[4]{1,3,4,5});
            Assert.Equal(sieve.FindFourPrimes2(1000), new int[4]{1,3,4,5});
        }

        [Fact]
        public void PrimesTest()
        {
            var sieve = new SieveOfEratosthenes();
            var expectPrimes = new bool[] { false,false, true, true, false, true, false, true, false, false, false };
            Assert.Equal(expectPrimes, sieve.Primes(10));
            var expectSemiPrimes = new bool[] { false,false, false, false, true, false, true, false, false, true, true, false,false };
            Assert.Equal(expectSemiPrimes, sieve.SemiPrimes(12));
        }

        [Fact]
        public void NonDivisorTest()
        {
            var sieve = new SieveOfEratosthenes();
            var expectResult = new int[] { 2, 4, 3, 2, 0 };
            Assert.Equal(expectResult, sieve.CountOfNonDivisor(new int[] { 3, 1, 2, 3, 6 }));
        }
    }

    public sealed class EuclideanAlgorithmTest
    {
        [Fact]
        public void NumberOfChocalateTest()
        {
            var algo = new EuclideanAlgorithm();
            Assert.Equal(5, algo.NumberOfChocolate2(10, 4));
         //   Assert.Throws<FormatException>(() => algo.NumberOfChocolate2(10, 4));

            Assert.Equal(5, algo.NumberOfChocolate(10, 4));

            var code = new Codility(algo);
            algo.Count = 2;

            Assert.Equal(2, code.check());
        }
    }

    public sealed class FibonacciNumbersTest
    {
        [Fact]
        public void FibFrogTest()
        {
            var fibFrog = new FibonacciNumbers();
            Assert.True(fibFrog.FibCount(100000) > 23);

            var A = new int[] { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 };
            Assert.Equal(3, fibFrog.FibFrog(A));
        }
    }

    public sealed class BinarySearchAlgoTest
    {
        [Fact]
        public void MinMaxDivisionTest()
        {
            var binarySearch = new BinarySearchAlgo();
            Assert.Equal(6, binarySearch.MinMaxDivision(3, 5, new int[] { 2, 1, 5, 1, 2, 2, 2 }));
        }
    }

    public sealed class CaterPillarMethodTest
    {
        [Fact]
        public void DistinctSliceCountTest()
        {
            var method = new CaterPillarMethod();
            Assert.Equal(9, method.DistinctSlice(5,new int[] { 3, 4, 5, 5, 2 }));
            Assert.Equal(9, method.DistinctSlice2(5,new int[] { 3, 4, 5, 5, 2 }));
        }
    }

    public sealed class GreedyTest
    {
        [Fact]
        public void TieRopesTest()
        {
            var greedy = new Greedy();
            Assert.Equal(3, greedy.TieRopes(4, new int[] { 1, 1, 2, 3, 4, 1, 3 }));
        }
    }

    public sealed class DynamicProgrammingTest
    {
        [Fact]
        public void NumberSolitaireTest()
        {
            var dp = new DynamicProgramming();

            Assert.Equal(8, dp.NumberSolitaire(new int[] { 1,-2,0,9,-1,-2}));
            Assert.Equal(4, dp.NumberSolitaire(new int[] { -2,5,1}));
        }
    }

    public sealed class TestAsync
    {
        private readonly ITestOutputHelper _output;

        public TestAsync(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task AsyncTEstAsync()
        {
            _output.WriteLine(DateTime.Now.ToString("yyyy��-��MM��-��dd��T��HH��:��mm��:��ss.ff"));
            var t = Task.Delay(1000);
            //Thread.Sleep(1000);
            _output.WriteLine(DateTime.Now.ToString("yyyy��-��MM��-��dd��T��HH��:��mm��:��ss.ff"));
            await t;
        }
    }

}

using ConsoleApp1;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
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
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ConsoleApp5;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(launchCount: 1, warmupCount: 3)]
public class AlgorithmDemo
{
    int[] array = { -1, -2, 0, -1, 2, 1, 4, 4 };

    int[] arrayLarge =
    {
        -1, -2, 0, -1, 2, 1, 4, 4, 3, 5, 67, 5, 5, -85, 4, 4, 3, -8, 5, -5, 5, 5, 5, 5, 5, 7, 6, -23, 4, 2, 2, 5, 4, 7,
        -8, 8, 9, 8, 73, 23, 21, 1, 2, 2, 45, 7, 8, 9, 9, 0, 0, 0, 9, 8, 0, 6, -5, 6, 5, 4, 33, 2, 2, 34, 5, 6,
        -8, 8, 9, 8, 73, 23, 21, 1, 2, 2, 45, 7, 8, 9, 9, 0, 0, 0, 9, 8, 0, 6, -5, 6, 5, 4, 33, 2, 2, 34, 5, 6
    };

    int target = 3;

    [Benchmark]
    public void HarishApproach_B_simpleData()
    {
        HarishApproach_B(target, array);
    }

    [Benchmark]
    public void HarishApproach_B_largeData()
    {
        HarishApproach_B(target, arrayLarge);
    }

    [Benchmark]
    public void HarishApproach_C_simpleData()
    {
        HarishApproach_C(target, array);
    }

    [Benchmark]
    public void HarishApproach_C_largeData()
    {
        HarishApproach_C(target, arrayLarge);
    }

    [Benchmark]
    public void HarishApproach_B_SightVariation_SimpleData()
    {
        HarishApproach_B_SightVariation(target, array);
    }

    [Benchmark]
    public void HarishApproach_B_SightVariation_LargeData()
    {
        HarishApproach_B_SightVariation(target, arrayLarge);
    }

    public static List<(int, int)> HarishApproach_B(int target, int[] nums)
    {
        // Two Pointers O(nlogn)
        var result = new List<(int, int)>();
        Array.Sort(nums); //-2,-1,-1,0,1,2,4,4    //O(nlogn)
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[left] + nums[right];
            if (sum == target)
            {
                result.Add((nums[left], nums[right]));
                //skip duplicates from left side
                while (left < right && nums[left] == nums[left - 1]) left++;
                //skip duplicates from right side
                while (left < right && nums[right] == nums[right - 1]) right--;
                left++;
                right--;
            }
            else if (sum > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return result;
    }

    public static List<(int, int)> HarishApproach_C(int target, int[] nums)
    {
        // Optimization - O(n)
        var result = new List<(int, int)>();
        var productLookup = new HashSet<int>(); // 
        var set = new HashSet<int>(); //-1, -2, 0, 2, 1

        foreach (var num in nums)
        {
            // num =2
            var diff = target - num; //3-2                
            var product = diff * num;
            var seenPair = productLookup.Contains(product);
            if (set.Contains(diff) && !seenPair)
            {
                result.Add((diff, num));
                productLookup.Add(product);
            }

            set.Add(num);
        }

        return result;
    }

    // my personal variation of the original code
    public static List<Pair> HarishApproach_B_SightVariation(int target, int[] array)
    {
        var list = new List<Pair>();
        Array.Sort(array);

        var left = 0;
        var right = array.Length - 1;
        while (left <= right)
        {
            var valLeft = array[left];
            var valRight = array[right];
            if (valLeft + valRight == target)
            {
                // because it is sorted I just have to check if the next one is different
                if (list.Count == 0 || list[list.Count - 1] != new Pair(valLeft, valRight))
                    list.Add(new Pair(valLeft, valRight));
                left++;
                right--;
            }
            else if (valLeft + valRight < target)
                left++;
            else
                right--;
        }

        return list;
    }
}

public record Pair(int a, int b);
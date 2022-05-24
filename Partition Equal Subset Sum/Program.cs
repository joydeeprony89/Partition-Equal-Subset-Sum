using System;
using System.Collections.Generic;
using System.Linq;

namespace Partition_Equal_Subset_Sum
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 5, 3, 2, 2, 2, 2, 2, 2, 2 }; // 1, 2, 3, 4, 5, 6, 7
      Solution s = new Solution();
      var result = s.CanPartition(nums);
      Console.WriteLine(result);
    }
  }

  public class Solution
  {
    public bool CanPartition(int[] nums)
    {
      int sum = nums.Sum();
      // if sum is Odd return false, as odd no can not be divided into two half
      if (sum % 2 != 0 || nums.Length == 1) return false;

      // each half should be equal to target
      int target = sum / 2;
      // set we have used to add the sum of all combination of sub array sum, at any point we found the set contains the half of the sum we can return true
      HashSet<int> visited = new HashSet<int>();
      visited.Add(0);
      visited.Add(nums[nums.Length - 1]);
      for (int i = nums.Length - 2; i >= 0; i--)
      {
        if (visited.Contains(target)) return true;
        // we need temp set as while iterating same set we can not modify the visited set
        HashSet<int> tempvisited = new HashSet<int>();
        foreach (var kvp in visited)
        {
          int n = kvp + nums[i];
          tempvisited.Add(n);
          tempvisited.Add(kvp);
        }
        visited = tempvisited;
      }

      return false;
    }
  }
}

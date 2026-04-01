namespace DSA_Solutions.Arrays;

using System.Collections.Generic;

public static class TwoSum
{
    public static int[] Solve(int[] nums, int target)
    {
        // Dictionary to store: [Value] -> [Index]
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            // If we've seen the complement before, we found our pair
            if (map.TryGetValue(complement, out int complementIndex))
            {
                return [complementIndex, i];
            }

            // Otherwise, add current number to the map
            // Use TryAdd to prevent errors if duplicate numbers exist
            map.TryAdd(nums[i], i);
        }

        // Return empty if no solution is found
        return [];
    }
}

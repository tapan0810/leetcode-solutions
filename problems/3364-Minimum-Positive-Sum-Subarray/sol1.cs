// ==========================================================
// 3364. Minimum Positive Sum Subarray 
// Difficulty : Easy
// Language   : C#
// Solution   : #1
// Runtime    : 3 ms (Beats 90%)
// Memory     : 45.1 MB (Beats 68%)
// Link       : https://leetcode.com/problems/minimum-positive-sum-subarray/
// ==========================================================


public class Solution {
    public int MinimumSumSubarray(IList<int> nums, int l, int r) {

        int n = nums.Count;

        int[] prefix = new int[n + 1];

        for (int i = 0; i < n; i++) {
            prefix[i + 1] = prefix[i] + nums[i];
        }

        int ans = int.MaxValue;

        for (int i = 0; i < n; i++) {

            for (int len = l; len <= r && i + len <= n; len++) {

                int sum = prefix[i + len] - prefix[i];

                if (sum > 0) {
                    ans = Math.Min(ans, sum);
                }
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}

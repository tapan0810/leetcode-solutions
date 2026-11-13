// ==========================================================
// 3420. Count Non-Decreasing Subarrays After K Operations
// Difficulty : Hard
// Language   : C#
// Solution   : #1
// Runtime    : 14 ms (Beats 100%)
// Memory     : 65.5 MB (Beats 100%)
// Link       : https://leetcode.com/problems/count-non-decreasing-subarrays-after-k-operations/
// ==========================================================


public class Solution
{
    public long CountNonDecreasingSubarrays(int[] nums, int k)
    {
        int n = nums.Length;

        int[] deque = new int[n];
        int head = 0, tail = 0;

        int right = n - 1;

        long cost = 0;
        long answer = 0;

        for (int left = n - 1; left >= 0; left--)
        {
            // Merge smaller maximum blocks.
            while (tail > head &&
                   nums[deque[tail - 1]] < nums[left])
            {
                int index = deque[--tail];

                int next = tail > head
                    ? deque[tail - 1]
                    : right + 1;

                cost += (long)(next - index) *
                        (nums[left] - nums[index]);
            }

            deque[tail++] = left;

            // Reduce window until cost <= k.
            while (cost > k)
            {
                cost -= nums[deque[head]] - nums[right];

                if (deque[head] == right)
                {
                    head++;
                }

                right--;
            }

            // All subarrays [left ... right] are valid.
            answer += right - left + 1;
        }

        return answer;
    }
}

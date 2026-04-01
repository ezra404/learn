using DSA_Solutions.Arrays;

namespace DSA_Tests.Arrays;

public class TwoSumTests
{
    [Fact]
    public void Case_Basic()
    {
        Assert.Equal([0, 1], TwoSum.Solve([2, 7, 11, 15], 9));
    }

    [Fact]
    public void Case_Duplicates()
    {
        Assert.Equal([0, 1], TwoSum.Solve([3, 3], 6));
    }

    [Fact]
    public void Case_NoSolution()
    {
        Assert.Empty(TwoSum.Solve([1, 2, 3], 10));
    }
}

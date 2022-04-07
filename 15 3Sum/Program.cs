var result = new Solution().ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
foreach (var i in result)
{
    foreach (var j in i)
    {
        Console.Write(j); ;
    }
    Console.WriteLine();
}

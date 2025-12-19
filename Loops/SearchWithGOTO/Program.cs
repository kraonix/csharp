class SearchWithGOTO
{
    static void Main()
    {
        int[][] data = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };

        int target = 6;

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                for (int k = 0; k < data[i][j]; k++)
                {
                    if (data[i][j] == target)
                    {
                        Console.WriteLine($"Found {target} at [{i}][{j}]");
                        goto Found;
                    }
                }
            }
        }

        Console.WriteLine($"{target} not found");
        return;

        Found:
        Console.WriteLine("Search complete");
    }
}
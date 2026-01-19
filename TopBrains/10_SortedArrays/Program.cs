class Program
{
    /// <summary>
    /// Merges two sorted arrays into a single sorted array.
    /// </summary>
    public static T[] MergeSortedArrays<T>(T[] a, T[] b) where T : IComparable<T>
    {
        // Handle edge cases where one or both arrays are null or empty
        if (a == null || a.Length == 0) return b ?? Array.Empty<T>();
        if (b == null || b.Length == 0) return a;

        // Create a new array to hold the merged result
        T[] merged = new T[a.Length + b.Length];

        int i = 0, j = 0, k = 0;

        // Merge the two arrays
        while (i < a.Length && j < b.Length)
        {
            if (a[i].CompareTo(b[j]) <= 0)
                merged[k++] = a[i++];
            else
                merged[k++] = b[j++];
        }

        // Copy any remaining elements from array a
        while (i < a.Length)
            merged[k++] = a[i++];

        // Copy any remaining elements from array b
        while (j < b.Length)
            merged[k++] = b[j++];

        return merged;
    }

    /// <summary>
    /// Example usage of MergeSortedArrays method.
    /// </summary>
    public static void Main(string[] args)
    {
        int[] array1 = { 1, 3, 5, 7 };
        int[] array2 = { 2, 4, 6, 8 };

        int[] mergedArray = MergeSortedArrays(array1, array2);

        Console.WriteLine(string.Join(", ", mergedArray));
    }

}
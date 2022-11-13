namespace CountingSorting;

public static class Sort
{
    public static int[] CountingSort(int[] arr)
    {
        var size = arr.Length;
        var maxElement = arr.Max();
        
        var occurrences = new int[maxElement + 1];
        for (int i = 0; i < size; i++)
        {
            occurrences[arr[i]]++;
        }

        for (int i = 0, j = 0; i <= maxElement; i++)
        {
            while (occurrences[i] > 0)
            {
                arr[j] = i;
                j++;
                occurrences[i]--;
            }
        }
        return arr;
    }
}
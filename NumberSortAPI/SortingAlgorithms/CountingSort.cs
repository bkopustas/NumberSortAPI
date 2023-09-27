using NumberSortAPI.Interfaces;

namespace NumberSortAPI.SortingAlgorithms
{
    public class CountingSort : ISortAlgorithm
    {
        public void Sort(List<int> numbers)
        {
            if (numbers == null || numbers.Count <= 1)
            {
                return;
            }
            int max = numbers.Max();
            int min = numbers.Min();

            int[] countArray = new int[max - min + 1];

            for (int i = 0; i < numbers.Count; i++)
            {
                countArray[numbers[i] - min]++;
            }

            int index = 0;
            for (int i = 0; i < countArray.Length; i++)
            {
                for (int j = 0; j < countArray[i]; j++)
                {
                    numbers[index] = i + min;
                    index++;
                }
            }
        }
    }
}

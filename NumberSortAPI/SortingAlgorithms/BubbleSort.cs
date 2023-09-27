using NumberSortAPI.Interfaces;

namespace NumberSortAPI.SortingAlgorithms
{
    public class BubbleSort : ISortAlgorithm
    {
        public void Sort(List<int> numbers)
        {
            int n = numbers.Count;
            bool swapped;
            int temp;

            do
            {
                swapped = false;

                for (int i = 0; i < n - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;

                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
        }
    }
}

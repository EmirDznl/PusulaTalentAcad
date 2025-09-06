using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Pusula
{
    public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
            return JsonSerializer.Serialize(numbers);

        List<int> best = new List<int>();
        List<int> current = new List<int> { numbers[0] };

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                current.Add(numbers[i]);
            }
            else
            {
                if (current.Sum() > best.Sum())
                    best = new List<int>(current);

                current = new List<int> { numbers[i] };
            }
        }

        if (current.Sum() > best.Sum())
            best = new List<int>(current);

        return JsonSerializer.Serialize(best);
    }
}

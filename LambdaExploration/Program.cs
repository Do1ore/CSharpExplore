// See https://aka.ms/new-console-template for more information

int[] array = new[] { 1, 2, 4, 645, 3 };

var result = await ArrayManipulation(i => Task.FromResult(i + 1), array);

foreach (var number in result)
{
    Console.WriteLine(number);
}

var res = Calculate(arr => arr.Average(), array);
Console.WriteLine("Result: " + res);


async Task<int[]> ArrayManipulation(Func<int, Task<int>> lambda, int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        nums[i] += await lambda(nums[i]);
    }

    return nums;
}

//2


double Calculate(Func<int[], double> selector, int[] array)
{
    var magicNumber = selector(array);
    magicNumber++;
    return magicNumber;
}
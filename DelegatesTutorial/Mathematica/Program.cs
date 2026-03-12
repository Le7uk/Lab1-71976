using System;
using System.Collections.Generic;

List<int> TransformNumbers(List<int> numbers, Func<int, int> transformer)
{
    List<int> result = new List<int>();
    foreach (int number in numbers)
    {
        result.Add(transformer(number));
    }
    return result;
}

List<int> FilterNumbers(List<int> numbers, Func<int, bool> predicate)
{
    List<int> result = new List<int>();
    foreach (int number in numbers)
    {
        if (predicate(number))
        {
            result.Add(number);
        }
    }
    return result;
}

int AggregateNumbers(List<int> numbers, int initialValue, Func<int, int, int> aggregator)
{
    int result = initialValue;
    foreach (int number in numbers)
    {
        result = aggregator(result, number);
    }
    return result;
}

void Repeat(int times, Action action)
{
    for (int i = 0; i < times; i++)
    {
        action();
    }
}

Func<int, int> CreateMultiplier(int factor)
{
    return x => x * factor;
}

List<int> testNumbers = new List<int> { 1, 2, 3, 4, 5, 12, 15 };

Console.WriteLine("Task 1 - TransformNumbers");
var doubled = TransformNumbers(testNumbers, x => x * 2);
var squared = TransformNumbers(testNumbers, x => x * x);
Console.WriteLine($"Doubled: {string.Join(", ", doubled)}");
Console.WriteLine($"Squared: {string.Join(", ", squared)}");
Console.WriteLine();

Console.WriteLine("Task 2 - FilterNumbers");
var evens = FilterNumbers(testNumbers, x => x % 2 == 0);
var greaterThan10 = FilterNumbers(testNumbers, x => x > 10);
var divisibleBy3 = FilterNumbers(testNumbers, x => x % 3 == 0);
Console.WriteLine($"Evens: {string.Join(", ", evens)}");
Console.WriteLine($"Greater than 10: {string.Join(", ", greaterThan10)}");
Console.WriteLine($"Divisible by 3: {string.Join(", ", divisibleBy3)}");
Console.WriteLine();

Console.WriteLine("Task 3 - AggregateNumbers");
var sum = AggregateNumbers(testNumbers, 0, (acc, x) => acc + x);
var product = AggregateNumbers(new List<int> { 1, 2, 3, 4, 5 }, 1, (acc, x) => acc * x);
var max = AggregateNumbers(testNumbers, int.MinValue, (acc, x) => x > acc ? x : acc);
Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Product (1-5): {product}");
Console.WriteLine($"Maximum: {max}");
Console.WriteLine();

Console.WriteLine("Task 4 - Repeat");
Repeat(5, () => Console.WriteLine("HERE COMES THE ACTION TO BE REPEATED"));
Console.WriteLine();

Console.WriteLine("Task 5 - Function factory");
var multiplyBy2 = CreateMultiplier(2);
var multiplyBy5 = CreateMultiplier(5);
Console.WriteLine($"multiplyBy2(10): {multiplyBy2(10)}");
Console.WriteLine($"multiplyBy5(10): {multiplyBy5(10)}");
Console.WriteLine();

public class Integrator
{
    public double Integrate()
    {
        var start = 0.0;
        var end = 1.0;
        var step = 0.1;
        var sum = 0.0;

        for (var x = start; x < end; x += step)
        {
            var y = x * x;
            sum += y * step;
        }

        return sum;
    }
}

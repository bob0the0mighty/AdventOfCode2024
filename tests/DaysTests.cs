using System.Runtime.CompilerServices;
using AdventOfCode2024;

namespace tests;

public static class Parts
{
    public static string Part1 { get { return "Part 1";} }
    public static string Part2 { get { return "Part 2";} }
}

[Parallelizable]
public class DaysTests
{

    private string rootTestDir = @"C:\Users\bob0t\source\repos\AdventOfCode\2024\tests";

    [SetUp]
    public void Setup()
    {
    }

    private void RunTestForDayPart(string day, string part, bool skipActual = false, string testName = "test", string inputName = "input")
    {
        var t = Type.GetType($"AdventOfCode2024.{day}, AdventOfCode2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        var testInput = rootTestDir + @$"\testData\{day}\{testName}";
        var dayClass = (DayTemplate)Activator.CreateInstance(t, testInput);
        int? result = CallDayPart(day, part, dayClass);

        if (!skipActual)
        {
            var dayInput = rootTestDir + @$"\testData\{day}\{inputName}";
            dayClass?.SetLines(dayInput);
            CallDayPart(day, part, dayClass);
        }
    }

    private static int? CallDayPart(string day, string part, DayTemplate? dayClass)
    {
        int? result = 0;
        if (part == Parts.Part1)
        {
            result = dayClass?.Part1();
        }
        else
        {
            result = dayClass?.Part2();
        }
        Console.WriteLine($"{day} {part}, result: {result}");
        Assert.NotNull(result);
        return result;
    }

    [Test]
    public void Day1Part1()
    {
        RunTestForDayPart("Day1", Parts.Part1);
    }

    [Test]
    public void Day1Part2()
    {
        RunTestForDayPart("Day1", Parts.Part2);
    }

    [Test]
    public void Day2Part1()
    {
        RunTestForDayPart("Day2", Parts.Part1);
    }

    [Test]
    public void Day2Part2()
    {
        RunTestForDayPart("Day2", Parts.Part2);
    }

    [Test]
    public void Day3Part1()
    {
        RunTestForDayPart("Day3", Parts.Part1);
    }

    [Test]
    public void Day3Part2()
    {
        RunTestForDayPart("Day3", Parts.Part2, testName: "test2");
    }

    [Test]
    public void Day4Part1()
    {
        RunTestForDayPart("Day4", Parts.Part1);
    }

    [Test]
    public void Day4Part2()
    {
        RunTestForDayPart("Day4", Parts.Part2);
    }

    [Test]
    public void Day5Part1()
    {
        RunTestForDayPart("Day5", Parts.Part1);
    }

    [Test]
    public void Day5Part2()
    {
        RunTestForDayPart("Day5", Parts.Part2);
    }
}
using AdventOfCode2024;

namespace tests;


public class DaysTests
{

    private string rootTestDir = @"C:\Users\bob0t\source\repos\AdventOfCode\2024\tests";

    [SetUp]
    public void Setup()
    {
    }

    private void RunTestForDayPart1(string day)
    {
        var testInput = rootTestDir + @$"\testData\{day}\test";
        var t = Type.GetType($"AdventOfCode2024.{day}, AdventOfCode2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        var dayClass = (DayTemplate) Activator.CreateInstance(t, testInput);
        Console.WriteLine($"{day} Part 1, test: {dayClass?.Part1()}");
        Assert.NotNull(dayClass?.Part1());

        var dayInput = rootTestDir + @$"\testData\{day}\input";
        dayClass?.SetLines(dayInput);
        Console.WriteLine($"{day} Part 1, actual: {dayClass?.Part1()}");
        Assert.NotNull(dayClass?.Part1());
    }

    private void RunTestForDayPart2(string day)
    {
        var testInput = rootTestDir + @$"\testData\{day}\test";
        var t = Type.GetType($"AdventOfCode2024.{day}, AdventOfCode2024, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        var dayClass = (DayTemplate) Activator.CreateInstance(t, testInput);
        Console.WriteLine($"{day} Part 2, test: {dayClass?.Part2()}");
        Assert.NotNull(dayClass?.Part2());

        var dayInput = rootTestDir + @$"\testData\{day}\input";
        dayClass?.SetLines(dayInput);
        Console.WriteLine($"{day} Part 2, actual: {dayClass?.Part2()}");
        Assert.NotNull(dayClass?.Part2());
    }

[Test]
    public void Day1Test1()
    {
        RunTestForDayPart1("Day1");
    }

    [Test]
    public void Day1Test2()
    {
        RunTestForDayPart2("Day1");
    }

    [Test]
    public void Day2Test1()
    {
        RunTestForDayPart1("Day2");
    }

    [Test]
    public void Day2Test2()
    {
        RunTestForDayPart2("Day2");
    }
}
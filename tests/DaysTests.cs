using AdventOfCode2024;

namespace tests;


public class DaysTests
{

    private string rootTestDir = @"C:\Users\bob0t\source\repos\AdventOfCode\2024\tests";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day1Test1()
    {
        var testInput = File.ReadAllLines(rootTestDir+@"\testData\Day1\test");
        Day1 day = new Day1(testInput);
        Console.WriteLine(day.Part1());
        Assert.NotZero(day.Part1());

        var dayInput = File.ReadAllLines(rootTestDir+@"\testData\Day1\input");
        day.lines = dayInput;
        Console.WriteLine(day.Part1());
        Assert.NotZero(day.Part1());
    }

    [Test]
    public void Day1Test2()
    {
        var testInput = File.ReadAllLines(rootTestDir+@"\testData\Day1\test");
        Day1 day = new Day1(testInput);
        Console.WriteLine(day.Part2());
        Assert.NotZero(day.Part2());

        var dayInput = File.ReadAllLines(rootTestDir+@"\testData\Day1\input");
        day.lines = dayInput;
        Console.WriteLine(day.Part2());
        Assert.NotZero(day.Part2());
    }
}
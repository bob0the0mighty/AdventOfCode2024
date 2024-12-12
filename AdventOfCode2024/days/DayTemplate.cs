namespace AdventOfCode2024;

public abstract class DayTemplate
{
    protected string[] lines;

    public DayTemplate(string fileLocation){
        lines = File.ReadAllLines(fileLocation);
    }

    public void SetLines(string fileLocation){
        lines = File.ReadAllLines(fileLocation);
    }

    public abstract string Part1();

    public abstract string Part2();
}
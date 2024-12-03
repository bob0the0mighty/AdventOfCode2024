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

    public abstract int Part1();

    public abstract int Part2();
}
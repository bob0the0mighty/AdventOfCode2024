using System.Runtime.ExceptionServices;
using System.Text;

namespace AdventOfCode2024;

public class Day2 : DayTemplate
{
    public Day2(string fileLocation) : base(fileLocation){}

    public override int Part1(){
        return lines.Select(line => {
            var ints = line.Split(" ")
                        .Select(int.Parse);
            return checkIfGood(ints);
        })
        .Where(isGood => isGood)
        .Count();
    }

    public override int Part2(){
        return lines.Select(line =>
        {
            var ints = line.Split(" ")
                        .Select(int.Parse);
            bool isGood = checkIfGood(ints);

            if (!isGood)
            {
                for(var x = 0; x < ints.Count(); ++x){
                    if(checkIfGood(ints.Where((_, idx) => idx != x))){
                        return true;
                    }
                }
            }
            return isGood;
        })
        .Where(isGood => isGood)
        .Count();
    }

    private static bool checkIfGood(IEnumerable<int> ints)
    {
        var tuples = ints.Zip(ints.Skip(1), Tuple.Create);
        var differences = tuples.Select(pair => pair.Item1 - pair.Item2);
        var isGood = differences.All(dif => 1 <= int.Abs(dif) && int.Abs(dif) <= 3) &&
            (int.IsPositive(differences.First()) ? differences.All(int.IsPositive) : differences.All(int.IsNegative));
        return isGood;
    }
}
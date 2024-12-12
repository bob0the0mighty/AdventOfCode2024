
using System.Text.RegularExpressions;
using AdventOfCode2024.helpers;

namespace AdventOfCode2024;

public class Day3 : DayTemplate
{
    private static Regex mulReg = new Regex(@"(?<=mul\()(\d+,\d+)(?=\))");
    private static Regex doReg = new Regex(@"(do\(\))|(don't\(\))");

    public Day3(string fileLocation) : base(fileLocation){}

    public override string Part1()
    {
        var input = string.Join("", lines);
        var matches = mulReg.Matches(input);
        
        return matches.Select(item => 
            item.Value.Split(",")
                .Select(int.Parse)
                .Aggregate((x, y) => x * y)
            )
            .Sum()
            .ToString();
    }

    public override string Part2()
    {
        var input = string.Join("", lines);
        var mulMatches = mulReg.Matches(input);
        var doMatches = doReg.Matches(input)
            .NonConsecutive((match1, match2) => match1.Value != match2.Value);

        if(doMatches.FirstOrDefault().Value == "do()"){
            doMatches = doMatches.Skip(1);
        }

        var dontRanges = doMatches.Chunk(2)
            .Select(matches => (matches[0].Index, matches[1].Index+matches[1].Length));

        return mulMatches.Select(item => {
                if(dontRanges.Any(range => range.Index < item.Index && item.Index < range.Item2)){
                    return 0;
                } else {
                    return item.Value.Split(",")
                    .Select(int.Parse)
                    .Aggregate((x, y) => x * y);
                }
            })
            .Sum()
            .ToString();
    }
}
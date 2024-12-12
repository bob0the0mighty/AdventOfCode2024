using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day5 : DayTemplate
{
    public IEnumerable<string[]>? rules;
    public IEnumerable<string[]>? updates;
    public ILookup<string, string> rulesLookup;

    public Day5(string fileLocation) : base(fileLocation){}

    public override string Part1()
    {
        this.rules = lines.Where(line => Regex.IsMatch(line, @"\d+\|\d+"))
            .Select(line => line.Split("|"));
        this.updates = lines.Where(line => Regex.IsMatch(line, @"\d+,"))
            .Select(line => line.Split(","));

        this.rulesLookup = rules.ToLookup(p => p[0], p => p[1]);

        return updates.Where(pages =>
            {
                return checkForValidUpdate(pages, rulesLookup);
            })
        .Select(updates => int.Parse(updates[updates.Length/2]))
        .Sum()
        .ToString();
    }

    private static bool checkForValidUpdate(string[] pages, ILookup<string, string> rulesLookup)
    {
        for (var x = 1; x < pages.Length; ++x)
        {
            var currentPage = pages[x];
            var previousPages = new ArraySegment<string>(pages, 0, x);
            var badRules = previousPages.Intersect(rulesLookup[currentPage].ToArray());
            if (badRules.Any())
            {
                return false;
            }
        }
        return true;
    }

    public override string Part2()
    {
        this.rules = lines.Where(line => Regex.IsMatch(line, @"\d+\|\d+"))
            .Select(line => line.Split("|"));
        this.updates = lines.Where(line => Regex.IsMatch(line, @"\d+,"))
            .Select(line => line.Split(","));

        this.rulesLookup = rules.ToLookup(p => p[0], p => p[1]);

        return updates.Where(pages =>
            {
                return !checkForValidUpdate(pages, rulesLookup);
            })
        .Select(pages => UpdateOrdering(pages, rulesLookup))
        .Select(updates => int.Parse(updates[updates.Length/2]))
        .Sum()
        .ToString();
    }

    public static string[] UpdateOrdering(string[] pages, ILookup<string, string> ruleLookup){
        var comparer = new PageComparator(ruleLookup);
        var orderdPages = pages.OrderBy(x => x, comparer);
        return orderdPages.ToArray();
    }
}

public class PageComparator : IComparer<string>
{
    ILookup<string, string> lookup;

    public PageComparator(ILookup<string, string> lookup){
        this.lookup = lookup;
    }

    public int Compare(string? x, string? y)
    {
        return lookup.Contains(x) && lookup[x].Contains(y) ? -1 : 1;
    }
}
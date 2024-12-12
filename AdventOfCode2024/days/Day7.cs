namespace AdventOfCode2024;

public class Day7 : DayTemplate
{
    public Day7(string fileLocation) : base(fileLocation){}

    public override string Part1()
    {
        IEnumerable<long> sums;
        List<IEnumerable<long>> operands;
        prepareInput(out sums, out operands);

        return sums.Where((sum, index) => TryCombinations(sum, operands[index], 0))
            .Sum()
            .ToString();
    }

    private void prepareInput(out IEnumerable<long> sums, out List<IEnumerable<long>> operands)
    {
        var sumAndOperands = lines.Select(line =>
                    line.Split(":")
                );
        sums = sumAndOperands.Select(line => Int64.Parse(line[0]));
        operands = sumAndOperands.Select(line =>
            line[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse))
            .ToList();
    }

    bool TryCombinations(Int64 sum, IEnumerable<long> operands, Int64 currentSum)
        {
            var operandsList = operands.ToList();
            if (operandsList.Count() == 0) return currentSum == sum;
                if (currentSum > sum) return false;

            return TryCombinations(sum, operandsList.Skip(1), Math.Max(currentSum, 1) * operandsList.First())
                || TryCombinations(sum, operandsList.Skip(1), currentSum + operandsList.First());
        }

    public override string Part2(){
        IEnumerable<long> sums;
        List<IEnumerable<long>> operands;
        prepareInput(out sums, out operands);

        return sums.Where((sum, index) => TryCombinations2(sum, operands[index], 0))
            .Sum()
            .ToString();
    }

    bool TryCombinations2(Int64 sum, IEnumerable<long> operands, Int64 currentSum)
        {
            var operandsList = operands.ToList();
            if (operandsList.Count() == 0) return currentSum == sum;
                if (currentSum > sum) return false;

            return TryCombinations2(sum, operandsList.Skip(1), Math.Max(currentSum, 1) * operandsList.First())
                || TryCombinations2(sum, operandsList.Skip(1), currentSum + operandsList.First())
                || TryCombinations2(sum, operandsList.Skip(1), long.Parse(currentSum.ToString() + operandsList.First().ToString()));
        }
}
namespace AdventOfCode2024;

public class Day1 : DayTemplate
{
    public Day1(string fileLocation): base(fileLocation){}

    public override string Part1(){
        var list1 = new List<int>();
        var list2 = new List<int>();
        
        foreach(var line in lines){
            var ints = line.Split(" ")
                .Select(str => str.Trim());
            list1.Add(int.Parse(ints.First()));
            list2.Add(int.Parse(ints.Last()));
        }

        list1.Sort();
        list2.Sort();

        return list1.Zip(list2, (x, y) => (x, y))
            .Select( val => {
                if(val.x > val.y){
                    return val.x - val.y;
                } else {
                    return val.y - val.x;
                } 
            })
            .Sum()
            .ToString();
    }

    public override string Part2(){
        var list1 = new List<int>();
        var dict2 = new Dictionary<int, int>();
        
        foreach(var line in lines){
            var ints = line.Split(" ")
                .Select(str => str.Trim());
            list1.Add(int.Parse(ints.First()));
            dict2[int.Parse(ints.Last())] = dict2.GetValueOrDefault(int.Parse(ints.Last()), 0) + 1;
        }

        return list1.Select( val => val * dict2.GetValueOrDefault(val, 0))
            .Sum()
            .ToString();
    }
}

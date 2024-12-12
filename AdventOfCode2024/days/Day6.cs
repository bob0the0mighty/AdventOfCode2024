using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

using Point = (int X, int Y);

public class Day6 : DayTemplate
{
    
    public Day6(string fileLocation) : base(fileLocation){}

    public override string Part1()
    {
        Point position = (X: 0, Y: 0);
        for(var y = 0; y < lines.Length; ++y){
            for(var x = 0; x < lines[y].Length; ++x){
                if(lines[y][x] == '^'){
                    position = (X: x, Y: y);
                }
            }
        }

        var lineArray = lines.Select(line => line.ToArray())
            .ToArray();

        var positions = 0;
        
        while(true){
            (lineArray, position) = moveGuard(lineArray, position);
            if(position == (-1,-1)){
                break;
            }
        }

        positions = lineArray.Select(line => line.Count(c => c == 'X'))
            .Sum();

        return positions.ToString();
    }

    public override string Part2()
    {
        Point position = (X: 0, Y: 0);
        for(var y = 0; y < lines.Length; ++y){
            for(var x = 0; x < lines[y].Length; ++x){
                if(lines[y][x] == '^'){
                    position = (X: x, Y: y);
                }
            }
        }

        var lineArray = lines.Select(line => line.ToArray())
            .ToArray();

        var loops = 0;
        
        while(true){
            if(doesBlockageResultInLoop(lineArray, position)){
                ++loops;
                //Console.WriteLine($"loops: {loops}");
            }

            (lineArray, position) = moveGuard(lineArray, position);
            if(position.X == -1){
                break;
            }
        }

        return loops.ToString();
    }

    private void outputMap(char[][] map){
        foreach(var line in map){
            Console.WriteLine(new string(line));
        }
        Console.WriteLine();
    }

    public (char[][], Point) moveGuard(char[][] map, Point position)
    {
        (int X, int Y) newPosistion = getNextGuardPosition(map, position);
        char[][] newMap = copyMap(map);

        switch (map[newPosistion.Y][newPosistion.X])
        {
            case '.' or 'X':
                newMap[newPosistion.Y][newPosistion.X] = map[position.Y][position.X];
                newMap[position.Y][position.X] = 'X';
                break;
            case '#' or 'N':
                newMap[position.Y][position.X] = RotateGuard(map, position);
                newPosistion = position;
                break;
            case 'W':
                newMap[position.Y][position.X] = 'X';
                newPosistion = (-1, -1);
                break;
        };
        return (newMap, newPosistion);
    }

    private static char[][] copyMap(char[][] map)
    {
        return map.Select(line => line.ToArray()).ToArray();
    }

    private static (int X, int Y) getNextGuardPosition(char[][] map, (int X, int Y) position)
    {
        return map[position.Y][position.X] switch
        {
            '^' => (position.X, position.Y - 1),
            '>' => (position.X + 1, position.Y),
            'v' => (position.X, position.Y + 1),
            '<' => (position.X - 1, position.Y),
            _ => position
        };
    }

    public bool doesBlockageResultInLoop(char[][] map, Point position){
        var newBlockageMap = copyMap(map);
        var blockagePosition = getNextGuardPosition(newBlockageMap, position);
        newBlockageMap[blockagePosition.Y][blockagePosition.X] = '#';
        
        var oldPosition = position;
        var movesList = new HashSet<(Point, Point)>();
        while(true){
            (newBlockageMap, position) = moveGuard(newBlockageMap, oldPosition);
            if(position.X == -1){
                return false;
            }

            if(movesList.Contains((oldPosition, position))){
                //outputMap(newBlockageMap);
                return true;
            }

            if(oldPosition != position){
                movesList.Add((oldPosition, position));
            }
            oldPosition = position;
        }
    }

    public char RotateGuard(char[][] map, Point position){
        var currentOrientation = map[position.Y][position.X];

        return currentOrientation switch {
            '^' => '>',
            '>' => 'v',
            'v' => '<',
            '<' => '^',
            _ => currentOrientation
        };
    }
}
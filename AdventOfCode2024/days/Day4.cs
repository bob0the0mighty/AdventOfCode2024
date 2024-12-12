namespace AdventOfCode2024;

public class Day4 : DayTemplate
{
    public Day4(string fileLocation) : base(fileLocation){}

    public override string Part1()
    {
        var xmasFound = 0;
        for(var y = 0; y < lines.Length; ++y){
            for(var x = 0; x < lines[y].Length; ++x){
                if(lines[y][x] == 'X'){
                    xmasFound += CountXmas(x, y);
                }
            }
        }
        return xmasFound.ToString();
    }

    public override string Part2()
    {
        var xedMasFound = 0;
        for(var y = 0; y < lines.Length; ++y){
            for(var x = 0; x < lines[y].Length; ++x){
                if(lines[y][x] == 'A'){
                    xedMasFound += CountXedMas(x, y) ? 1 : 0;
                }
            }
        }
        return xedMasFound.ToString();
    }

    public int CountXmas(int x, int y) {
        var xmasFound = 0;
        //look in the eight directions
        //right
        if(x + 3 < lines[y].Length){
            xmasFound += XmasExists(lines[y][x+1], lines[y][x+2], lines[y][x+3]) ? 1 : 0;
        }
        //diagonal down and right
        if(y + 3 < lines.Length && x + 3 < lines[y].Length){
            xmasFound += XmasExists(lines[y+1][x+1], lines[y+2][x+2], lines[y+3][x+3]) ? 1 : 0;
        }
        //down
        if(y + 3 < lines.Length){
            xmasFound += XmasExists(lines[y+1][x], lines[y+2][x], lines[y+3][x]) ? 1 : 0;
        }
        //diagonal down and left
        if(y + 3 < lines.Length && x - 3 >= 0){
            xmasFound += XmasExists(lines[y+1][x-1], lines[y+2][x-2], lines[y+3][x-3]) ? 1 : 0;
        }
        //left
        if(x - 3 >= 0){
            xmasFound += XmasExists(lines[y][x-1], lines[y][x-2], lines[y][x-3]) ? 1 : 0;
        }
        //diagonal up and left
        if(y - 3 >= 0 && x - 3 >= 0){
            xmasFound += XmasExists(lines[y-1][x-1], lines[y-2][x-2], lines[y-3][x-3]) ? 1 : 0;
        }
        //up
        if(y - 3 >= 0){
            xmasFound += XmasExists(lines[y-1][x], lines[y-2][x], lines[y-3][x]) ? 1 : 0;
        }
        //diagonal up and right
        if(y - 3 >= 0 && x + 3 < lines[y].Length){
            xmasFound += XmasExists(lines[y-1][x+1], lines[y-2][x+2], lines[y-3][x+3]) ? 1 : 0;
        }
        return xmasFound;
    }

    public bool XmasExists(char m, char a, char s){
        return m == 'M' && a == 'A' && s == 'S' ;
    }

    public bool CountXedMas(int x, int y) {
        var xedMasFound = false;
        //look in the four directions
        //diagonal down and right
        var topLeftShouldBe = 'B';
        if(y + 1 < lines.Length && x + 1 < lines[y].Length){
            if(MorS(lines[y+1][x+1])){
                topLeftShouldBe = (lines[y+1][x+1] == 'M') ? 'S' : 'M';
            }
        } else {
            return false;
        }
        //diagonal down and left
        var topRightShouldBe = 'B';
        if(y + 1 < lines.Length && x - 1 >= 0){
            var morS = MorS(lines[y+1][x-1]);
            if(MorS(lines[y+1][x-1])){
                topRightShouldBe = (lines[y+1][x-1] == 'M') ? 'S' : 'M';
            }
        } else {
            return false;
        }

        //diagonal up and left
        if(y - 1 >= 0 && x - 1 >= 0 && lines[y-1][x-1] == topLeftShouldBe){
            xedMasFound = true;
        } else {
            return false;
        }

        //diagonal up and right
        if(y - 1 >= 0 && x + 1 < lines[y].Length && lines[y-1][x+1] == topRightShouldBe){
            xedMasFound &= true;
        } else {
            return false;
        }

        return xedMasFound;
    }

    public bool MorS(char c){
        return c == 'M' || c == 'S';
    }
}

using static System.Console;

namespace ConsoleApp31;

internal class Game1
{

    static public void CreateChessBoard() //nermucum enq dirqy ev qary
    {
        string f;
        char x;
        int y;
        string pos;




        do
        {
            WriteLine("Writh a position");
            pos = ReadLine();
            if (pos.Length == 2 &&
               char.TryParse(pos[0].ToString(), out x) &&
               int.TryParse(pos[1].ToString(), out y) &&
               x >= 'A' && x <= 'H' &&
               y >= 1 && y <= 8)
            {
                WriteLine("correct position " + pos);
                break;
            }
            else
            {
                WriteLine("incorrect position");
            }
        }
        while (true);
        do
        {
            WriteLine("Writh a figur: K Q B N R ");
            f = ReadLine();

            if (f == "K" && f == "Q" && f == "B" && f == "N" && f == "R")
            {
                WriteLine("correct figure" + f);
                break;
            }
            else
            {
                WriteLine("incorrect figure");
            }
            Coord coord = new Coord(x, y);
            Figure figure = (Figure)Enum.Parse(typeof(Figure), f);
            ChessBoard(coord, figure);
        }
        while (true);
    }

    static void ChessBoard(Coord coord, Figure f) //sarqum enq taxtak
    {
        for (int i = 9; i >= 0; i--)
        {
            if (i == 0 || i == 9)
            {
                Write(" ");

                foreach (tox symbol in Enum.GetValues(typeof(tox))) ///veradrarcnum e tvarkac andamnery
                {
                    Write(symbol + " ");
                }
            }
            else
            {
                Write(i);
                for (int j = 0; j <= 7; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        BackgroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        BackgroundColor = ConsoleColor.Black;

                    }
                    if (i == coord.yCoord && ((int)coord.xCoord - 65) == j)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        Write(f + " ");
                        ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Write("  ");
                    }
                }
                BackgroundColor = ConsoleColor.Black;
                Write(i);
            }

            WriteLine();

        }
        if (NorQayl(ref coord, f))
        {
            ChessBoard(coord, f);
        }
    }
    static bool NorQayl(ref Coord coord, Figure f) //qareri varkn enq talis
    {
        char x1;
        int y1;
        string pos;

        do
        {
            WriteLine("Next position");
            pos = ReadLine();
            if (pos.Length == 2 &&
               char.TryParse(pos[0].ToString(), out x1) &&
               int.TryParse(pos[1].ToString(), out y1) &&
               x1 >= 'A' && x1 <= 'H' &&
               y1 >= 1 && y1 <= 8)
            {
                WriteLine("correct position " + pos);
                break;
            }
            else
            {
                WriteLine("incorrect position");

            }
        }
        while (true);

        switch (f)
        {
            case Figure.K:

                if (coord.xCoord >= x1 - 1 && coord.xCoord <= x1 + 1 && coord.yCoord >= y1 - 1 && coord.yCoord <= y1 + 1)
                {
                    coord.xCoord = x1;
                    coord.yCoord = y1;
                    return true;

                }
                WriteLine("next step is not correct");
                return false;
            case Figure.R:
                if (coord.xCoord == x1 || coord.yCoord == y1)
                {
                    coord.xCoord = x1;
                    coord.yCoord = y1;
                    return true;
                }
                WriteLine("next step is not correct");
                return false;
            case Figure.B:
                if ((Math.Abs(x1 - coord.xCoord) == Math.Abs(y1 - coord.yCoord)))
                {
                    coord.xCoord = x1;
                    coord.yCoord = y1;
                    return true;
                }
                WriteLine("next step is not correct");
                return false;
            case Figure.Q:
                if ((coord.xCoord == x1 || coord.yCoord == y1) || Math.Abs(x1 - coord.xCoord) == Math.Abs(y1 - coord.yCoord))
                {
                    coord.xCoord = x1;
                    coord.yCoord = y1;
                    return true;
                }
                WriteLine("next step is not correct");
                return false;

            case Figure.N:
                if ((x1 == coord.xCoord + 2 && y1 == coord.yCoord + 1) || (x1 == coord.xCoord + 1 && y1 == coord.yCoord + 2) || (x1 == coord.xCoord - 1 && y1 == coord.yCoord + 2) ||
                    (x1 == coord.xCoord - 2 && y1 == coord.yCoord + 1) || (x1 == coord.xCoord - 2 && y1 == coord.yCoord - 1) || (x1 == coord.xCoord - 1 && y1 == coord.yCoord - 2) ||
                    (x1 == coord.xCoord + 1 && y1 == coord.yCoord - 2) || (x1 == coord.xCoord - 2 && y1 == coord.yCoord - 1))
                {
                    coord.xCoord = x1;
                    coord.yCoord = y1;
                    return true;
                }
                WriteLine("next step is not correct");
                return false;
            default:
                WriteLine("Unknown figur");
                return false;

        }
    }


}




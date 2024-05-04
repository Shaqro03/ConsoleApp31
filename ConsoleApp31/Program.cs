using static System.Console;


namespace ConsoleApp31;
internal class Program
{
    static void Main(string[] args)
    {
        GameChess();
    }

    static void GameChess()
    {
        WriteLine("G1,G2 or G3");
        string game = ReadLine();
        if (game == "G1")
        {
            Game1.CreateChessBoard();
        }
        
         if (game == "G2")
        {
            Game2.G2();
        }
        if (game == "G3")
        {
            Game3.G3();
        }

        else
        {
            WriteLine("not correct game try again ");
        }

    }



}




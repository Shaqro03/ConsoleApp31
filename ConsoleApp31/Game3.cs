using System.Drawing;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

namespace ConsoleApp31;

internal class Game3
{
    static public void G3()
    {
        string[,] matrix = new string[8, 8];
        int x;
        int y;
        string pos;
        string f;
        var coordF = new List<(int X, int Y, string F)>();
        
            do
            {
                Console.WriteLine("Write a pos:  A1 ");
                pos = Console.ReadLine();

                if (pos.Length == 2 && pos[0] >= 'A' && pos[0] <= 'H' && pos[1] >= '1' && pos[1] <= '8')
                {
                    x = pos[0] - 'A';
                    y = pos[1] - '1';
                }
                else
                {
                    Console.WriteLine("Incorrect pos");
                    continue; 
                }

                Console.WriteLine("Write white/black figure Kw/Kb: ");
                f = Console.ReadLine();

                if (f.Length >= 2 && ((f[0] == 'K' || f[0] == 'Q' || f[0] == 'B' || f[0] == 'R' || f[0] == 'N') && (f[1] == 'w' || f[1] == 'b')))
                {
                    Console.WriteLine($"Correct figure: {f}");
                }
                else
                {
                    Console.WriteLine("Incorrect figure");
                    continue; 
                }

                coordF.Add((x, y, f));

                Console.WriteLine("Continue? yes/no");
                string a = Console.ReadLine();
                if (a == "no")
                {
                    break;
                }

            } while (true); 
        
        ChessFigure(matrix, coordF);




    }

    static void ChessFigure(string[,] matrix, List<(int X, int Y, string F)> coordF)
    {
        int i;
        int j;
        int x, y;
        for(i=0;i<8;i++)
        {
            for(j=0;j<8;j++)
            {
                foreach(var call in coordF) 
                {
                    if(i == call.X && j == call.Y) 
                    {
                        matrix[i, j] = call.F;
                    }
                }
            }
     
        }
        foreach (var call in coordF)
        {
            switch(call.F[0])
            {
                case 'K':
                King(matrix,call.X,call.Y,call.F);
                break;
                case 'N':
                Knight(matrix, call.X, call.Y, call.F);
                break;
                default:
                break;        
            }    
        }

        Board(matrix);
    }

    static void King(string[,] matrix, int X, int Y, string F)
    {
        int i;
        int j;
        for (i = 0; i < 8; i++)
        {
            for (j = 0; j < 8; j++)
            {
                if ((i >= X - 1 && i <= X + 1 && j >= Y - 1 && j <= Y + 1) && (matrix[i, j] == null || matrix[i, j] == "w" || matrix[i, j] == "b"))
                {
                    if ((F[1] == 'b' && matrix[i, j] == "w") || (F[1] == 'w' && matrix[i, j] == "b"))
                    {
                        matrix[i, j] = "g";
                    }
                    else
                    {
                        matrix[i, j] = Char.ToString(F[1]);
                    }
                }

            }
        }

    }
    static void Knight(string[,] matrix, int X, int Y, string F)
    {
        int i;
        int j;
        for (i = 0; i < 8; i++)
        {
            for (j = 0; j < 8; j++)
            {
                if ((Math.Abs(i - X) == 2) && (Math.Abs(j - Y) == 1) || (Math.Abs(i - X) == 1) && (Math.Abs(j - Y) == 2) && (matrix[i, j] == null || matrix[i, j] == "w" || matrix[i, j] == "b"))
                {
                    if ((F[1] == 'b' && matrix[i, j] == "w") || (F[1] == 'w' && matrix[i, j] == "b"))
                    {
                        matrix[i, j] = "g";
                    }
                    else
                    {
                        matrix[i, j] = Char.ToString(F[1]);
                    }
                }
            }
        }
    }
    static void Board(string[,] matrix)
    {
        for (int i = 9; i >= 0; i--)
        {

            if (i == 0 || i == 9)
            {
                Console.Write(" ");
                for (char letter = 'A'; letter <= 'H'; letter++)
                {
                    Console.Write(letter + " ");
                }
            }
            else
            {
                Console.Write(i);
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        if (matrix[j, i - 1] == null)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ");
                        }
                        else if (matrix[j, i - 1] == "w")
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                        }
                        else if (matrix[j, i - 1] == "b")
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("  ");
                        }
                        else if (matrix[j, i - 1] == "g")
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            if (matrix[j, i - 1][1] == 'w')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(matrix[j, i - 1][0] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(matrix[j, i - 1][0] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    else
                    {
                        if (matrix[j, i - 1] == null)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                        }
                        else if (matrix[j, i - 1] == "w")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("  ");
                        }
                        else if (matrix[j, i - 1] == "b")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("  ");
                        }
                        else if (matrix[j, i - 1] == "g")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (matrix[j, i - 1][1] == 'w')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(matrix[j, i - 1][0] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(matrix[j, i - 1][0] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }

}

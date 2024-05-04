namespace ConsoleApp31;

internal class Game2
{
    static public void G2()
    {


        int[,] matrix = new int[8, 8];
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        string pos;
        Console.WriteLine("Write a start position");
        while (true)
        {
            pos = Console.ReadLine();
            if (pos.Length != 2 || (pos[0] < 'A' || pos[0] > 'H') || (pos[1] <= '0' || pos[1] > '8'))
            {
                Console.WriteLine("Write a correct position");
            }
            else
            {
                x1 = pos[0] - 'A';
                y1 = pos[1] - '1';
                break;

            }
        }
        Console.WriteLine("Write a target position");
        while (true)
        {
            pos = Console.ReadLine();
            if (pos.Length != 2 || (pos[0] < 'A' || pos[0] > 'H') || (pos[1] <= '0' || pos[1] > '8'))
            {
                Console.WriteLine("Write a correct position");
            }
            else
            {
                x2 = pos[0] - 'A';
                y2 = pos[1] - '1';
                break;

            }
        }
        int min = KnightMinimumMoves(matrix, x1, y1, x2, y2);
        int[,] path = new int[min + 1, 2];
        path[min, 0] = x2;
        path[min, 1] = y2;
        FindingPath(matrix, ref path, min - 1, x2, y2);

        KnightGameBoard(min, path);
    }

    static int KnightMinimumMoves(int[,] matrix, int startX, int startY, int targetX, int targetY)
    {
        int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int qan = 0;
        int min = 0;
        int moves = 1;

        if (targetX == startX && targetY == startY)
        {
            return 0;
        }
        for (int i = 0; i < 8; i++)
        {
            if (startX + dx[i] < 8 && startY + dy[i] < 8 && startX + dx[i] >= 0 && startY + dy[i] >= 0 && matrix[startX + dx[i], startY + dy[i]] == 0)
            {
                qan++;
                matrix[startX + dx[i], startY + dy[i]] = moves;
                if (targetX == startX + dx[i] && targetY == startY + dy[i])
                {
                    min = moves;
                    return min;
                }
            }
        }

        while (qan != 63)
        {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    if (matrix[x, y] == moves)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if ((x + dx[i] < 8 && y + dy[i] < 8 && x + dx[i] >= 0 && y + dy[i] >= 0 && matrix[x + dx[i], y + dy[i]] == 0) && (startX != x + dx[i] || startY != y + dy[i]))
                            {
                                qan++;
                                matrix[x + dx[i], y + dy[i]] = moves + 1;
                                if (targetX == x + dx[i] && targetY == y + dy[i])
                                {
                                    min = moves + 1;
                                }
                            }
                        }
                    }
            moves++;
        }
        return min;
    }

    static void FindingPath(int[,] matrix, ref int[,] path, int min, int targetX, int targetY)
    {
        int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
        for (int i = 0; i < 8; i++)
        {

            if ((targetX + dx[i] < 8 && targetY + dy[i] < 8 && targetX + dx[i] >= 0 && targetY + dy[i] >= 0) && (matrix[targetX + dx[i], targetY + dy[i]] == min))
            {
                path[min, 0] = targetX + dx[i];
                path[min, 1] = targetY + dy[i];
                if (min == 0)
                    return;
                else
                    min--;
                FindingPath(matrix, ref path, min, targetX + dx[i], targetY + dy[i]);
            }
        }
    }

    static void KnightGameBoard(int min, int[,] path)
    {
        int a;
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
                    a = 0;
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    for (int k = min; k >= 0; k--)
                    {
                        if (i == path[k, 1] + 1 && path[k, 0] == j)
                        {
                            a = 1;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(k + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    if (a == 0)
                    {
                        Console.Write("  ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(i);
            }
            Console.WriteLine();
        }


    }
}



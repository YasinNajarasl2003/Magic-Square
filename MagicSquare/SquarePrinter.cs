using System.Text;

public class SquarePrinter
{
    public static void PrintSquare(int[,] magicSquare, int n)
    {

        Console.WriteLine($"The Magic Square for {n} :");
        StringBuilder str = new StringBuilder();
        int length = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                switch (magicSquare[i, j].ToString().Length)
                {
                    case 1:
                        str.Append($"|  {magicSquare[i, j]}  ");
                        break;
                    case 2:
                        str.Append($"| {magicSquare[i, j]}  ");
                        break;
                    case 3:
                        str.Append($"| {magicSquare[i, j]} ");
                        break;
                    case 4:
                        str.Append($"|{magicSquare[i, j]} ");
                        break;
                    case 5:
                        str.Append($"|{magicSquare[i, j]}");
                        break;
                }
            }
            str.Append("|\n");
            if (i == 0)
                length = str.Length + "|\n".Length;
            if (i == n - 1)
            {
                str.Append("|");
                for (int c = 1; c <= length - 5; c++)
                {
                    if (c % 6 == 0)
                        str.Append("|");
                    else
                        str.Append("_");
                }
                str.Append("|");
                str.AppendLine();
            }
            else
            {
                for (int c = 0; c <= length - 4; c++)
                {
                    if (c % 6 == 0)
                        str.Append("|");
                    else
                        str.Append("-");
                }
                str.AppendLine();
            }
        }

        StringBuilder start = new();
        for (int c = 0; c <= length - 4; c++)
        {
            start.Append("_");
        }
        Console.WriteLine(start);
        Console.WriteLine(str);

        Console.WriteLine($"Sum of each row or column = {n * (n * n + 1) / 2}");
    }
}
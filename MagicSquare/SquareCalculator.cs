using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class SquareCalculator
{
    public static int[,] OddSquareGenerator(int n)
    {
        int[,] magicSquare = new int[n, n];

        int i = n / 2;
        int j = n - 1;

        for (int num = 1; num <= n * n;)
        {
            if (i == -1 && j == n)
            {
                j = n - 2;
                i = 0;
            }
            else
            {
                if (j == n)
                    j = 0;

                if (i < 0)
                    i = n - 1;
            }

            if (magicSquare[i, j] != 0)
            {
                j -= 2;
                i++;
                continue;
            }
            else
                magicSquare[i, j] = num++;
            j++;
            i--;
        }

        return magicSquare;
    }
    public static int[,] DoublyEvenSquareGenerator(int n)
    {
        int[,] magicSquare = new int[n, n];


        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                magicSquare[i, j] = (n * i) + j + 1;


        for (int i = 0; i < n / 4; i++)
            for (int j = 0; j < n / 4; j++)
                magicSquare[i, j] = (n * n + 1) - magicSquare[i, j];


        for (int i = 0; i < n / 4; i++)
            for (int j = 3 * (n / 4); j < n; j++)
                magicSquare[i, j] = (n * n + 1) - magicSquare[i, j];

        for (int i = 3 * n / 4; i < n; i++)
            for (int j = 0; j < n / 4; j++)
                magicSquare[i, j] = (n * n + 1) - magicSquare[i, j];


        for (int i = 3 * n / 4; i < n; i++)
            for (int j = 3 * n / 4; j < n; j++)
                magicSquare[i, j] = (n * n + 1) - magicSquare[i, j];

        for (int i = n / 4; i < 3 * n / 4; i++)
            for (int j = n / 4; j < 3 * n / 4; j++)
                magicSquare[i, j] = (n * n + 1) - magicSquare[i, j];

        return magicSquare;
    }
    public static int[,] SinglyEvenSquareGenerator(int n)
    {
        int[,] magicSquare = new int[n, n];
        FillQuarterOfSinglyEvenOrder(0, n / 2, 0, n / 2, 1, (n / 2) * (n / 2), magicSquare);
        FillQuarterOfSinglyEvenOrder(n / 2, n, n / 2, n, (n / 2) * (n / 2) + 1, n * n / 2, magicSquare);
        FillQuarterOfSinglyEvenOrder(0, n / 2, n / 2, n, n * n / 2 + 1, 3 * (n / 2) * (n / 2), magicSquare);
        FillQuarterOfSinglyEvenOrder(n / 2, n, 0, n / 2, 3 * (n / 2) * (n / 2) + 1, n * n, magicSquare);

        int shiftCol = (n / 2 - 1) / 2;
        int i, j;
        for (i = 0; i < n / 2; i++)
        {
            for (j = 0; j < shiftCol; j++)
            {
                if (i == n / 4)
                {
                    ExchangeCell(i, j + shiftCol, n, magicSquare);
                }
                else ExchangeCell(i, j, n, magicSquare);
            }
        }
        for (i = 0; i < n / 2; i++)
        {
            for (j = n - 1; j > n - shiftCol; j--)
            {
                ExchangeCell(i, j, n, magicSquare);
            }
        }

        return magicSquare;
    }
    private static int[,] FillQuarterOfSinglyEvenOrder(int firstRow, int lastRow,
        int firstColumn, int lastColumn, int num, int lastNum,
        int[,] matrix)
    {
        int i = firstRow;
        int j = (lastColumn + firstColumn) / 2;
        while (num <= lastNum)
        {
            if (i < firstRow && j >= lastColumn)
            {
                i += 2;
                j--;
            }
            if (j >= lastColumn)
            {
                j = firstColumn;
            }
            if (i < firstRow)
            {
                i = lastRow - 1;
            }
            if (matrix[i, j] != 0)
            {
                i += 2;
                j--;
                continue;
            }
            else
            {
                matrix[i, j] = num;
                num++;
            }
            i--;
            j++;
        }
        return matrix;
    }
    private static int[,] ExchangeCell(int i, int j, int n, int[,] matrix)
    {
        int r = (n / 2) + i;
        int temp = matrix[i, j];
        matrix[i, j] = matrix[r, j];
        matrix[r, j] = temp;
        return matrix;
    }
}
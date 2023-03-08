public class SquareHealthCheck
{
    public static bool Check(int n, int[,] magicSquare)
    {
        int formulaSum = n * (n * n + 1) / 2;
        int actualSum = 0;
        for (int j = 0; j < n; j++)
        {
            actualSum += magicSquare[1, j];
        }
        if (formulaSum == actualSum)
            return true;

        return false;
    }
}
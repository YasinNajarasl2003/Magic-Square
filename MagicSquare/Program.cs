using System.Diagnostics;


while (true)
{
    Console.Write("enter the length of square( n > 2 )(zero to exit): ");
    try
    {
        int n = int.Parse(Console.ReadLine());
        int[,] magicSqaure;
        if (n == 0)
        {
            break;
        }
        if(n == 1 || n == 2)
        {
            Console.WriteLine("What are you diong man :|");
            continue;
        }
        Stopwatch stopwatch = Stopwatch.StartNew();
        if (n % 4 == 0)
        {
            magicSqaure = SquareCalculator.DoublyEvenSquareGenerator(n);
            if (SquareHealthCheck.Check(n, magicSqaure))
                SquarePrinter.PrintSquare(magicSqaure, n);
            else
                Console.WriteLine("Failed");
        }
        else if (n % 4 == 2)
        {
            magicSqaure = SquareCalculator.SinglyEvenSquareGenerator(n);
            if(SquareHealthCheck.Check(n,magicSqaure))
                SquarePrinter.PrintSquare(magicSqaure,n);
            else
                Console.WriteLine("Failed");
        }
        else if (n % 2 != 0)
        {
            magicSqaure = SquareCalculator.OddSquareGenerator(n);
            if (SquareHealthCheck.Check(n, magicSqaure))
                SquarePrinter.PrintSquare(magicSqaure, n);
            else
                Console.WriteLine("Failed");
        }
        else
        {
            Console.WriteLine("Not Prodicted for this situation");
        }
        stopwatch.Stop();
        Console.WriteLine($"Calculation Time: {stopwatch.ElapsedMilliseconds} Milli seconds");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

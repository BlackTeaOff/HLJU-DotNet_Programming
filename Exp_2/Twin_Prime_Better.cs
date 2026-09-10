class Twin_Prime_Better
{
    static bool[] PrimeRange(int n, bool[] range)
    {
        for (int i = 2; i <= n; i++)
        {
            range[i] = true;
        }

        for (int i = 2; i <= n; i++)
        {
            if (range[i] == false)
            {
                continue;
            }
            for (int j = 2; i * j <= n; j++)
            {
                range[i * j] = false;
            }
        }
        return range;
    }

    public static void Main()
    {
        Console.Write("请输入范围上限 n : ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        bool[] range = new bool[n + 1];
        PrimeRange(n, range);
        int count = 0;
        for (int i = 3; i + 2 <= n; i += 2)
        {
            if (range[i] && range[i + 2])
            {
                Console.Write($"[{i}, {i + 2}] ");
                count++;
                if (count == 5)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
        }
        /*
        for (int i = 0; i <= n; i++)
        {
            Console.WriteLine($"数字 {i} {(range[i] == true ? "是" : "不是")} 素数");
        }
        */
    }
}
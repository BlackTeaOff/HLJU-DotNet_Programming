class Twin_Prime
{
    static bool IsPrime(int num)
    {
        if (num == 1) return false;
        if (num == 2) return true;
        // 偶数(除了2)不是素数, 因为能被自身和2整除
        if (num % 2 == 0) return false;

        // 它的质数不会超过自己的平方根
        double range = Math.Sqrt(num);

        for (int i = 3; i <= range; i += 2)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static void Main()
    {
        Console.Write("请输入范围上限 n : ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        int count = 0;
        for (int i = 3; i + 2 <= n; i += 2)
        {
            if (IsPrime(i) && IsPrime(i + 2))
            {
                Console.Write($"[{i}, {i + 2}] ");
                count++;

                if (count == 5)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            /*
            if (count == 5)
            {
                Console.WriteLine();
                count = 0;
            }
            */
        }
        /*
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"数字 {i} {(IsPrime(i) == true ? "是" : "不是")} 素数");
        }
        */
    }
}
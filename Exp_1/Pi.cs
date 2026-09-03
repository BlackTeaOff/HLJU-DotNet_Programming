// 4 * (1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11......)
// ??: 左面为空, 用右面的代替
class Pi
{
    public static void pi()
    {
        Console.Write("请输入要迭代的次数: ");
        int count = int.Parse(Console.ReadLine() ?? "0");
        double sum = 0;
        int sign = 1; // 初始符号为正
        for (int i = 0; i < count; i++)
        {
            // 分母 (奇数)
            int denominator = i * 2 + 1;
            sum += sign * (1.0 / denominator);
            sign = -sign;
        }
        Console.WriteLine($"{4 * sum}");
    }

    public static void Main()
    {
        Console.Write("请输入迭代精度 n : ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        double precision = Math.Pow(10, -n); 
        double sum = 0;
        int sign = 1;
        int count = 0;
        // 本轮要加/减的值
        double add;
        do
        {
            int denominator = count * 2 + 1;
            add = 1.0 / denominator;
            sum += sign * add;
            sign = -sign;
            count++;
        } while (add > precision);
        Console.WriteLine($"迭代次数: {count}");
        Console.WriteLine($"最终结果: {(sum * 4).ToString("F" + n)}");
    }
}

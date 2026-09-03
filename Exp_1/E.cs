// 1/0! + 1/1! + 1/2! + 1/3! + 1/4!......
class E
{
    public static void e()
    {
        Console.Write("请输入迭代次数: ");
        int count = int.Parse(Console.ReadLine() ?? "0");
        // 当前的 1 / 阶乘
        double num = 1;
        // 初始为第零项 1 / 0的阶乘
        double result = 1;
        // 从第一项开始计算
        for (int i = 1; i <= count; i++)
        {
            num /= i; // num *= 1 / i
            result += num;
        }
        Console.WriteLine($"{result}");
    }

    public static void Main()
    {
        Console.Write("请输入迭代精度 n: ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        double precision = Math.Pow(10, -n);
        double num = 1;
        double result = 1;
        int count = 0;
        // num 是每次加的数, 它如果小于要求的精度就可以了
        // 因为前面的位数都不会变化了，所以 result 前面不会再变的地方就是精确的
        while (num > precision)
        {
            count++;
            num /= count;
            result += num;
        }
        Console.WriteLine($"迭代次数: {count}");
        // 保留 n 位
        Console.WriteLine($"最终结果: {result.ToString("F" + n)}");
    }
}
// 每一个数 = 他前面两个数的和
class Fibonacci
{
    public static void Main()
    {
        Console.Write("请输入项数n: ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }
        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }
        int a = 0; // 前前项
        int b = 1; // 前一项
        for (int i = 2; i <= n; i++)
        {
            // 第 i 项 c
            int c = a + b;
            a = b;
            b = c;
        }
        Console.WriteLine($"{b}");
    }
}
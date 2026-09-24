abstract class User
{
    public string Name { get; set; }

    public abstract decimal DiscountRate { get; }

    public User(string name)
    {
        Name = name;
    }
}

class Teacher : User
{
    public int TeacherId { get; set; }

    public override decimal DiscountRate => 0.9m; 

    public Teacher(string name, int teacherId) : base(name)
    {
        TeacherId = teacherId;
    }
}

class Student : User
{
    public int StudentId { get; set; }

    public override decimal DiscountRate => 0.8m;

    /*
    public override decimal DiscountRate
    {
        get
        {
            return 0.8m;
        }
    }
    */

    public Student(string name, int studentId) : base(name)
    {
        StudentId = studentId;
    }
}

class Visitor : User
{
    public override decimal DiscountRate => 1.0m;

    public Visitor(string name) : base(name) {}    
}

class CampusCard : IPayable
{
    string CardNumber { get; set; }
    decimal Balance { get; set; }

    public CampusCard(string cardNumber, decimal balance)
    {
        CardNumber = cardNumber;
        Balance = balance;
    }

    public bool Pay(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"[Pay] 校园卡 {CardNumber} 扣款 {amount} 元, 卡内剩余 {Balance} 元");
            return true;
        }
        Console.WriteLine($"[Pay] 校园卡 {CardNumber} 扣款失败: 余额不足。(当前余额 {Balance} 元, 需支付 {amount} 元)");
        return false;
    }
}

class BankCard : IPayable
{
    string CardNumber { get; set; }
    decimal Balance { get; set; }

    public BankCard(string cardNumber, decimal balance)
    {
        CardNumber = cardNumber;
        Balance = balance;
    }

    public bool Pay(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"[Pay] 银行卡 {CardNumber} 扣款 {amount} 元, 卡内剩余 {Balance} 元");
            return true;
        }
        Console.WriteLine($"[Pay] 银行卡 {CardNumber} 扣款失败: 余额不足。(当前余额 {Balance} 元, 需支付 {amount} 元)");
        return false;
    }
}

class Dish
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Dish(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

interface IPayable
{
    bool Pay(decimal amount);
}

class CanteenWindow
{
    public string Name { get; set; }

    public List<Dish> Menu { get; private set; }

    public CanteenWindow(string name)
    {
        Name = name;
        Menu = new List<Dish>();
    }

    public void AddDish(Dish dish)
    {
        Menu.Add(dish);
    }

    public void Order(User user, int[] dishIndexes, IPayable payment)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine($"顾客: {user.Name} (折扣: {user.DiscountRate * 10})");

        List<Dish> dishes = new List<Dish>();
        foreach (int index in dishIndexes)
        {
            dishes.Add(Menu[index]);
        }

        decimal originalTotal = 0;
        Console.WriteLine("所点菜品: ");
        foreach (var dish in dishes)
        {
            Console.WriteLine($"{dish.Name}: {dish.Price} 元");
            originalTotal += dish.Price;
        }
        Console.WriteLine();

        decimal finalAmount = originalTotal * user.DiscountRate;
        Console.WriteLine($"原价: {originalTotal} 元, 折后价: {finalAmount} 元");

        bool paySuccess = payment.Pay(finalAmount);

        if (paySuccess)
        {
            Console.WriteLine("支付成功！");
        }
        else
        {
            Console.WriteLine("支付未完成。");
        }
        Console.WriteLine("------------------------------");
    }

    public void ShowMenu()
    {
        Console.WriteLine("[菜单]");
        for (int i = 0; i < Menu.Count; i++)
        {
            Console.WriteLine($"编号{i}: {Menu[i].Name} - {Menu[i].Price} 元");
        }
    }
}

class Program
{
    public static void Main()
    {
        CanteenWindow window = new CanteenWindow("test");

        window.AddDish(new Dish("红烧肉", 15m));
        window.AddDish(new Dish("麻婆豆腐", 10m));
        window.AddDish(new Dish("番茄炒蛋", 8m));
        window.AddDish(new Dish("白米饭", 2m));

        window.ShowMenu();

        User[] users = new User[]
        {
            new Teacher("张老师", 20246666),
            new Student("刘同学", 20245109),
            new Student("李同学", 20245102),
            new Teacher("王教授", 20000001),
            new Student("赵同学", 20265103),
            new Visitor("访客陈先生"),
            new Student("钱同学", 20221011),
            new Teacher("孙老师", 20181234),
            new Student("周同学", 20251221),
            new Visitor("访客邱女士")
        };

        IPayable[] payment = new IPayable[]
        {
            new CampusCard("C001", 50m),
            new CampusCard("C002", 40m),
            new CampusCard("C003", 30m),
            new CampusCard("C004", 100m),
            new CampusCard("C005", 25m),
            new BankCard("B001", 200m),
            new CampusCard("C006", 60m),
            new CampusCard("C007", 80m),
            new CampusCard("C008", 5m),
            new BankCard("B002", 150m),
        };

        int[][] lunchOrders = new int[][]
        {
            new int[] {0, 1, 3},
            new int[] {1, 2, 3},
            new int[] {0, 2, 3},
            new int[] {0, 1, 2, 3},
            new int[] {1, 3},
            new int[] {0, 0, 3, 3},
            new int[] {2, 3},
            new int[] {0, 3},
            new int[] {0, 1, 3},
            new int[] {2, 2, 3},
        };

        for (int i = 0; i < 10; i++)
        {
            window.Order(users[i], lunchOrders[i], payment[i]);
        }
        /*
        User teacher1 = new Teacher("张老师", 20246666);
        IPayable campusCard1 = new CampusCard("C001", 31.5m);
        int[] zhangLunch = new int[] { 0, 1, 2 };
        window.Order(teacher1, zhangLunch, campusCard1);

        User student1 = new Student("刘同学", 20245109);
        IPayable campusCard2 = new CampusCard("C002", 40m);
        int[] liuLunch = new int[] { 2, 2, 3 };
        window.Order(student1, liuLunch, campusCard2);

        User visitor1 = new Visitor("张三");
        IPayable bankCard1 = new BankCard("B001", 100m);
        int[] zhangSanLaunch = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3 };
        window.Order(visitor1, zhangSanLaunch, bankCard1);
        /*
        Teacher teacher1 = new Teacher("test", 1);
        Student student1 = new Student("test2", 1);
        System.Console.WriteLine(teacher1.Name);
        System.Console.WriteLine(student1.Name);
        System.Console.WriteLine(teacher1.TeacherId);

        User teacher2 = new Teacher("test3", 2);
        User student2 = new Student("test4", 2);
        System.Console.WriteLine(teacher2.Name);
        */
    }
}
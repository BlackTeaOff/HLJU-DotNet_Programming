public interface ICarryPassengers
{
    void Board();
    void Alight();
}

public interface ICarryGoods
{
    void Load();
    void Unload();
}

abstract class Vehicle
{
    protected String name;

    public Vehicle(String name)
    {
        this.name = name;
    }
}

abstract class Car : Vehicle
{
    public Car(String name) : base(name)
    {

    }
}

abstract class Train : Vehicle
{
    public Train(String name) : base(name)
    {

    }
}

class PassengerTrain : Train, ICarryPassengers
{
    public PassengerTrain(String name) : base(name)
    {

    }

    public void Board()
    {
        Console.WriteLine($"{name}: 载人火车上车");
    }

    public void Alight()
    {
        Console.WriteLine($"{name}: 载人火车下车");
    }
}

class CargoTrain : Train, ICarryGoods
{
    public CargoTrain(String name) : base(name)
    {

    }

    public void Load()
    {
        Console.WriteLine($"{name}: 载货火车装货");
    }

    public void Unload()
    {
        Console.WriteLine($"{name}: 载货火车卸货");
    }
}

class PassengerCar : Car, ICarryPassengers
{
    public PassengerCar(String name) : base(name)
    {

    }

    public void Board()
    {
        Console.WriteLine($"{name}: 载人汽车上车");
    }

    public void Alight()
    {
        Console.WriteLine($"{name}: 载人汽车下车");
    }
}

class CargoCar : Car, ICarryGoods
{
    public CargoCar(String name) : base(name)
    {

    }

    public void Load()
    {
        Console.WriteLine($"{name}: 载货汽车装货");
    }

    public void Unload()
    {
        Console.WriteLine($"{name}: 载货汽车卸货");
    }
}

class Test
{
    public static void Main()
    {
        PassengerTrain pTrain = new PassengerTrain("载人火车");
        CargoTrain cTrain = new CargoTrain("载货火车");
        PassengerCar pCar = new PassengerCar("载人汽车");
        CargoCar cCar = new CargoCar("载货汽车");

        ICarryPassengers p = pTrain;
        p.Board();
        p.Alight();

        p = pCar;
        p.Board();
        p.Alight();


        ICarryGoods g = cTrain;
        g.Load();
        g.Unload();

        g = cCar;
        g.Load();
        g.Unload();
    }
}

/*
class Coach : Car, ICarryPassengers
{
    public void Board()
    {
        Console.WriteLine("客车载人上车");
    }

    public void Alight()
    {
        Console.WriteLine("客车载人下车");
    }
}

class Sedan : Car, ICarryPassengers
{
    public void Board()
    {
        Console.WriteLine("轿车载人上车");
    }

    public void Alight()
    {
        Console.WriteLine("轿车载人下车");
    }
}

class Truck : Car, ICarryGoods
{
    virtual public void Load()
    {
        Console.WriteLine("卡车装货");
    }

    virtual public void Unload()
    {
        Console.WriteLine("卡车卸货");
    }
}

class Micro_Truck : Truck, ICarryGoods
{
    override public void Load()
    {
        Console.WriteLine("火车装货");
    }

    override public void Unload()
    {
        Console.WriteLine("火车卸货");
    }
}

class Test
{
    public static void Main()
    {

    }
}
*/
internal class Program
{
    private static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            string madel = input[0];
            int engine_speed = int.Parse(input[1]);
            int engine_power = int.Parse(input[2]);
            Engine engine = new Engine(engine_speed, engine_power);

            int cargoWeight = int.Parse(input[3]);
            string cargo_type = input[4];
            Cargo cargo = new Cargo(cargoWeight, cargo_type);

            double[] tireInfo = input.Skip(5).Select(double.Parse).ToArray();
            Tire[] tires = new Tire[4];

            for (int j = 0; j < 4; j++)
            {
                double pressure = tireInfo[j * 2];
                int age = (int)tireInfo[j * 2 + 1];
                tires[j] = new Tire(pressure, age);
            }
            Car car = new Car(madel, engine, cargo, tires);
            cars.Add(car);
        }
        string commands = Console.ReadLine();
        if (commands == "fragile")
        {
            fragile(cars);
        }
        else if (commands == "flamable")
        {
            flamable(cars);
        }
    }
    public static void fragile(List<Car> cars)
    {
        for (int i = 0; i < cars.Count; i++)
        {
            if (cars[i].Cargo.Type == "fragile")
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cars[i].Tire[j].Pressure < 1)
                    {
                        Console.WriteLine(cars[i].Model);
                        break;
                    }
                }
            }
            else { break; }
        }
    }
    public static void flamable(List<Car> cars)
    {
        for (int i = 0; i < cars.Count; i++)
        {
            if (cars[i].Cargo.Type == "flamable" && cars[i].Engine.Power > 250)
            {
                Console.WriteLine(cars[i].Model);
            }
        }
    }
}
class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public Tire[] Tire { get; set; }

    public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tire = tire;
    }
}
class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }
    public Engine(int speed, int power)
    {
        Speed = speed;
        Power = power;
    }
}
class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }
    public Cargo(int weight, string type)
    {
        Weight = weight;
        Type = type;
    }
}
class Tire
{
    public double Pressure { get; set; }
    public int Age { get; set; }
    public Tire(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}
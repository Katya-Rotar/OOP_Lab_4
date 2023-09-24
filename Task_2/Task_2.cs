internal class Program
{
    private static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();
        // Engine
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model_engine = input[0];
            int power = int.Parse(input[1]);
            int displacement = input.Length > 2 ? int.Parse(input[2]) : 0;
            string efficiency = input.Length > 3 ? input[3] : "n/a";
            Engine engine = new Engine(model_engine, power, displacement, efficiency);
            engines.Add(engine);
        }
        Console.Write("M = ");
        int M = int.Parse(Console.ReadLine());
        //Car
        for (int i = 0; i < M; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model_car = input[0];
            string engine = input[1];
            string weight = input.Length > 2 && input[2].Length < 5 ? input[2] : "n/a";
            string color = input.Length > 3 ? input[3] : "n/a";

            Engine engine1 = new Engine();
            for (int j = 0; j < engines.Count; j++)
            {
                if (engine == engines[j].ModelEngine)
                {
                    engine1 = new Engine(engines[j].ModelEngine, engines[j].Power, engines[j].Displacement, engines[j].Efficiency);
                }
            }
            Car car = new Car(model_car, engine1, weight, color);
            cars.Add(car);
        }
        for (int i = 0; i < cars.Count; i++)
        {
            Console.WriteLine(cars[i]);
        }
    }
}
class Car
{
    public string ModelCar { get; set; }
    public Engine engine { get; set; }
    public string Weight { get; set; } //
    public string Color { get; set; } //
    public Car(string modelCar, Engine engine, string weight, string color)
    {
        ModelCar = modelCar;
        this.engine = engine;
        Weight = weight;
        Color = color;
    }
    public Car()
    {
        ModelCar = "n/a";
        engine = null;
        Weight = "n/a";
        Color = "n/a";
    }
    public override string ToString()
    {
        string engineInfo = (engine != null) ? engine.ToString() : "Engine: n/a";
        return $"{ModelCar}:\n{engineInfo}\nWeight: {Weight}\nColor: {Color}";
    }
}
class Engine
{
    public string ModelEngine { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; } //
    public string Efficiency { get; set; } //
    public Engine(string modelEngine, int power, int displacement, string efficiency)
    {
        this.ModelEngine = modelEngine;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }
    public Engine() {
        ModelEngine = "n/a";
        Power = 0;
        Displacement = 0;
        Efficiency = "n/a";
    }
    public override string ToString()
    {
        string result = $"{ModelEngine}:\nPower: {Power}\n";
        result += (Displacement != 0) ? $"Displacement: {Displacement}" : "Displacement: n/a";
        return result + $"\nEfficiency: {Efficiency}";
    }
}
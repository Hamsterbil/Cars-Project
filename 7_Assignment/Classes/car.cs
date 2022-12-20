class Car
{
    #region Fields
    public int CurrentGear = 0;
    public float _speed = 0f;
    internal int _revolutions = 0;
    public string Brand;
    public string Color;
    public int TireSize;
    public int EnginePower;
    public int LightStrength;
    public double Price;
    public int ID;
    public bool Bought;
    public bool isInside;

    Random RNG = new Random();
    public List<Door> Doors = new List<Door>();
    public List<Tire> Tires = new List<Tire>();
    public List<Light> Lights = new List<Light>();
    public List<Engine> Engine = new List<Engine>();
    #endregion

    #region Constructors
    public Car(string brandParamater, string colorParameter, double price, int amountOfDoors, int amountOfTires, int tireSize, int enginePower, int lightStrength, int Id, bool bought)
    {
        this.Brand = brandParamater;
        this.Color = colorParameter;
        this.TireSize = tireSize;
        this.EnginePower = enginePower;
        this.LightStrength = lightStrength;
        this.Price = price;
        this.Bought = bought;
        this.ID = Id;
        this.Tires = new List<Tire>();
        this.Doors = new List<Door>();
        this.Lights = new List<Light>();
        this.Engine.Add(new Engine(0));

        for (int x = 0; x < 4; x++)
        {
            this.Doors.Add(new Door());
            this.Tires.Add(new Tire(10));
            this.Lights.Add(new Light(10));
        }
    }
    #endregion

    #region Methods
    public void Drive()
    {
        _speed = _speed + RNG.Next(1, 5);
    }

    public void Brake()
    {
        _speed = 0f;
    }

    public void Accelerate(float forceParameter)
    {
        _speed = _speed + forceParameter;
    }

    public int ChangeGear(int amount)
    {
        CurrentGear += amount;
        return CurrentGear;
    }

    public void GetIn(Door doorParameter)
    {
        isInside = true;
        doorParameter.Open();
        Console.WriteLine("Got inside " + Brand);
        doorParameter.Close();
    }

    public void GetOut(Door doorParameter)
    {
        isInside = false;
        doorParameter.Open();
        Console.WriteLine("Got out of " + Brand);
        doorParameter.Close();
    }

    public void data()
    {
        Console.WriteLine(
        "Car Brand: " + Brand +
        "\nCar Color: " + Color +
        "\nDoors: " + Doors.Count +
        "\nTires: " + Tires.Count +
        "\nTire Size: " + TireSize +
        "\nEngine Power: " + EnginePower +
        "\nLight Strength: " + LightStrength +
        "\nPrice: $" + Price + "\n");
    }
    #endregion
}
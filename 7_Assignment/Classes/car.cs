class Car
{
    #region Fields

    public string Brand = "";
    protected int CurrentGear = 0;
    private float _speed = 0f;
    internal int _revolutions = 0;

    public List<Door> Doors;
    public List<Tire> Tires;
    public List<Light> Lights;

    #endregion

    #region Constructors

    public Car(string brandParamater) {
        this.Brand = brandParamater;
        this.Tires = new List<Tire>();
        this.Doors = new List<Door>();
        this.Lights = new List<Light>();
        Door door1 = new Door();
        this.Doors.Add(door1);
        this.Doors.Add(new Door());

        for (int i = 0; i < 4; i++) {
            this.Tires.Add(new Tire(10));
            this.Lights.Add(new Light(10));
        }
        this.GetIn(this.Doors[0]);
        Console.WriteLine("Car constructed / Instantiated");
    }

    public Car(
        string brandParamater,
        int amountOfDoors,
        int amountOfTires,
        int tireSize,
        string rimMaterial
    ) {
        //Try to fill out the overloaded constructor
        Console.WriteLine("Car constructed / Instantiated");
    }
        public Car(string brandParamater, int amountOfDoors, int amountOfTires, int tireSize, string rimMaterial, int engineSize, int enginePower)

            //Try to fill out the overloaded constructor
            Console.WriteLine("Car constructed / Instantiated");
        }

        #endregion

    void Brake() {
        _speed = 0f;
    }

    public void Accelerate(float forceParameter) {
        _speed = _speed + forceParameter;
    }

    public void Turbo(float forceParameter) {
        _speed = _speed * forceParameter;
    }

    public int ChangeGear(int amount) {
        CurrentGear += amount;
        return CurrentGear;
    }

    private void GetIn(Door doorParameter) {
        doorParameter.Open();
        Console.WriteLine("Got inside " + Brand);
        doorParameter.Close();
    }

    private void GetOut(Door doorParameter) {
        doorParameter.Open();
        Console.WriteLine("Got out of " + Brand);
        doorParameter.Close();
    }

    #endregion
}

        #endregion
    }

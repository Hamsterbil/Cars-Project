class Car
{
    #region Fields -------------------------------------------

    public string Brand;
    protected int CurrentGear = 0;
    private float _speed = 0f;
    internal int _revolutions = 0;

    public List<Door> Doors;
    public List<Tire> Tires;

    #endregion

    #region Constructors ---------------------------------------

    public Car(string brandParamater)
    {
        Doors = new List<Door>();
        for(int i = 0; i < 4; i++) {
            Doors.Add(new Door(false));
        }

        this.Brand = brandParamater;
        this.Tires = new List<Tire>();
        
        for (int i = 0; i < 4; i++)
        {
            this.Tires.Add(new Tire(10));
        }
        this.GetIn(this.Doors[0]);
        Console.WriteLine("Car constructed / Instantiated");
    }

    public Car(string brandParamater, int amountOfDoors, int amountOfTires, int tireSize)
    {
        //Try to fill out the overloaded constructor
        Console.WriteLine("Car constructed / Instantiated");
    }

    #endregion

    #region Methods -----------------------------------------

    void Brake()
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

    private void GetIn(Door doorParameter)
    {
        doorParameter.Open();
        Console.WriteLine("Got inside " + Brand);
        doorParameter.Close();
    }

    public void Drive() { 

    }

    #endregion
}

class Car
{
    #region Fields


    protected int CurrentGear = 0;
    private float _speed = 0f;
    internal int _revolutions = 0;
    public string Brand;
    public string Color;
    public string Price;
    public List<Door> Doors = new List<Door>();
    public List<Tire> Tires = new List<Tire>();
    public List<Light> Lights = new List<Light>();
    public List<Engine> Engine = new List<Engine>();   



    #endregion

    #region Constructors

//Få det hele i Dealer. En bil har døre, lys, dæk. Ikke en liste. Det har dealeren.
//Refactor koden.
    public Car(string brandParamater, string colorParameter) {
                this.Brand = brandParamater;
                this.Color = colorParameter;

                int x = 0;
                for (x = 0; x < 4; x++) {
                this.Doors.Add(new Door());
                this.Tires.Add(new Tire(10));
                this.Lights.Add(new Light(10));
            }
        }

    

        //this.GetIn(this.Doors[0]);
        //Console.WriteLine("Car constructed / Instantiated");




    public Car(string brandParamater, string colorParameter,string price, int amountOfDoors, int amountOfTires, int tireSize, int enginePower) {
                this.Brand = brandParamater;
                this.Color = colorParameter;
                this.Price = price;
                this.Tires = new List<Tire>();
                this.Doors = new List<Door>();
                this.Lights = new List<Light>();
                this.Engine.Add(new Engine(10));

                int x = 0;
                for (x = 0; x < 4; x++) {
                this.Doors.Add(new Door());
                this.Tires.Add(new Tire(10));
                this.Lights.Add(new Light(10));
            }
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

    public void data() { 
        Console.WriteLine(
        "\nCar Brand: " + Brand +
        "\nCar Color: " + Color +
        "\nDoors: " + Doors.Count + 
        "\nTires: " + Tires.Count +
        "\nTire Size: " + Tires[0].Size +
        "\nLight Power: " + Lights[0].strength +
        "\nEngine Power: " + Engine[0].Power +
        "\nPrice: $" + Price + "\n\n");
        
    }

}
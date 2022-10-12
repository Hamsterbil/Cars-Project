/*
* Todays work will be refactoring the Car, Door and Tire class into seperate files
* and laying the ground work for the next assignment
*/

//Instantiating a Car class / Creating an object of type Car
Car car1 = new Car("BMW");
Car car2 = new Car("Toyota", 2, 8, 25);

Console.ReadKey();

//Class definition
class Car{
    #region Fields
    
    public string Brand = ""; 
    protected int CurrentGear = 0;
    private float _speed = 0f;
    internal int _revolutions = 0;
    
    public List<Door> Doors;
    public List<Tire> Tires;

    #endregion

    #region Constructors

    public Car(string brandParamater){
        this.Brand = brandParamater;
        this.Tires = new List<Tire>();
        this.Doors = new List<Door>();
        Door door1 = new Door();
        this.Doors.Add(door1);
        this.Doors.Add(new Door());

        for(int i = 0; i < 4; i++){
            this.Tires.Add(new Tire(10));
        }
        this.GetIn(this.Doors[0]);
        Console.WriteLine("Car constructed / Instantiated");
    }

    public Car(string brandParamater, int amountOfDoors, int amountOfTires, int tireSize){
        //Try to fill out the overloaded constructor
        Console.WriteLine("Car constructed / Instantiated");
    }

    #endregion

    #region Methods
    
    void Break(){
        _speed = 0f;
    }

    public void Accelerate(float forceParameter){
        _speed = _speed + forceParameter;
    }
    
    public int ChangeGear(int amount){
        CurrentGear += amount;
        return CurrentGear;
    }

    private void GetIn(Door doorParameter){
        doorParameter.Open();
        Console.WriteLine("Got inside " + Brand);
        doorParameter.Close();
    }

    #endregion
}

#region Door and Tire Classes

class Door{

    private bool IsOpen;

    public Door(){
        this.IsOpen = false;
    }

    public void Open(){
        if(this.IsOpen == true){
            Console.WriteLine("Door already open");
        }else{
            Console.WriteLine("Door opened");
            this.IsOpen = true;
        }
    }

    public void Close(){
        if(this.IsOpen == false){
            Console.WriteLine("Door already is close");
        }else{
            Console.WriteLine("Door closed");
            this.IsOpen = false;
        }
    }
}

class Tire{
    public int Size = 0;
    public Tire(int size = 10){
        this.Size = size;
    }
}

#endregion


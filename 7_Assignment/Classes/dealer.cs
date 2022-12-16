class Dealer
{
    private static readonly Person player = new Person();
    public List<Car> randomCars = new List<Car>();   

    public static List<string> CarBrands = new List<string>() {
            "Volvo", "Volkswagen", "Toyota", "Ford", "Mercedes",
            "BMW", "Audi", "Kia", "Renault", "Peugeot"
        };
    public static List<string> CarColors = new List<string>() {
            "Yellow", "Black", "Silver", "Gold", "Red",
            "Blue", "White", "Orange", "Green"
        };            

    double price;
    public int i = 0; 

    public void showCars(int i, bool showList)
    {        
        Random RNG = new Random();
        int x = randomCars.Count;

        for (i = i + x; x < i; x = randomCars.Count)
        {
            int brandNum = RNG.Next(0, 9);
            int colorNum = RNG.Next(0, 8);
            int tireSize = RNG.Next(1, 10);
            int enginePower = RNG.Next(50, 100);
            int lightStrength = RNG.Next(1, 10);
            int ID = 100 + x;

            price = RNG.Next(10000, 100000);
            price = price % 10000 >= 5000 ? price + 10000 - price % 10000 : price - price % 10000;

            string Brand = CarBrands[brandNum];
            string Color = CarColors[colorNum];
            randomCars.Add(new Car(CarBrands[brandNum], CarColors[colorNum], price, 4, 4, tireSize, enginePower, lightStrength, ID, false));
        }

        if (showList == true)
        {
            for (x = 0; x < randomCars.Count; x++)
            {
                if (randomCars[x].Bought == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(x + 1 + ". Car");
                randomCars[x].data();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------------\n");
            }

        }
    }
    
    public void buy(int x)
    {
        if (randomCars[x].Price > player.money.Amount)
        {
            talkingDealer("\nI'm sorry, but you cannot buy this car");
            player.actions("New cars, Personal, Buy");
        }
        else if (randomCars[x].Bought == true)
        {
            Console.WriteLine("\nYou already own this car");
            player.actions("New cars, Personal, Buy");
        }
        else
        {
            Console.Clear();
            player.personalCars.Add(new Car(
                randomCars[x].Brand,
                randomCars[x].Color,
                randomCars[x].Price,
                4,
                4,
                randomCars[x].TireSize,
                randomCars[x].EnginePower,
                randomCars[x].LightStrength,
                randomCars[x].ID,
                randomCars[x].Bought
            ));

            randomCars[x].Bought = true;            

            showCars(0, true);

            player.money.spendMoney(randomCars[x].Price);
            double reduced = player.personalCars.Last().Price * 0.1;
            player.personalCars.Last().Price = player.personalCars.Last().Price * 0.9;

            Console.WriteLine("You purchased:");
            player.personalCars.Last().data();  

            Console.WriteLine("Price went down by:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("- $" + reduced + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine("Your balance is now: $" + player.money.Amount);
            talkingDealer("\nThank you for your purchase. Would you like to take it for a test drive, or buy something else?\n");
            player.actions("Cars, Personal, Buy, Get in");
        }
    }
    
    public void sell(int x)
    {            
        for (int z = 0; z < randomCars.Count; z++)
        {
            if (randomCars[z].ID == player.personalCars[x].ID)
            {
                randomCars[z].Bought = false;
                player.money.addMoney(player.personalCars[x].Price);
                player.personalCars.RemoveAt(x);
                player.actions("Cars, Personal");
            }
        }
    }
    
    public void customize() //FREDERIK
    {
        /*
        Print personlige biler
        Spørg hvilken bils farve skal ændres, medmindre der er andre ting man kan ændre?
        Print listen med farver
        Person skriver farve, switch statement tager input og ændrer farven til den nye
        Print dataen for den nye bil   
        */
        int x = 0;

        player.personalCars[x].Color = CarColors[0];

        player.personalCars[x].data();
    }
    
    public void talkingDealer(string text)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (char c in text)
        {
            Console.Write(c);
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}
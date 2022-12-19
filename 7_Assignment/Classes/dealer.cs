class Dealer
{
    #region Fields
    //Person calls "int i", because otherwise nothing works. ¯\_(ツ)_/¯
    public int i = 0;
    int x;
    int colorNum;
    double price;
    string input;
    bool loop;
    Random RNG = new Random();
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
    #endregion

    #region Methods
    public void showCars(int i, bool showList)
    {
        x = randomCars.Count;

        for (i = i + x; x < i; x = randomCars.Count)
        {
            int brandNum = RNG.Next(0, 9);
            int colorNum = RNG.Next(0, 8);
            int tireSize = RNG.Next(1, 10);
            int enginePower = RNG.Next(50, 100);
            int lightStrength = RNG.Next(1, 10);
            int ID = 100 + x;

            string Brand = CarBrands[brandNum];
            string Color = CarColors[colorNum];

            price = RNG.Next(10000, 100000);
            price = price % 10000 >= 5000 ? price + 10000 - price % 10000 : price - price % 10000;

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
                Console.WriteLine(x + 1 + ". Car\n");
                randomCars[x].data();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------------\n");
            }
        }
    }

    public void buy(int x)
    {
        if (randomCars[x].Bought == true)
        {
            Console.WriteLine("\nYou already own this car");
            player.actions("New cars, Personal, Buy");
        }
        else if (randomCars[x].Price > player.money.Amount)
        {
            talkingDealer("\nI'm sorry, but you cannot buy this car");
            player.actions("New cars, Personal, Buy");
        }
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
        player.actions("Cars, Personal, Buy, Customize, Get in");
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

    public void customize(int x)
    {
        colorNum = 0;
        loop = true;
        Console.Clear();
        player.personalCars[x].data();
        talkingDealer("It costs $1000 to change car color\n");
        if (player.money.Amount < 1000)
        {
            talkingDealer("Im sorry, but ya broke");
            player.actions("Cars, Personal, Sell, Customize, Get in");
        }
        talkingDealer("Choose your color.\n");
        for (int i = 0; i < CarColors.Count; i++)
        {
            Console.WriteLine(CarColors[i]);
        }
        Console.Write("\n");
        input = Console.ReadLine().ToLower();
        while (loop)
        {
            for (int l = 0; l <= CarColors.Count && loop; l++)
            {
                if (l == CarColors.Count && input.ToLower() != CarColors[8].ToLower())
                {
                    player.actions("Cars, Personal, Sell, Customize, Get in");
                }
                else if (input.ToLower() == CarColors[l].ToLower())
                {
                    if (player.personalCars[x].Color == CarColors[l])
                    {
                        talkingDealer("\nBut your car is already " + CarColors[l].ToLower());
                        player.actions("Cars, Personal, Sell, Customize, Get in");
                    }
                    colorNum = l;
                    loop = false;
                }
            }
        }
        for (int z = 0; z < randomCars.Count; z++)
        {
            if (randomCars[z].ID == player.personalCars[x].ID)
            {
                randomCars[z].Color = CarColors[colorNum];
            }
        }
        player.money.spendMoney(1000);
        player.personalCars[x].Color = CarColors[colorNum];
        player.personalCars[x].data();
        player.actions("Cars, Personal, Sell, Customize, Get in");
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
    #endregion
}
public class Dealer
{
    List<Car> randomCars = new List<Car>();
    List<Car> personalCars = new List<Car>();
    Person player = new Person();
    int price;

    public void showCars(int i, bool showList)
    {
        Random RNG = new Random();
        int x = randomCars.Count;

        for (i = i + x; x < i; x = randomCars.Count)
        {
            int brandNum = RNG.Next(0, 9);
            int colorNum = RNG.Next(0, 8);

            price = RNG.Next(10000, 100000);
            price = price % 10000 >= 5000 ? price + 10000 - price % 10000 : price - price % 10000;

            string Brand = CarBrands[brandNum];
            string Color = CarColors[colorNum];
            randomCars.Add(new Car(CarBrands[brandNum], CarColors[colorNum], price, 4, 4, 0, 0, false));
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
    Credit money = new Credit(100000);

    public void buy(int x)
    {
        if (randomCars[x].Price > money.Amount)
        {
            talkingDealer("I'm sorry, but you cannot buy this car");
        }

        else
        {
            Console.Clear();
            personalCars.Add(randomCars[x]);
            randomCars[x].Bought = true;
            showCars(0, true);
            money.spendMoney(randomCars[x].Price);
            Console.WriteLine("You purchased:");
            personalCars[0].Bought = false;
            personalCars[0].data();
            Console.WriteLine("Your balance is now: $" + money.Amount);
            talkingDealer("\nThank you for your purchase. Would you like to take it for a test drive, or buy something else?\n");
            player.actions("Cars, Personal, Getin, Exit");
        }
    }

    public void sell()
    {

    }

    public void customize()
    {

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

    public static List<string> CarBrands = new List<string>() {
            "Volvo", "Volkswagen", "Toyota", "Ford", "Mercedes",
            "BMW", "Audi", "Kia", "Renault", "Peugeot"
        };

    public static List<string> CarColors = new List<string>() {
            "Yellow", "Black", "Silver", "Gold", "Red",
            "Blue", "White", "Orange", "Green"
        };
}
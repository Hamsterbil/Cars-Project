class Person
{
    private static readonly Dealer dealer = new Dealer();
    public static Dealer Dealer
    {
        get 
        {
            return dealer; 
        }
    }
    public List<Car> personalCars = new List<Car>();
    public Credit money = new Credit();
    int i;


    //THIS ORDER
    //Cars, New Cars, Personal, Buy, Sell, Customize, Get in, Drive, Change Gear, Accelerate, Turbo, Brake, Get out, Exit
    public void actions(string usedActions)
    {
        Console.WriteLine("\nWrite an action: [" + usedActions + ", Exit]");
        string input = Console.ReadLine();
        switch (input)
        {
            case "Cars":
                Console.Clear();
                if (dealer.i == 0)
                {
                    dealer.showCars(5, true);
                    dealer.i++; 
                }
                else
                {
                    dealer.showCars(0, true);
                }
                money.bal();
                dealer.talkingDealer("\nWould you like to purchase any of these cars?");
                actions("New Cars, Personal, Buy, Sell");
                break;

            case "New Cars":
                Console.Clear();
                dealer.randomCars.Clear();
                dealer.showCars(5, true);
                dealer.talkingDealer("\nWould you like to purchase any of these cars?");
                actions("New Cars, Personal, Buy, Sell");
                break;

            case "Personal":
                Console.Clear();
                money.bal();
                Console.WriteLine("You own these cars:\n");
                for (int i = 0; i < personalCars.Count; i++)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(i + 1 + ". Car");
                    personalCars[i].data();
                }

                actions("Cars, Sell, Getin");
                break;

            case "Buy":
                dealer.talkingDealer("\nPlease select your car:\n");
                dealer.buy(int.Parse(Console.ReadLine()) - 1);
                break;

            case "Sell":
                Console.Clear();
                Console.WriteLine("You own these cars:\n");
                for (int i = 0; i < personalCars.Count; i++)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(i + 1 + ". Car");
                    personalCars[i].data();
                }
                dealer.talkingDealer("Are you sure you would like to sell a car?\n");
                input = Console.ReadLine();
                if (input == "Yes")
                {
                    Console.WriteLine("\nWhat car would you like to sell?");
                    dealer.sell(int.Parse(Console.ReadLine()) - 1);
                    actions("Cars, Personal");
                }
                else
                {
                    actions("Cars, Personal, Sell");
                }    
                break;

            case "Drive":

                break;

            case "Accelerate":

                break;

            case "Get in":

                break;

            case "Get out":

                break;

            case "Exit":
                Console.WriteLine("You exit the car dealer.");
                Console.ReadKey();
                return;

            default:
                return;
        }
    }
}
using System.Diagnostics;
class Person
{
    private static Dealer dealer = new Dealer("Mr White");
    Road road = new Road();    
    public List<Car> personalCars = new List<Car>();

    public int insideCar;
    int i;
    string input;
    bool loop;
    public Credit money = new Credit();

    public Person(string name)
    {
        string Name = name;
    }

    //ACTIONS IN THIS ORDER
    //Cars, New cars, Personal, Buy, Sell, Customize, Get in, Drive, Change gear, Accelerate, Turbo, Brake, Get out
    public void actions(string usedActions, Person player)
    {
        //Loop whenever wrong input
        loop = true;
        while (loop)
        {
            Console.WriteLine("\nWrite an action: [" + usedActions + "]");
            input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "cars": /*
                - Check if cars have been created (only happens once). If not, create and display 5 cars. Otherwise display current cars
                - Display balance
                - Display actions   */
                    Console.Clear();
                    checkIfInsideCar(player);
                    if (dealer.randomCars.Count == 0)
                    {
                        dealer.showCars(5, true, dealer);
                    }
                    else
                    {
                        dealer.showCars(0, true, dealer);
                    }
                    money.bal();
                    dealer.talkingDealer("\nWould you like to purchase any of these cars?", dealer);
                    actions("New Cars, Personal, Buy, Sell", player);
                    break;

                case "new cars": /*
                - Remove all cars in randomCars list
                - Create 5 new cars in the list
                - Display actions   */
                    Console.Clear();
                    checkIfInsideCar(player);
                    dealer.randomCars.Clear();
                    dealer.showCars(5, true, dealer);
                    money.bal();
                    dealer.talkingDealer("\nWould you like to purchase any of these cars?", dealer);
                    actions("New Cars, Personal, Buy, Sell", player);
                    break;

                case "personal": /*
                - Display balance
                - Display currently owned cars, if any are owned
                - Display actions  */
                    Console.Clear();
                    money.bal();
                    if (personalCars.Count > 0)
                    {
                        ownedCars();
                    }
                    else
                    {
                        Console.WriteLine("You do not own any cars.");
                    }
                    actions("Cars, Sell, Customize, Get in", player);
                    break;

                case "buy": /*
                - Checks if any cars exist. If not, loop switch
                - Player chooses car to buy. If player writes anything other than int, loop
                - Display actions   */
                    if (dealer.randomCars.Count > 0)
                    {
                        checkIfInsideCar(player);
                        dealer.talkingDealer("\nPlease select your car: [1 - " + dealer.randomCars.Count + "]\n", dealer);
                        input = Console.ReadLine();
                        if (int.TryParse(input, out i))
                        {
                            if (int.Parse(input) > dealer.randomCars.Count)
                            {
                                Console.WriteLine("That is not a valid number");
                                break;
                            }
                            else if (int.Parse(input) < 1)
                            {
                                Console.WriteLine("That is not a valid number");
                                break;
                            }
                            dealer.buy(int.Parse(input) - 1, player, dealer);
                        }
                    }
                    break;

                case "sell": /*
                - Check if any car is owned
                - If player owns more than one car (to make player choose), sell chosen car. If they write anything other than an int, loops switch again
                - If they own 1 car (chooses automatically), sell
                - Display actions   */
                    Console.Clear();
                    checkIfInsideCar(player);
                    if (personalCars.Count == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        break;
                    }
                    dealer.talkingDealer("Are you sure you would like to sell a car?\n", dealer);
                    input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        if (personalCars.Count > 1)
                        { 
                                ownedCars();
                                dealer.talkingDealer("\nWhat car would you like to sell? [1 - " + personalCars.Count + "]", dealer);
                                input = Console.ReadLine();
                                if (int.TryParse(input, out i))
                                {
                                    if (int.Parse(input) > personalCars.Count)
                                    {
                                        Console.WriteLine("That is not a valid number");
                                        break;
                                    }
                                    else if (int.Parse(input) < 1)
                                    {
                                        Console.WriteLine("That is not a valid number");
                                        break;
                                    }
                                    dealer.sell(int.Parse(input) - 1, player);
                                }
                            }
                        else if (personalCars.Count == 1)
                        {        
                                Console.WriteLine("You sold:");
                                personalCars[0].data();
                                dealer.sell(0, player);
                        }  
                    }
                    break;

                case "customize": /*
                - Check if any car is owned
                - If player owns more than one car (to make player choose), customize chosen car. If they write anything other than an int, loops switch again
                - If they own 1 car (chooses automatically), customize
                - Display actions   */
                    Console.Clear();
                    checkIfInsideCar(player);
                    if (personalCars.Count > 1)
                    {
                        ownedCars();
                        dealer.talkingDealer("\nWhat car would you like to customize? [1 - " + personalCars.Count + "]", dealer);
                        input = Console.ReadLine();
                        if (int.TryParse(input, out i))
                        {
                            if (int.Parse(input) > personalCars.Count)
                            {
                                Console.WriteLine("That is not a valid number");
                                break;
                            }
                            else if (int.Parse(input) < 1)
                            {
                                Console.WriteLine("That is not a valid number");
                                break;
                            }
                            dealer.customize(int.Parse(input) - 1, player, dealer);
                        }
                        break;
                    }
                    else if (personalCars.Count == 1)
                    {
                        dealer.customize(0, player, dealer);
                    }
                    Console.WriteLine("You do not own any cars");
                    break;

                case "get in": /*
                - Check if any car is owned
                - If player owns more than one car (to make player choose), get inside chosen car. If they write anything other than an int, loops switch again
                - If they own 1 car (chooses automatically), get in
                - Display actions   */
                    Console.Clear();
                    if (personalCars.Count > 0)
                    {
                        checkIfInsideCar(player);
                        if (personalCars.Count > 1)
                        {
                            ownedCars();
                            dealer.talkingDealer("Which car would you like to get in? [1 - " + personalCars.Count + "]", dealer);
                            input = Console.ReadLine();
                            if (int.TryParse(input, out i))
                            {
                                if (int.Parse(input) > personalCars.Count)
                                {
                                    Console.WriteLine("That is not a valid number");
                                    break;
                                }
                                else if (int.Parse(input) < 1)
                                {
                                    Console.WriteLine("That is not a valid number");
                                    break;
                                }
                                insideCar = int.Parse(input) - 1;
                                personalCars[insideCar].GetIn(personalCars[insideCar].Doors[0]);
                                actions("Personal, Drive, Get out", player);
                            }
                            break;
                        }
                        else if (personalCars.Count == 1)
                        {
                            personalCars[0].GetIn(personalCars[0].Doors[0]);
                            actions("Personal, Drive, Get out", player);
                        }
                    }
                    Console.WriteLine("You do not own any cars");
                    break;


                case "drive": /*
                - Check if player owns cars
                - Take car for a ride, and add $1000
                - Display actions*/
                    Console.Clear();
                    if (personalCars.Count > 0)
                    {
                        if (personalCars[insideCar].isInside && personalCars.Count > 0)
                        {
                            road.Tick(player);
                            actions("Cars, Personal", player);
                        }
                    }
                    Console.WriteLine("You are not inside any car");
                    break;

                case "get out": /*
                - Check if inside car. If true, get out of car
                - Display actions   */
                    Console.Clear();
                    if (personalCars.Count > 0)
                    {
                        if (personalCars[insideCar].isInside)
                        {
                            personalCars[insideCar].GetOut(personalCars[insideCar].Doors[0]);
                            actions("Cars, Personal, Get in", player);
                        }
                    }
                    Console.WriteLine("You are not inside any car");
                    break;

                case "jesper": //Skriv Jesper før du tjekker ting
                    Console.Clear();
                    Console.WriteLine("Hej Jesper, pls giv os 12+");
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = "chrome.exe";
                    process.StartInfo.Arguments = "\"" + Path.Combine(Directory.GetCurrentDirectory(), @"obj/Debug/brugerfoto.png") + "\"";
                    process.Start();
                    break;

                default:
                    break;
            }
        }
    }
    public void ownedCars()
    {
        Console.WriteLine("You own these cars:\n");
        for (int i = 0; i < personalCars.Count; i++)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(i + 1 + ". Car\n");
            personalCars[i].data();
        }
    }

    public void checkIfInsideCar(Person player)
    {
        if (personalCars.Count > 0)
        {
            if (personalCars[insideCar].isInside == true)
            {
                Console.WriteLine("You are inside a car");
                actions("Personal, Drive, Get out", player);
            }
        }
    }
}
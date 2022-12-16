class Person
{
    private static readonly Dealer dealer = new Dealer();
    public List<Car> personalCars = new List<Car>();
    public int insideCar;
    public Credit money = new Credit();

    //THIS ORDER
    //Cars, New cars, Personal, Buy, Sell, Customize, Get in, Drive, Change gear, Accelerate, Turbo, Brake, Get out, Exit
    public void actions(string usedActions)
    {
        bool loop = true;
        while(loop)
        {
            Console.WriteLine("\nWrite an action: [" + usedActions + ", Exit]");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "cars": //DONE-------------------------------------
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
                    loop = false;
                    break;

                case "new cars": //DONE-------------------------------------
                    Console.Clear();
                    dealer.randomCars.Clear();
                    dealer.showCars(5, true);
                    dealer.talkingDealer("\nWould you like to purchase any of these cars?");
                    actions("New Cars, Personal, Buy, Sell");
                    loop = false;
                    break;

                case "personal": //DONE-------------------------------------
                    Console.Clear();
                    money.bal();
                    Console.WriteLine("You own these cars:\n");
                    for (int i = 0; i < personalCars.Count; i++)
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine(i + 1 + ". Car");
                        personalCars[i].data();
                    }

                    actions("Cars, Sell, Get in");
                    loop = false;
                    break;

                case "buy": //DONE-------------------------------------
                    dealer.talkingDealer("\nPlease select your car:\n");
                    dealer.buy(int.Parse(Console.ReadLine()) - 1);
                    loop = false;
                    break;

                case "sell": //DONE-------------------------------------
                    if (personalCars.Count == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        break;
                    }    
                    else if (personalCars.Count > 1)
                    {       
                        dealer.talkingDealer("Are you sure you would like to sell a car?\n");
                        input = Console.ReadLine();
                        if (input == "Yes")
                        {                       
                            Console.Clear();   
                            Console.WriteLine("You own these cars:\n");
                            for (int i = 0; i < personalCars.Count; i++)
                            {
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine(i + 1 + ". Car");
                                personalCars[i].data();
                            }
                            Console.WriteLine("\nWhat car would you like to sell?");     
                            dealer.sell(int.Parse(Console.ReadLine()) - 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You sold:");
                        personalCars[0].data();
                        dealer.sell(0);
                        actions("Cars, Personal");
                    }
                    loop = false;
                    break;

                case "customize":
                    dealer.customize(int.Parse(Console.ReadLine()));

                    actions("Cars, Personal, Sell, Customize, Get in");
                    loop = false;
                    break;

                case "get in": //DONE-------------------------------------
                    Console.Clear();
                    if (personalCars.Count() > 1)
                    {
                        Console.WriteLine("You own these cars:\n");
                        for (int i = 0; i < personalCars.Count; i++)
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine(i + 1 + ". Car");
                            personalCars[i].data();
                        }
                        Console.WriteLine("Which car would you like to get in?");
                        int z = int.Parse(Console.ReadLine()) - 1;
                        
                        insideCar = z;
                        personalCars[insideCar].GetIn(personalCars[insideCar].Doors[0]);    
                    }
                    else if (personalCars.Count() == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        actions("Cars, Personal");
                    }
                    else
                    {   
                        insideCar = 0;
                        personalCars[0].GetIn(personalCars[0].Doors[0]);
                    }                

                    actions("Drive, Get out");
                    loop = false;
                    break;

                case "drive":
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].Drive();
                    }
                    else
                    {
                        Console.WriteLine("You are not in your car");
                        break;
                    }

                    actions("Drive, Change gear, Accelerate, Brake");
                    loop = false;
                    break;

                case "change gear":
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].ChangeGear(int.Parse(Console.ReadLine()));
                    }
                    else
                    {
                        Console.WriteLine("You are not in your car");
                        break;
                    }

                    actions("Drive, Change gear, Accelerate, Brake");
                    loop = false;
                    break;

                case "accelerate":
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].Accelerate(0);
                    }
                    else
                    {
                        Console.WriteLine("You are not in your car");
                        break;
                    }

                    actions("Drive, Change gear, Accelerate, Turbo, Brake");
                    loop = false;
                    break;

                case "turbo":
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].Turbo(0);
                    }
                    else
                    {
                        Console.WriteLine("You are not in your car");
                        break;
                    }

                    actions("Drive, Change gear, Accelerate, Brake");
                    loop = false;
                    break;

                case "brake": //DONE-------------------------------------
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].Brake();
                    }
                    else
                    {
                        Console.WriteLine("You are not in your car");
                        break;
                    }

                    actions("Drive, Get out");
                    loop = false;
                    break;
                
                case "get out": //DONE-------------------------------------
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].GetOut(personalCars[insideCar].Doors[0]);      
                    }
                    else
                    {
                        Console.WriteLine("You are not in your car");
                        break;
                    }
                            
                    actions("Cars, Personal");
                    loop = false;
                    break;

                case "exit": //DONE-------------------------------------
                    Console.WriteLine("Game exited.");
                    Console.ReadKey();
                    return;

                default:
                    break;
            }
        }
    }
}
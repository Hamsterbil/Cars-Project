class Person
{
    private static readonly Dealer dealer = new Dealer();
    public List<Car> personalCars = new List<Car>();
    public int insideCar;
    int i;
    public Credit money = new Credit();

    //ACTIONS IN THIS ORDER
    //Cars, New cars, Personal, Buy, Sell, Customize, Get in, Drive, Change gear, Accelerate, Turbo, Brake, Get out
    public void actions(string usedActions)
    {
    //Loop whenever wrong input
        bool loop = true;
        while(loop)
        {
            Console.WriteLine("\nWrite an action: [" + usedActions + "]");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "cars": /*
                - Clear console
                - Check if cars have been created (only happens once). If not, create and display 5 cars. Otherwise display current cars
                - Display balance
                - Display actions   */
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

                case "new cars": /*
                - Clear console
                - Remove all cars in randomCars list
                - Create 5 new cars in the list
                - Display actions   */
                    Console.Clear();
                    dealer.randomCars.Clear();
                    dealer.showCars(5, true);
                    dealer.talkingDealer("\nWould you like to purchase any of these cars?");
                    actions("New Cars, Personal, Buy, Sell");
                    break;

                case "personal": /*
                - Clear console
                - Display balance
                - Display currently owned cars, if any are owned
                - Display actions  */
                    Console.Clear();
                    money.bal();              
                    if (personalCars.Count > 0)
                    {
                        Console.WriteLine("You own these cars:\n");
                        for (int i = 0; i < personalCars.Count; i++)
                        {
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine(i + 1 + ". Car");
                            personalCars[i].data();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You do not own any cars.");
                    }
                    actions("Cars, Sell, Customize, Get in");
                    break;

                case "buy": /*
                - Checks if any cars exist. If not, loop switch
                - Player chooses car to buy. If player writes anything other than int, loop
                - Display actions   */
                    if (dealer.randomCars.Count > 0)
                    {
                        dealer.talkingDealer("\nPlease select your car: [1 - " + dealer.randomCars.Count + "]\n");
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
                            dealer.buy(int.Parse(input) - 1);
                        }
                        else 
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    break;

                case "sell": /*
                - Check if any car is owned
                - If player owns more than one car (to make player choose), sell chosen car. If they write anything other than an int, loops switch again
                - If they own 1 car (chooses automatically), sell
                - Display actions   */  
                    if (personalCars.Count == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        break;
                    }                       
                    Console.Clear();     
                    if (personalCars.Count > 1)
                    {       
                        dealer.talkingDealer("Are you sure you would like to sell a car?\n");
                        input = Console.ReadLine().ToLower();
                        if (input == "yes")
                        {                      
                            Console.WriteLine("You own these cars:\n");
                            for (int i = 0; i < personalCars.Count; i++)
                            {
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine(i + 1 + ". Car");
                                personalCars[i].data();
                            }

                            Console.WriteLine("\nWhat car would you like to sell?");     
                            input = Console.ReadLine();
                            if (int.TryParse(input, out i))
                            {
                                dealer.sell(int.Parse(input) - 1);
                            }
                            else 
                            {
                                break;
                            }
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
                    }
                    break;

                case "customize": /*
                - Clear console
                - Check if any car is owned
                - If player owns more than one car (to make player choose), customize chosen car. If they write anything other than an int, loops switch again
                - If they own 1 car (chooses automatically), customize
                - Display actions   */
                    if (personalCars.Count == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        break;
                    }    
                    Console.Clear();
                    if (personalCars.Count > 1)
                    {    
                            Console.WriteLine("You own these cars:\n");
                            for (int i = 0; i < personalCars.Count; i++)
                            {
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine(i + 1 + ". Car");
                                personalCars[i].data();
                            }
                            Console.WriteLine("\nWhat car would you like to sell?");                             
                            input = Console.ReadLine();
                            if (int.TryParse(input, out i))
                            {
                                dealer.customize(int.Parse(input) - 1);
                            }
                            else 
                            {
                                break;
                            }
                    }
                    else
                    {
                        personalCars[0].data();
                        dealer.customize(0);
                    }
                    break;

                case "get in": /*
                - Clear console
                - Check if any car is owned
                - If player owns more than one car (to make player choose), get inside chosen car. If they write anything other than an int, loops switch again
                - If they own 1 car (chooses automatically), get in
                - Display actions   */
                    if (personalCars.Count == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        break;
                    }    
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
                        input = Console.ReadLine();
                        if (int.TryParse(input, out i))
                            {
                                insideCar = int.Parse(input);
                                personalCars[insideCar].GetIn(personalCars[insideCar].Doors[0]);  
                            }
                            else 
                            {
                                break;
                            }
  
                    }
                    else if (personalCars.Count() == 0)
                    {
                        Console.WriteLine("You do not own any cars");
                        break;
                    }
                    else
                    {   
                        personalCars[0].GetIn(personalCars[0].Doors[0]);
                    }                
                    actions("Drive, Get out");
                    break;

                case "drive":
                    Console.WriteLine("You do not have the keys");
                    break;
                    // if (personalCars[insideCar].isInside)
                    // {
                    //     personalCars[insideCar].Drive();
                    // }
                    // else
                    // {
                    //     Console.WriteLine("You are not in your car");
                    //     break;
                    // }

                //     actions("Drive, Change gear, Accelerate, Brake");
                //     break;

                // case "change gear": //NOT MADE YET
                //     if (personalCars[insideCar].isInside)
                //     {
                //         personalCars[insideCar].ChangeGear(int.Parse(Console.ReadLine()));
                //     }
                //     else
                //     {
                //         Console.WriteLine("You are not in your car");
                //         break;
                //     }

                //     actions("Drive, Change gear, Accelerate, Brake");
                //     break;

                // case "accelerate": //NOT MADE YET
                //     if (personalCars[insideCar].isInside)
                //     {
                //         personalCars[insideCar].Accelerate(0);
                //     }
                //     else
                //     {
                //         Console.WriteLine("You are not in your car");
                //         break;
                //     }

                //     actions("Drive, Change gear, Accelerate, Turbo, Brake");
                //     break;

                // case "turbo": //NOT MADE YET
                //     if (personalCars[insideCar].isInside)
                //     {
                //         personalCars[insideCar].Turbo(0);
                //     }
                //     else
                //     {
                //         Console.WriteLine("You are not in your car");
                //         break;
                //     }

                //     actions("Drive, Change gear, Accelerate, Brake");
                //     break;

                // case "brake": //NOT MADE YET
                // 
                //     if (personalCars[insideCar].isInside)
                //     {
                //         personalCars[insideCar].Brake();
                //     }
                //     else
                //     {
                //         Console.WriteLine("You are not in your car");
                //         break;
                //     }

                //     actions("Drive, Get out");
                //     break;
                
                case "get out": /*
                - Check if inside car. If true, get out of car
                - Display actions   */
                    if (personalCars[insideCar].isInside)
                    {
                        personalCars[insideCar].GetOut(personalCars[insideCar].Doors[0]);      
                    }
                    else
                    {
                        Console.WriteLine("You are not in any car");
                        break;
                    }
                            
                    actions("Cars, Personal");
                    break;

                default:
                    break;
            }
        }
    }
}
#region Assignment

//Create a CarDealer program
//Minimum requirements:
//The CarDealer must have a list of available cars for sale
//The CarDealer must have public Buy/Sell methods
//These methods must be accessiable via console input/output
//These methods must change the car dealers available cars
//Make use of atleast 5 classes.
//These classes must have atleast 1 Field variable each
//Classes are usually nouns (navneord, en/et foran), f.x.:

//Car, CarDealer, Engine, Light, Tire, Door, Spoiler, Rim, Person, Credit

//Make use of atleast 10 methods
//5 of these methods must use paramaters
//Methods usually describes verbs (udsagnsord, at/jeg foran)

//Buy, Sell, Exit, Accelerate, Move, Turbo, Get in, Get out, Brake, Change gear

// Suggestion to get started on user interaction in the console

Dealer dealer = new Dealer(); //This class you need to create yourself!
while (true)
{

    Console.WriteLine("Write an action [buy, sell, exit]");
    string input = Console.ReadLine();

    switch (input)
    {
        case "buy":
            Car myNewCar = dealer.buy(/*...*/);
            break;
        case "sell":
            Car myNewCar = dealer.sell(/*...*/);
            break;
        case "exit":
            Console.WriteLine("You exit the car dealer.");
            Console.Readkey();
            return;
        default:
            return;
    }
}
{
    Console.WriteLine("Welcome to the Car Dealer.\n" +
    "Would you like to see our available cars?");

    string answer = Console.ReadLine();
    if (answer == "Yes" || answer == "yes")
    {
        talkingDealer("");

        Thread.Sleep(1000);
        Console.Clear();
        break;
    }

    else if (answer == "No" || answer == "no")
    {
        talkingDealer("");

        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Well screw you, man!");
        return;
    }

    else
    {
        talkingDealer("");

        Thread.Sleep(1000);
        Console.Clear();
        continue;
    }


}
#endregion

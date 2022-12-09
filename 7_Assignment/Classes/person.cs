class Person
{
    Dealer dealer = new Dealer();
    Credit moneys = new Credit(100000);
    public int i = 0;

    //Cars, Personal, Buy, Sell, Drive, Accelerate, Getin, Getout, Exit
    public void actions(string usedActions)
    {
        Console.WriteLine("\nWrite an action: [" + usedActions + "]");
        string input = Console.ReadLine();
        switch (input)
        {
            case "Cars":
                Console.Clear();
                if (i == 1)
                {
                    dealer.showCars(0, true);
                }
                while (i < 1)
                {
                    dealer.showCars(5, true);
                    i++;
                }
                moneys.bal();
                dealer.talkingDealer("\nWould you like to purchase any of these cars?");
                actions("Personal, Buy, Sell, Exit");
                break;

            case "Personal":
                moneys.bal();
                Console.WriteLine("You own these cars:\n");
                actions("Cars, Sell, Getin, Exit");
                break;

            case "Buy":
                dealer.talkingDealer("\nPlease select your car:\n");
                dealer.buy(int.Parse(Console.ReadLine()) - 1);
                break;

            case "Sell":

                break;

            case "Drive":

                break;

            case "Accelerate":

                break;

            case "Getin":

                break;

            case "Getout":

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
class Credit
{
    public double Amount = 100000;
    public void spendMoney(double deducted)
    {
        Amount = Amount - deducted;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("- $" + deducted + "\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void addMoney(double added)
    {
        Amount = Amount + added;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("+ $" + added + "\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void bal()
    {
        Console.WriteLine("\nYou have: $" + Amount + " moneys");
    }
}
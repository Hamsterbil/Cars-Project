class Credit
{
    public int Amount = 100000;
    public void spendMoney(int deducted)
    {
        Amount = Amount - deducted;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("- $" + deducted + "\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void addMoney(int added)
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
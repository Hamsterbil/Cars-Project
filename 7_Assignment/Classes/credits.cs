class Credit
{
    public int Amount = 0;
    public Credit(int amount)
    {
        this.Amount = amount;
    }

    public void spendMoney(int deducted)
    {
        Amount = Amount - deducted;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("- $" + deducted + "\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void bal()
    {
        Console.WriteLine("\nYou have: $" + Amount + " moneys");
    }
}
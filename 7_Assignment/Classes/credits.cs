class Credit {
    public double Amount = 100000;
    public void spendMoney(double deducted) {
        Amount = Amount - deducted;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("- $" + deducted);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void addMoney(double added) {
        Amount = Amount + added;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("+ $" + added);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void bal() {
        Console.Write("You have: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("$" + Amount);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
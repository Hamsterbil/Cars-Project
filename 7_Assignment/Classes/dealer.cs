class Dealer {
    public void buy() {

    }

    public void sell() {

    }

    public void customize() {

    }

    public void talkingDealer(string text) {
    Console.ForegroundColor = ConsoleColor.Blue;
    foreach (char c in text) {
        Console.Write(c);
    }
    Console.ForegroundColor = ConsoleColor.Red;  
    }

 }
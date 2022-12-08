class Dealer {
        public List<Car> randomCars = new List<Car>();
        int price;

    public void showCars(int i, bool showList = false) {
        Random RNG = new Random();

        int x = randomCars.Count;
        for (i = i + x; x < i; x = randomCars.Count) {

            int brandNum = RNG.Next(0, 9);
            int colorNum = RNG.Next(0, 8);           
            
            price = RNG.Next(10000, 100000);
            price = price % 10000 >= 5000 ? price + 10000 - price % 10000 : price - price % 10000;
            string pricernd = price.ToString("#,##0.00");

            string Brand = CarBrands[brandNum];
            string Color = CarColors[colorNum];
        
            randomCars.Add(new Car(CarBrands[brandNum], CarColors[colorNum], pricernd, 4, 4, 0, 0));
        }

        if (showList == true) {
            for (x = 0; x < randomCars.Count; x++) {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(x + 1 + ". " + randomCars[x]);
                randomCars[x].data();
            }
        }  
    }

    public void buy(int x) {

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
    Console.ForegroundColor = ConsoleColor.White;  
    }

    public static List<string> CarBrands = new List<string>() {
    "Volvo", "Volkswagen", "Toyota", "Ford", "Mercedes",
    "BMW", "Audi", "Kia", "Renault", "Peugeot"
    };

    public static List<string> CarColors = new List<string>() {
    "Yellow", "Black", "Silver", "Gold", "Red",
    "Blue", "White", "Orange", "Green"
    };

}
class Engine {
    Random RNG = new Random();
    public int Power = 0;
    public Engine(int power) {
        this.Power = RNG.Next(50, 100);
        this.Power = power;

    }
}
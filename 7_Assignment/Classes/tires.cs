class Tire
{
    Random RNG = new Random();
    public int Size = 0;

    public Tire(int size = 10)
    {
        size = RNG.Next(1, 10);
        this.Size = size;
    }
}

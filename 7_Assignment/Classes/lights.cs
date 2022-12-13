class Light
{
    Random RNG = new Random();
    public int Strength = 0;

    public Light(int strength)
    {
        strength = RNG.Next(50, 60);
        this.Strength = strength;
    }
}
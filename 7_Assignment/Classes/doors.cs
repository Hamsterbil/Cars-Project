class doors
{
    private bool IsOpen;

    public Door()
    {
        this.IsOpen = false;
    }

    public void Open()
    {
        if (this.IsOpen == true)
        {
            Console.WriteLine("Door already open");
        }
        else
        {
            Console.WriteLine("Door opened");
            this.IsOpen = true;
        }
    }

    public void Close()
    {
        if (this.IsOpen == false)
        {
            Console.WriteLine("Door already is close");
        }
        else
        {
            Console.WriteLine("Door closed");
            this.IsOpen = false;
        }
    }
}

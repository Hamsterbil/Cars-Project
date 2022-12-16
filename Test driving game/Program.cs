//CAR DEALER DRIVING "GAME"
/*
Actions:
    Drive:
        Straight
        Left
        Right
    Change gear
    Accelerate
    Turbo
    Brake

Pick up money (Worth $10 * speed?)
Don't get hit or hit others (- $5000?)
Brake will put speed = 0 next tick.

Personal car = § , % , U, &, 8, X? (Printed in color of car)
Pedestrians = w
Other cars = C
Money = $

Speed:
    >0 = 1 tile pr tick
    >30 = 2 tiles pr tick
    >60 = 3 tiles pr tick
    >100 = 4 tiles pr tick

Gears max speed:
    1 <= 10
    2 <= 25
    3 <= 50
    4 <= 80
    5 <= 130

Scene 11 x 5 (Actually 11 x 19)
Scene will refresh after every action using Console.Clear(). A tick
Every tick, random chance for Car, Money or Pedestrian to spawn in designated area, from the top.

EXAMPLE SCENE:  
      1   2   3   4   5           
    +---+---+---+---+---+       
 10 |w ||    $|   C ||  |       Speed = 30
  9 + w||  C        || w+       Current gear = 3
  8 |  ||     | $   ||  |       Turbo left = 100  (Will replenish)
  7 +  ||       $   ||ww+       Balance = $67500
  6 |  ||  $  |   C ||  |
  5 +w ||  C        ||  +       Actions:
  4 |  ||   C |  $  ||  |           [Straight, Left, Right, Change gear, Accelerate, Turbo, Brake]
  3 + w|| $  $  C   || w+
  2 |  || C   |    $||  |       + $300 (Whenever money collected) or - $5000
  1 +  ||        X  ||  +    ---Always keep car at this level        
  0 | w||  $  |     ||w |
    +---+---+---+---+---+       (If speed = 0, you can get out of car)

Write action:
____

*/
Road road = new Road();
road.Tick();
Console.ReadLine();
road.Tick();
Console.ReadLine();
road.Tick();
Console.ReadLine();
road.Tick();
Console.ReadLine();
road.Tick();
Console.ReadLine();
road.Tick();
Console.ReadLine();

public class Road
{
    List<Cash> _cash = new List<Cash>();
    List<Car> cars = new List<Car>();
    List<Pedestrian> people = new List<Pedestrian>();
	List<string> lines = new List<string>();
	List<string> walkLines = new List<string>();

    private string[,] road;
    public string edgeHorizontal { get; set; }

	public bool isInside = true; 


	int width = 5;
	int height = 11;

    public int _tick = 0;
    public Road()
    {
        // road = new string[DimensionHori, DimensionVerti];
        edgeHorizontal = "    +---+---+---+---+---+";

		for (int x = 0; x < height; x++)
			{
				if (x % 2 == 0)
					{
						this.lines.Add("||     |     ||");
					}
				else
					{
						this.lines.Add("||           ||");
					}
			}

		for (int x = 0; x < height; x++)
			{
				this.walkLines.Add("  ");
			}
		
		lines[10] = "||{0}{1}{2}{3}{4}{5}{6}{7}{8}||";
		lines[1] = "||         {0} ||";
    }
    public void Tick()
    {

		
		string[] data = {"C"," ","$"," "," | ","C","C"," "," "};
		string[] carData = {"X"};
		Random random = new Random();

        Console.WriteLine("      1   2   3   4   5");
        Console.Write(edgeHorizontal + "\n");
        Console.WriteLine(
           " 10 |" + walkLines[10] + String.Format(lines[10], data) + walkLines[10] + "|      Speed: " /*+ _speed*/ + "\n" +
           "  9 +" + walkLines[9] + lines[9] + walkLines[9] + "+      Current gear: " /*+ CurrentGear*/ + "\n" + 
           "  8 |" + walkLines[8] + lines[8] + walkLines[8] + "|      Turbo left: " /*+ turboTank*/ + "\n" +
           "  7 +" + walkLines[7] + lines[7] + walkLines[7] + "+      Balance: " /*+ bal*/ + "\n" +
           "  6 |" + walkLines[6] + lines[6] + walkLines[6] + "|\n" +
           "  5 +" + walkLines[5] + lines[5] + walkLines[5] + "+      Actions:" + "\n" +
           "  4 |" + walkLines[4] + lines[4] + walkLines[4] + "|         [" /*+ usedActions*/ + ", Exit]" + "\n" +
           "  3 +" + walkLines[3] + lines[3] + walkLines[3] + "+      " /*+ addMoney*/ + "\n" +
           "  2 |" + walkLines[2] + lines[2] + walkLines[2] + "|\n" +
           "  1 +" + walkLines[1] + String.Format(lines[1], carData) + walkLines[1] + "+\n" +
           "  0 |" + walkLines[0] + lines[0] + walkLines[0] + "|"
            );
        Console.Write(edgeHorizontal);

		Console.WriteLine("\n\n\n");

		for (int x = 0; x < 100; x++)
		{
			Console.Clear();
			string mmm = String.Format(lines[10], data);
			lines[0] = lines[3]; 
			lines[2] = lines[3];
			lines[3] = lines[4];
			lines[4] = lines[5];
			lines[5] = lines[6];
			lines[6] = lines[7];
			lines[7] = lines[8];
			lines[8] = lines[9];
			lines[9] = lines[10];
			lines[10] = lines[0];

			Console.WriteLine("      1   2   3   4   5");
        	Console.Write(edgeHorizontal + "\n");
			Console.WriteLine(
			" 10 |" + walkLines[10] + String.Format(lines[10], data) + walkLines[10] + "|      Speed: " /*+ _speed*/ + "\n" +
			"  9 +" + walkLines[9] + String.Format(lines[9], data) + walkLines[9] + "+      Current gear: " /*+ CurrentGear*/ + "\n" + 
            "  8 |" + walkLines[8] + String.Format(lines[8], data) + walkLines[8] + "|      Turbo left: " /*+ turboTank*/ + "\n" +
            "  7 +" + walkLines[7] + String.Format(lines[7], data) + walkLines[7] + "+      Balance: " /*+ bal*/ + "\n" +
            "  6 |" + walkLines[6] + String.Format(lines[6], data) + walkLines[6] + "|\n" +
            "  5 +" + walkLines[5] + String.Format(lines[5], data) + walkLines[5] + "+      Actions:" + "\n" +
            "  4 |" + walkLines[4] + String.Format(lines[4], data) + walkLines[4] + "|         [" /*+ usedActions*/ + ", Exit]" + "\n" +
            "  3 +" + walkLines[3] + String.Format(lines[3], data) + walkLines[3] + "+      " /*+ addMoney*/ + "\n" +
            "  2 |" + walkLines[2] + String.Format(lines[2], data) + walkLines[2] + "|\n" +
            "  1 +" + walkLines[1] + String.Format(lines[1], carData) + walkLines[1] + "+\n" +
            "  0 |" + walkLines[0] + String.Format(lines[0], data) + walkLines[0] + "|"
            );
			Console.Write(edgeHorizontal);

			_tick++;
			Console.WriteLine("\n\n" + _tick);
			Thread.Sleep(500);
		}
        

    }       
	public class Cash
	{

	}
	public class Pedestrian
	{

	}
}
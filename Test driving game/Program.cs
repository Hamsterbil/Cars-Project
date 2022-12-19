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
    }

    public void Tick()
    {
		Random random = new Random();
        int carPos = 7;
        string[] data = {" "," "," "," "," | "," "," "," ", " "};        
        string[] carData = {" "," "," "," "," | "," "," "," ", " "};
        string line0save = "";
        string line0save1 = "";
        int l = 0;
        int xx = 0;
        string input = "";
        bool loop = true;

        string[] data2 = {" "," "," "," "," | "," "," "," ", " "}; 
        string[] data3 = {" "," "," "," "," | "," "," "," ", " "}; 
        string[] data4 = {" "," "," "," "," | "," "," "," ", " "}; 
        string[] data5 = {" "," "," "," "," | "," "," "," ", " "}; 
        string[] data6 = {" "," "," "," "," | "," "," "," ", " "}; 
        string[] data7 = {" "," "," "," "," | "," "," "," ", " "}; 
        string[] data8 = {" "," "," "," "," | "," "," "," ", " "};
        string[] data9 = {" "," "," "," "," | "," "," "," ", " "};  

	    while (loop)
		{
            if (input == "left" && carPos > 0)
            {
                carPos = carPos - 1;
            }
            else if (input == "right" && carPos < 8)
            {
                carPos = carPos + 1;
            }
            carData[carPos] = "X";
            lines[10] = "||{0}{1}{2}{3}{4}{5}{6}{7}{8}||";
            lines[10] = string.Format(lines[10], data);
            lines[1] = string.Format(lines[1], carData);

			Console.Clear();
			Console.WriteLine("      1   2   3   4   5");
        	Console.Write(edgeHorizontal + "\n");
			Console.WriteLine(
			" 10 |" + walkLines[10] + lines[10] + walkLines[10] + "|      Speed: " /*+ _speed*/ + "\n" +
			"  9 +" + walkLines[9] + lines[9] + walkLines[9] + "+      Current gear: " /*+ CurrentGear*/ + "\n" + 
            "  8 |" + walkLines[8] + lines[8] + walkLines[8] + "|      Turbo left: " /*+ turboTank*/ + "\n" +
            "  7 +" + walkLines[7] + lines[7] + walkLines[7] + "+      Balance: " /*+ bal*/ + "\n" +
            "  6 |" + walkLines[6] + lines[6] + walkLines[6] + "|\n" +
            "  5 +" + walkLines[5] + lines[5] + walkLines[5] + "+      Actions:" + "\n" +
            "  4 |" + walkLines[4] + lines[4] + walkLines[4] + "|         [" /*+ usedActions*/ + ", Exit]" + "\n" +
            "  3 +" + walkLines[3] + lines[3] + walkLines[3] + "+      " /*+ addMoney*/ + "\n" +
            "  2 |" + walkLines[2] + lines[2] + walkLines[2] + "|\n" +
            "  1 +" + walkLines[1] + lines[1] + walkLines[1] + "+\n" +
            "  0 |" + walkLines[0] + lines[0] + walkLines[0] + "|"
            );
			Console.Write(edgeHorizontal);
			Console.WriteLine("\n\n" + _tick);

            for (int z = 0; z < 9; z++)
            {
                int i = random.Next(0, 9);
                    if (i == 0)
                    {
                        data[z] = "C";
                    }
                    else if (i == 1)
                    {
                        data[z] = "$";
                    }
                    else
                    {
                        data[z] = " ";
                    }
            }

            if (xx == 0) {data2 = data;}
            if (xx == 1) {data3 = data;}
            if (xx == 2) {data4 = data;}
            if (xx == 3) {data5 = data;}
            if (xx == 4) {data6 = data;}
            if (xx == 5) {data7 = data;}
            if (xx == 6) {data8 = data;}
            if (xx == 7) {data9 = data;}

            if (xx > 7)
            {
                for (int x = 0; x < 8; x++)
                {
                    
                    if (data9[carPos] == "C")
                    {
                        Console.WriteLine("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");                    
                    }
                    carData[x] = data9[x];
                    carData[carPos] = "X";

                    data9 = data8;
                    data8 = data7;
                    data7 = data6; 
                    data6 = data5; 
                    data5 = data4; 
                    data4 = data3; 
                    data3 = data2; 
                    data2 = data; 
                }
            }

            if (l == 0)
            {
                data[4] = "   ";
                l++;
            }
            else
            {
                data[4] = " | ";
                l--;
            }

                if (_tick == 0)
                {
                    line0save = lines[3];
                    line0save1 = lines[2];
                }
                if (_tick % 2 != 0)
                {
                    line0save = lines[2];
                    lines[0] = line0save1;
                }
                else if (_tick % 2 == 0)
                {
                    line0save1 = lines[2];
                    lines[0] = line0save;
                }            
            lines[2] = lines[3];
			lines[3] = lines[4];
			lines[4] = lines[5];
			lines[5] = lines[6];
			lines[6] = lines[7];
			lines[7] = lines[8];
			lines[8] = lines[9];
			lines[9] = lines[10];

            _tick++;
            xx++;
            input = Console.ReadLine();
        }    

    }       
	public class Cash
	{

	}
	public class Pedestrian
	{

	}
}
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
Don"t get hit or hit others (- $5000?)
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
                this.lines.Add("     |     ");
            }
            else
            {
                this.lines.Add("           ");
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
        int carPos = 9;
        string[] data = {" "," "," "," "," ","|"," "," "," "," "," "};        
        string line0save = "";
        string line0save1 = "";
        string[] carData = {" "," "," "," "," "," "," "," "," "," "," "};
        int l = 0;
        string input = "";
        bool loop = true;
        int bal = 10000;
    
        while (loop)
		{          
            if (carData[carPos] == "C")
            {
                bal = bal - 5000;
            }
            else if (carData[carPos] == "$")
            {
                bal = bal + 500;
            }  
            
            //Make into arrow keys input
            carData[carPos] = " ";
            if (input == "left" && carPos > 0)
            {
                carPos = carPos - 1;
            }
            else if (input == "right" && carPos < 10)
            {
                carPos = carPos + 1;
            }
            carData[carPos] = "X";

            lines[10] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            lines[10] = string.Format(lines[10], data);

            lines[1] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            lines[1] = string.Format(lines[1], carData);
            lines[2] = string.Format(lines[10], data2);
            lines[3] = string.Format(lines[10], data3);
            lines[4] = string.Format(lines[10], data4);
            lines[5] = string.Format(lines[10], data5);
            lines[6] = string.Format(lines[10], data6);
            lines[7] = string.Format(lines[10], data7);
            lines[8] = string.Format(lines[10], data8);
            lines[9] = string.Format(lines[10], data9);
            lines[10] = string.Format(lines[10], data);


            
			Console.Clear();
			Console.WriteLine("      1   2   3   4   5");
        	Console.Write(edgeHorizontal + "\n");
			Console.WriteLine(
			" 10 |" + walkLines[10] + "||" + lines[10] + "||" + walkLines[10] + "|      Speed: " /*+ _speed*/ + "\n" +
			"  9 +" + walkLines[9] + "||" + lines[9] + "||" + walkLines[9] + "+      Current gear: " /*+ CurrentGear*/ + "\n" + 
            "  8 |" + walkLines[8] + "||" + lines[8] + "||" + walkLines[8] + "|      Turbo left: " /*+ turboTank*/ + "\n" +
            "  7 +" + walkLines[7] + "||" + lines[7] + "||" + walkLines[7] + "+      Balance: " + bal + "\n" +
            "  6 |" + walkLines[6] + "||" + lines[6] + "||" + walkLines[6] + "|\n" +
            "  5 +" + walkLines[5] + "||" + lines[5] + "||" + walkLines[5] + "+      Actions:" + "\n" +
            "  4 |" + walkLines[4] + "||" + lines[4] + "||" + walkLines[4] + "|         [" /*+ usedActions*/ + ", Exit]" + "\n" +
            "  3 +" + walkLines[3] + "||" + lines[3] + "||" + walkLines[3] + "+      " /*+ addMoney*/ + "\n" +
            "  2 |" + walkLines[2] + "||" + lines[2] + "||" + walkLines[2] + "|\n" +
            "  1 +" + walkLines[1] + "||" + lines[1] + "||" + walkLines[1] + "+\n" +
            "  0 |" + walkLines[0] + "||" + lines[0] + "||" + walkLines[0] + "|"
            );
			Console.Write(edgeHorizontal);
			Console.WriteLine("\n\n" + _tick);
 

            for (int z = 0; z < 11; z++)
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

            if (l == 0)
            {
                data[5] = " ";
                l++;
            }
            else
            {
                data[5] = "|";
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

            carData = lines[2].ToArray().Select( c => c.ToString()).ToArray();
            lines[2] = lines[3];
			lines[3] = lines[4];
			lines[4] = lines[5];
			lines[5] = lines[6];
			lines[6] = lines[7];
			lines[7] = lines[8];
			lines[8] = lines[9];
			lines[9] = lines[10];

            _tick++;
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
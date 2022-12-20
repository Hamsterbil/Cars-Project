
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

public class Road
{
    private string[,] road;
    public string edgeHorizontal { get; set; }
	int height = 11;

    public int _tick = 0;


    List<string> roadLines = new List<string>();
	List<string> walkLines = new List<string>();
    public Road()
    {
        edgeHorizontal = "    +---+---+---+---+---+";

		for (int x = 0; x < height; x++)
        {
            if (x % 2 == 0)
            {
                this.roadLines.Add("     |     ");
            }
            else
            {
                this.roadLines.Add("           ");
            }
        }

		for (int x = 0; x < height; x++)
        {
            this.walkLines.Add("  ");
        }
    }

    public void Drive()
    {

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
                player.bal = player.bal - 5000;
            }
            else if (carData[carPos] == "$")
            {
                player.bal = player.bal + 500;
            }

            if (carData[5] == carData[carPos])
            {
                
            }
            else
            {
                carData[carPos] = " ";
            }

            carData[carPos] = "X";
            roadLines[10] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            roadLines[1] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            roadLines[10] = string.Format(roadLines[10], data);
            roadLines[1] = string.Format(roadLines[1], carData);

            //Display road with everything on
			Console.Clear();
			Console.WriteLine("      1   2   3   4   5");
        	Console.Write(edgeHorizontal + "\n");
			Console.WriteLine(
			" 10 |" + walkLines[10] + "||" + roadLines[10] + "||" + walkLines[10] + "|      Speed: " /*+ _speed*/ + "\n" +
			"  9 +" + walkLines[9] + "||" + roadLines[9] + "||" + walkLines[9] + "+      Current gear: " /*+ CurrentGear*/ + "\n" + 
            "  8 |" + walkLines[8] + "||" + roadLines[8] + "||" + walkLines[8] + "|      Turbo left: " /*+ turboTank*/ + "\n" +
            "  7 +" + walkLines[7] + "||" + roadLines[7] + "||" + walkLines[7] + "+      Balance: " + bal + "\n" +
            "  6 |" + walkLines[6] + "||" + roadLines[6] + "||" + walkLines[6] + "|\n" +
            "  5 +" + walkLines[5] + "||" + roadLines[5] + "||" + walkLines[5] + "+      Actions:" + "\n" +
            "  4 |" + walkLines[4] + "||" + roadLines[4] + "||" + walkLines[4] + "|         [" /*+ usedActions*/ + ", Exit]" + "\n" +
            "  3 +" + walkLines[3] + "||" + roadLines[3] + "||" + walkLines[3] + "+      " /*+ addMoney*/ + "\n" +
            "  2 |" + walkLines[2] + "||" + roadLines[2] + "||" + walkLines[2] + "|\n" +
            "  1 +" + walkLines[1] + "||" + roadLines[1] + "||" + walkLines[1] + "+\n" +
            "  0 |" + walkLines[0] + "||" + roadLines[0] + "||" + walkLines[0] + "|"
            );
			Console.Write(edgeHorizontal);
			Console.WriteLine("\n\n" + _tick);
            //--------------------------------------------

            var key = Console.ReadKey(false).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (carPos > 0)
                    {
                        carPos = carPos - 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (carPos < 10)
                    {
                        carPos = carPos + 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    break;

                case ConsoleKey.DownArrow:
                    break;
            } 
            

            


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
                line0save = roadLines[3];
                line0save1 = roadLines[2];
            }

            if (_tick % 2 != 0)
            {
                line0save = roadLines[2];
                roadLines[0] = line0save1;
            }
            else if (_tick % 2 == 0)
            {
                line0save1 = roadLines[2];
                roadLines[0] = line0save;
            }    

            carData = roadLines[2].ToArray().Select( c => c.ToString()).ToArray();
            roadLines[2] = roadLines[3];
			roadLines[3] = roadLines[4];
			roadLines[4] = roadLines[5];
			roadLines[5] = roadLines[6];
			roadLines[6] = roadLines[7];
			roadLines[7] = roadLines[8];
			roadLines[8] = roadLines[9];
			roadLines[9] = roadLines[10];

            _tick++;
        }    
    }
}
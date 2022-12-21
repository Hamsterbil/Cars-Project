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
    1 <= 15
    2 <= 25
    3 <= 50
    4 <= 80
    5 <= 160

Scene 11 x 5 (Actually 11 x 19)
Scene will refresh after every action using Console.Clear(). A tick
Every tick, random chance for Car, Money or Pedestrian to spawn in designated area, from the top.

EXAMPLE SCENE:  
      1   2   3   4   5           
    +---+---+---+---+---+       
 10 |w ||    $|   C ||  |       Speed = 30
  9 + w||  C        || w+       Current gear = 3
  8 |  ||     | $   ||  |       Balance = $67500
  7 +  ||       $   ||ww+       
  6 |  ||  $  |   C ||  |       Actions:
  5 +w ||  C        ||  +           [Change gear (W) , Accelerate (A) , Brake (S)]
  4 |  ||   C |  $  ||  |           
  3 + w|| $  $  C   || w+
  2 |  || C   |    $||  |       + $300 (Whenever money collected) or - $5000
  1 +  ||        X  ||  +    ---Always keep car at this level        
  0 | w||  $  |     ||w |
    +---+---+---+---+---+       (If speed = 0, you can get out of car)

Write action:
____

*/

//Træls det er så mange linjer, men ved ikke hvor jeg ellers skulle smide tingene hen

class Road
{
    Random random = new Random();
    int car;
	int height = 11;
    int _tick;
    int carPos; 
    int l;
    int dolladolla;
    bool loop;
    string edgeHorizontal { get; set; }
    string line0save = "";
    string line0save1 = "";    
    string input = "";
    string[] data = {" "," "," "," "," ","|"," "," "," "," "," "};        
    string[] carData = {" "," "," "," "," "," "," "," "," "," "," "};
    string[] noCarData = {" "," "," "," "," ","|"," "," "," "," "," "};

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
    public void Tick(Person player)
    {   
        car = player.insideCar;
        carPos = 9; 
        l = 0;
        _tick = 0;

        while (player.personalCars[car].isInside)
		{   
            dolladolla = 0;
            loop = true;

            if (player.money.Amount < 0)
            {   
                Console.WriteLine("You crashed and lost your car");
                player.personalCars.RemoveAt(car);
                if (player.personalCars.Count() == 0)
                {
                    Console.WriteLine("Game over...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                player.money.Amount = 0;
                player.actions("Cars, Personal", player);
            }
            if (carData[carPos] == "C")
            {
                dolladolla = -1;
            }
            else if (carData[carPos] == "$")
            {
                player.money.addMoney(500);
                dolladolla = 1;
            }

            if (carData[5] != carData[carPos])
            {
                carData[carPos] = " ";
            }

            carData[carPos] = "X";
            roadLines[10] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            roadLines[1] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            roadLines[0] = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}";
            roadLines[10] = string.Format(roadLines[10], data);
            roadLines[1] = string.Format(roadLines[1], carData);
            roadLines[0] = string.Format(roadLines[0], noCarData);
            //Display road with everything on
			Console.Clear();
			Console.WriteLine("      1   2   3   4   5");
        	Console.Write(edgeHorizontal + "\n");
			Console.Write(
			" 10 |" + walkLines[10] + "||" + roadLines[10] + "||" + walkLines[10] + "|      Speed: " + player.personalCars[car]._speed  + "\n" +
			"  9 +" + walkLines[9] + "||" + roadLines[9] + "||" + walkLines[9] + "+      Current gear: " + player.personalCars[car].CurrentGear + "\n" + 
            "  8 |" + walkLines[8] + "||" + roadLines[8] + "||" + walkLines[8] + "|      Balance: " + player.money.Amount + "\n" +
            "  7 +" + walkLines[7] + "||" + roadLines[7] + "||" + walkLines[7] + "+\n" +      
            "  6 |" + walkLines[6] + "||" + roadLines[6] + "||" + walkLines[6] + "|      Inputs:" + "\n" +
            "  5 +" + walkLines[5] + "||" + roadLines[5] + "||" + walkLines[5] + "+      [Drive (\x2191), Left (\x2190), Right (\x2192), Change Gear (W), Accelerate (A), Brake (\x2193)]\n" +
            "  4 |" + walkLines[4] + "||" + roadLines[4] + "||" + walkLines[4] + "|\n" +
            "  3 +" + walkLines[3] + "||" + roadLines[3] + "||" + walkLines[3] + "+      "); 
            
            if (dolladolla == 1)
            {
                player.money.addMoney(10 * player.personalCars[car]._speed);
                dolladolla = 0;
            }
            else if (dolladolla == -1)
            {
                player.money.spendMoney(5000);
                dolladolla = 0;
            }
            Console.WriteLine(   
            "\n" +
            "  2 |" + walkLines[2] + "||" + roadLines[2] + "||" + walkLines[2] + "|\n" +
            "  1 +" + walkLines[1] + "||" + roadLines[1] + "||" + walkLines[1] + "+\n" +
            "  0 |" + walkLines[0] + "||" + roadLines[0] + "||" + walkLines[0] + "|"
            );
			Console.Write(edgeHorizontal);
			Console.WriteLine("\n\n" + _tick);
            //--------------------------------------------

            if (player.personalCars[car]._speed == 0f)
            {
                Console.WriteLine("If you wish to exit your vehicle, press 'Escape'");
            }

            while (loop)
            {
                Console.WriteLine("\nPress an input");
                ConsoleKey key = Console.ReadKey(false).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (carPos > 0)
                        {
                            if (player.personalCars[car]._speed > 0)
                            {
                            carPos = carPos - 1;
                            loop = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWatch out you don't crash");
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (carPos < 10)
                        {
                            if (player.personalCars[car]._speed > 0)
                            {
                            carPos = carPos + 1;
                            loop = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWatch out you don't crash");
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        player.personalCars[car].Drive();
                        loop = false;
                        break;

                    case ConsoleKey.DownArrow:
                        if (player.personalCars[car]._speed > 0)
                        {
                            player.personalCars[car].Brake();
                            loop = false;
                        }
                        else 
                        {
                            Console.WriteLine("\nCar already stopped");
                        }
                        break;

                    case ConsoleKey.A:
                        if (player.personalCars[car]._speed > 0)
                        {
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nYou are not driving");
                        }
                        break;

                    case ConsoleKey.W:
                        if (player.personalCars[car]._speed > 0)
                        {
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nYou are not driving");
                        }
                        break;
                        
                    case ConsoleKey.Escape:
                        if (player.personalCars[car]._speed == 0)
                        {
                            player.personalCars[car].GetOut(player.personalCars[car].Doors[0]);
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nTry stopping your car");
                        }
                        break;

                    default:
                        Console.WriteLine("\nNot a valid input");
                        break;
                }
            }
            
            for (int z = 0; z < data.Count(); z++)
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

            roadLines[0] = roadLines[1];
            noCarData = roadLines[1].ToArray().Select(c => c.ToString()).ToArray();
            for (int x = 0; x < noCarData.Count(); x++)
            {
                if (noCarData[x] == "X")
                {
                    noCarData[x] = " ";
                    if (x == 5)
                    {
                        if (l == 0)
                        {
                            noCarData[5] = "|";
                        }
                        else
                        {
                            noCarData[5] = " ";
                        }
                    }
                    break;
                }
            }

    // >0 = 1 tile pr tick
    // >30 = 2 tiles pr tick
    // >60 = 3 tiles pr tick
    // >100 = 4 tiles pr tick

            carData = roadLines[2].ToArray().Select(c => c.ToString()).ToArray();
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
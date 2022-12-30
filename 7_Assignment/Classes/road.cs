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

//Magtede ikke at få alt med, men det ligemeget (Køre delen kunne være bedre og mangler gågængere)

class Road
{
    Random random = new Random();
    int car;
	int height = 11;
    int _tick;
    int carPos; 
    int l;
    int dolladolla;
    int gear;
    int increment = 0;
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

		for (int x = 0; x < height + 4; x++)
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
        gear = 0;

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
            "  8 |" + walkLines[8] + "||" + roadLines[8] + "||" + walkLines[8] + "|      Balance: " + player.money.Amount + " ");            
            if (dolladolla == 1)
            {
                player.money.addMoney(10 * player.personalCars[car]._speed);
            }
            else if (dolladolla == -1)
            {
                player.money.spendMoney(5000);                
            }            
            Console.Write( 
            "\n  7 +" + walkLines[7] + "||" + roadLines[7] + "||" + walkLines[7] + "+\n" +      
            "  6 |" + walkLines[6] + "||" + roadLines[6] + "||" + walkLines[6] + "|      [Drive (\x2191), Left (\x2190), Right (\x2192), Change Gear (W), Accelerate (A), Brake (\x2193)]\n" +
            "  5 +" + walkLines[5] + "||" + roadLines[5] + "||" + walkLines[5] + "+  " + 
            "\n  4 |" + walkLines[4] + "||" + roadLines[4] + "||" + walkLines[4] + "|" +
            "\n  3 +" + walkLines[3] + "||" + roadLines[3] + "||" + walkLines[3] + "+" +
            "\n  2 |" + walkLines[2] + "||" + roadLines[2] + "||" + walkLines[2] + "|" +           
            "\n  1 +" + walkLines[1] + "||" + roadLines[1] + "||" + walkLines[1] + "+" +
            "\n  0 |" + walkLines[0] + "||" + roadLines[0] + "||" + walkLines[0] + "|\n");
			Console.Write(edgeHorizontal);
        //--------------------------------------------

            if (player.personalCars[car]._speed == 0f)
            {
                Console.WriteLine("\nIf you wish to exit your vehicle, press 'Escape'");
            }
        
        //Input with exception handling
            while (loop)
            {
                Console.WriteLine("\nPress a valid input");
                ConsoleKey key = Console.ReadKey(false).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (carPos == 0)
                        {
                            Console.WriteLine("\nWatch out you don't crash");
                            break;
                        }                        
                        else if (player.personalCars[car]._speed > 0)
                            {
                                carPos = carPos - 1;
                                loop = false;
                            }
                        break;

                    case ConsoleKey.RightArrow:
                        if (carPos == 10)
                        {
                            Console.WriteLine("\nWatch out you don't crash");
                        }
                        else if (player.personalCars[car]._speed > 0)
                            {
                            carPos = carPos + 1;
                            loop = false;
                            }
                        break;

                    case ConsoleKey.UpArrow:
                        player.personalCars[car].Drive(random.Next(1, 5));
                        loop = false;
                        if (gear == 0)
                        {
                            gear = 1;
                            increment = 1;
                            player.personalCars[car].ChangeGear(1);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (player.personalCars[car]._speed > 0)
                        {
                            player.personalCars[car].Brake();
                            player.personalCars[car].CurrentGear = 0;
                            gear = 0;
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
                            player.personalCars[car].Accelerate(random.Next(10, 20));
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
                            if (gear == 1)
                            {
                                increment = 1;
                            }
                            else if (gear == 5)
                            {
                                increment = 0;
                            }

                            if (increment == 0)
                            {
                                player.personalCars[car].ChangeGear(-1); 
                                gear--;
                            }
                            else 
                            {
                                player.personalCars[car].ChangeGear(1); 
                                gear++;
                            }
                             
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
            
        //Place cars (C), money ($) and road lines (|) correctly
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

        //Place car (X) and road lines (|) correctly
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

        //Make line 2 into array, to check for money or other cars
            carData = roadLines[2].ToArray().Select(c => c.ToString()).ToArray();

        //Recursive something I think. Anyways, it makes moves upper line into lower line
            int zz;
            int p;
            for (zz = 2, p = 3; zz < height; zz++, p++)
            {
                roadLines[zz] = roadLines[p];
            }

            _tick++;
        }    
    }
}
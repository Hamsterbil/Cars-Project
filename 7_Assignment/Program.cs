﻿//Create a CarDealer program
//Minimum requirements:
//The CarDealer must have a list of available cars for sale
//The CarDealer must have public Buy/Sell methods
//These methods must be accessiable via console input/output
//These methods must change the car dealers available cars
//Make use of atleast 5 classes.
//These classes must have atleast 1 Field variable each
//Classes are usually nouns (navneord, en/et foran), f.x.:

//Car, CarDealer, Engine, Light, Tire, Door, Spoiler, Rim, Person, Credit

//Make use of atleast 10 methods
//5 of these methods must use paramaters
//Methods usually describes verbs (udsagnsord, at/jeg foran)

//Buy, Sell, Exit, Accelerate, Move, Turbo, Get in, Get out, Brake, Change gear

Person player = new Person();
Dealer dealer = new Dealer();

dealer.talkingDealer("Welcome to our Car Dealership TM.");

player.actions("Cars, Personal, Exit");

// string answer = Console.ReadLine();
// if (answer == "Yes" || answer == "yes")
// {
//     dealer.talkingDealer("");
//     Thread.Sleep(1000);
//     Console.Clear();
// }

// else if (answer == "No" || answer == "no")
// {
//     dealer.talkingDealer("Well screw you, man!");
//     Thread.Sleep(1000);
//     return;
// }

// else
// {
//     Thread.Sleep(1000);
//     return;
// }




Console.ReadKey();

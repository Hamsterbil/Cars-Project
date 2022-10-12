/*
* Todays work will be refactoring the Car, Door and Tire class into seperate files
* and laying the ground work for the next assignment
*/

//Instantiating a Car class / Creating an object of type Car
Car car1 = new Car("BMW");
Car car2 = new Car("Toyota", 2, 8, 25);
car1.Drive();

Car[] carArr = new Car[5];

List<Car> cars = new List<Car>();
cars.Add(new Car("Mercedes"));

Console.ReadKey();
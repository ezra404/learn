/*
  System namespace provides input/output functions, and Console is used for I/O.
  Not seeing it right now because of 'Top-Level' Statements

  - Console.WriteLine() displays messages or values on the screen and moves to a new line.
  - Console.Write() displays messages without moving to a new line.
  - Console.ReadLine() reads input from the user as a string; type conversion is
  needed for other types like int.Parse() or float.Parse().

*/

using System.Globalization;

Console.Write("Enter your age, height, grade, and name");
string[] inputs = (Console.ReadLine() ?? "").Split(' ');

int age = int.Parse(inputs[0], CultureInfo.InvariantCulture);
float height = float.Parse(inputs[1], CultureInfo.InvariantCulture);
char grade = char.Parse(inputs[2]);
string name = inputs[3];

Console.WriteLine("your age: " + age);
Console.WriteLine("your height: " + height);
Console.WriteLine("your grade: " + grade);
Console.WriteLine("your name: " + name);

// See https://aka.ms/new-console-template for more information
//Fizz Buzz
//Write a program thaty prints the numbers from 1 to 8 (where N is a given upper limit
//For number divisible by 3, print "Fizz" instead of the number
//For numbers divisible by 5, print "Buzz" instead of the number.
//For numbers divisible by both 3 and 5, print "FizzBuzz" instead of the number.


using System.Diagnostics.Contracts;

int x = 1;

Console.WriteLine("How many rows should teh table have?");
int row = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("How many columns should the table have?");
int col = Convert.ToInt16(Console.ReadLine());


for(int i = 0; i <= col; i++)
{
    if (i == 0)
    {
        Console.Write($"  |");
    }
    else
    {
        Console.Write($"{i,5}|");
    }
}
Console.WriteLine();

for(int i = 0; i <= col; i++)
{
    Console.Write($"-------");
}
Console.WriteLine();

for(int i = 1; i <= row; i++)
{
    Console.Write($"{i,5}|");
      for(x = 1; x <= col; x++)
    {
        Console.Write($"{i * x,5}|");
    }
    Console.WriteLine();
}
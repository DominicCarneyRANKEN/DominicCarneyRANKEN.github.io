// See https://aka.ms/new-console-template for more information

//Loops - Make your program POWERFUL - Write a little bit of code, that does something repetivley
//and makes your program DO a lot of work

//Count Controlled Loop
//PreTest loop- The condition is tested before the body executes the first iteration of the loop


//Printing Odd numbers

//for (int i = 100; i > 1; i/=2)
//{

//}

//For Printing Even Numbers
//for (int i = 100; i > 1; i-=2 )
//{
//    Console.WriteLine($"The current value of i is {i}");

//}

//We have a while loop & a do while loop

//int j = 0;

////Pre Test Loops
//while(j <= 10)
//{
//    Console.WriteLine($"Tbe current value of j is {j}");
//    j += 2;
//}

//int e = 100;

//do
//{
//    Console.WriteLine($"The current value of e is {e}");
//} while (e <= 10);
//Conditonals - Mkae your programs SMART - Humans make decisions based on conditions
//Conditionals allow our software to do the same thing.


//int testScore = 90;
//if (testScore >= 90)
//{
//    Console.WriteLine("You got an A");
//}
//else if (testScore >= 80)
//{
//    Console.WriteLine("You got an B");
//}
//else if (testScore >= 70)
//{
//    Console.WriteLine("You got an C");
//}else{
//    Console.WriteLine("F");
//}

//int age = 24;

//switch (age)
//{
//    case > 10:
//        Console.WriteLine("You're a kid");
//        break;
//    case 2:
//        Console.WriteLine("Youre a baby");
//        break;
//    case 3:
//        Console.WriteLine("Youre still a baby");
//        break;
//    default:
//        Console.WriteLine("Well partner, Idk how old u r partner");
//        break;
//}


//Fizz Buzz
//Write a program that prints the numbers from 1 to 8 (where N is a given upper limit
//For number divisible by 3, print "Fizz" instead of the number
//For numbers divisible by 5, print "Buzz" instead of the number.
//For numbers divisible by both 3 and 5, print "FizzBuzz" instead of the number.

Console.WriteLine("What is the upper limit of our Fizz Buzz");
int upperLimit = Convert.ToInt32(Console.ReadLine());

for(int i = 1; i <= upperLimit; i++)
{
    if(i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }else if(i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }else if(i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine($"{i}");
    }
}

//for (int i = 0; i < 1; i/= 3)
//{
//    if(i = 3)
//    {
//        Console.WriteLine($"{3}");
//    }
//}


//unary
//i++

//binary operators
// i+3

//Ternary Conditional Operator
//Short Hand for if-else

//int i = 100;

//string result = i < 200 ? "i less than 200" : "i greather or equal to 200";
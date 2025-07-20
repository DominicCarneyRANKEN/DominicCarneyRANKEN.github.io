//Create an appliation that creates four classes: Page, Corner, Pancake and Leaf

//Create an Interface named UTurnable that contains a method named Turn()

//The 4 classes should implement that interface and a diff implementation of the Turn()

//In Program.cs Create a List<ITurnable> and add instances of each class to the list

//Write a single method in Program.cs that accepts a List <ITurnable> and calls-
//the Turn() method on each item in the list

using Proj9;

static void Turning(List<ITurnable> t)
{
    foreach (ITurnable turn in t)
    {
        Console.WriteLine(turn.Turn());
    }
}

Leaf leaf = new();
Pancake pancake = new();
Corner corner = new();
Page page = new();
List<ITurnable> turns = [leaf, pancake, corner, page];

Turning(turns);
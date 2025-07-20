//Classes are blueprints for objects

using Proj8;

// Create a Cart class that represents a shopping cart in an e-commerce application.
// The Cart class should have the following instance fields:

// _cartId (string)
// _items (Dictionary of <String, double> such as <"Lollypop", 2.5>)

// The Cart class should have the following methods:
// AddItem - Adds a string item to the cart
// RemoveItem - Removes a string item from the cart
// GetTotal - Returns the total price of the items in the cart

// Optionally, can add consturctors/ToString methods

Dictionary<string, double> items = new Dictionary<string, double>();
items.Add("Lollypop", 2.5);
items.Add("Gum", 1.5);
items.Add("Soda", 3.75);

Cart cart1 = new Cart("1234");
cart1.AddItem("Lollypop", 2.5);
cart1.AddItem("Gum", 1.5);

Cart cart2 = new Cart("5678");
cart2.AddItem("Soda", 3.75);
cart2.AddItem("Lollypop", 2.5);

Console.WriteLine(cart1);
Console.WriteLine(cart2);
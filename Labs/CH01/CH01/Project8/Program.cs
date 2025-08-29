using Project8;

Cart cart1 = new Cart("1234");
cart1.AddItem("Apple", 0.99);
cart1.AddItem("Banana", 0.59);
cart1.AddItem("Orange", 0.79);
Console.WriteLine(cart1);

cart1.RemoveItem("Banana");
Console.WriteLine(cart1);

Cart cart2 = new Cart("5678");
cart2.AddItem("Milk", 2.99);
cart2.AddItem("Bread", 1.99);
Console.WriteLine(cart2);

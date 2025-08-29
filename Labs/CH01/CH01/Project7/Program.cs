bool exit =false;
Dictionary<string, string> phoneBook = new();
phoneBook.Add("Alice", "123-456-7890");
phoneBook.Add("Bob", "987-654-3210");
phoneBook.Add("Charlie", "555-555-5555");

do
{
    Console.WriteLine("\n 1. Add Contact \n 2. View Contact \n 3. Update Contact \n 4. Delete Contact \n 5. List All Contacts \n 6. Exit");
    Console.WriteLine("Enter Choice: ");
    string? choice = Console.ReadLine();
    if (choice.Equals("6"))
    {
        exit = true;
    }
    else if (choice.Equals("1"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        phoneBook.Add(name, phoneNumber);
    }
    else if (choice.Equals("2"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        if (phoneBook.ContainsKey(name))
        {
            Console.WriteLine($"Name: {name}, Phone Number: {phoneBook[name]}");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    else if (choice.Equals("3"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        if (phoneBook.ContainsKey(name))
        {
            Console.Write("Enter New Phone Number: ");
            string newPhoneNumber = Console.ReadLine();
            phoneBook[name] = newPhoneNumber;
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    else if (choice.Equals("4"))
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        if (phoneBook.ContainsKey(name))
        {
            phoneBook.Remove(name);
            Console.WriteLine("Contact deleted.");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    else if (choice.Equals("5"))
    {
        foreach (var contact in phoneBook)
        {
            Console.WriteLine($"Name: {contact.Key}, Phone Number: {contact.Value}");
        }
    }
    else
    {
        Console.WriteLine("Invalid Choice. Please try again.");
    }
} while(exit == false);

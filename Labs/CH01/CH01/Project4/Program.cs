Console.WriteLine("Enter your name:");
string name = Console.ReadLine();

for (int i = name.Length - 1; i >= 0; i--)
{
    Console.Write(name[i]);
}
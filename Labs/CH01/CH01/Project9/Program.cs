using Project9;

Leaf leaf = new Leaf();
Page page = new Page();
Pancake pancake = new Pancake();
Corner corner = new Corner();

List<ITurnable> turnables = new List<ITurnable> { leaf, page, pancake, corner };

static void Turning(List<ITurnable> t)
{
    foreach (ITurnable turn in t)
    {
        Console.WriteLine(turn.Turn());
    }
}

Turning(turnables);

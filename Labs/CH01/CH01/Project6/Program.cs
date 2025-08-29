int[] testScores = { 98, 76, 54, 32, 84, 89, 67, 93, 75, 56 };

int best = 0;
int worst = 100;
int sum = 0;

foreach (int i in testScores)
{
    best = int.Max(best, i);
    worst = int.Min(worst, i);
    sum += i;
}

Console.WriteLine($"Best: {best}\nWorst: {worst}\nSum: {sum}\n Average: {sum / testScores.Length}");

namespace TipCalculator.Models
{
    public class CalculateTip
    {
        public decimal MealCost { get; set; }
        public decimal CalculateTipFifteenPercent()
        {
            return MealCost * 0.15m;
        }
        public decimal CalculateTipTwentyPercent()
        {
            return MealCost * 0.20m;
        }
        public decimal CalculateTipTwentyFivePercent()
        {
            return MealCost * 0.25m;
        }
    }
}

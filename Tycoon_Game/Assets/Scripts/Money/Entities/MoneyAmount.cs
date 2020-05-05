namespace Assets.Scripts.Money.Entities
{
    public static class MoneyAmount
    {
        private const int MoneyForOneAnimal = 10;

        public static int Choose() => MoneyForOneAnimal * Zoo.AnimalCount * (int)Zoo.WelfareCoefficient;
    }
}

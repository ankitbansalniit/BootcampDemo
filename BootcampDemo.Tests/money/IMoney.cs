namespace NUnit.Samples.Money
{
    internal interface IMoney
    {
        IMoney Add(IMoney m);

        IMoney AddMoney(Money m);

        IMoney AddMoneyBag(MoneyBag s);

        bool IsZero { get; }

        IMoney Multiply(int factor);

        IMoney Negate();

        IMoney Subtract(IMoney m);
    }
}
namespace Price.Net;

public struct Price
{
    public decimal Value { get; private init; }

    public string CurrencyCode { get; }

    public Price(decimal value, string currency) : this()
    {
        Value = value;
        CurrencyCode = currency;
    }

    public static explicit operator decimal(Price price) => price.Value;

    public static Price operator +(Price left, Price right)
    {
        if (right.Value == 0)
            return left;
        if (left.Value == 0)
            return right;

        return left with { Value = left.Value + right.Value };
    }

    public static Price operator -(Price left, Price right)
    {
        if (right.Value == 0)
            return left;
        if (left.Value == 0)
            return new Price(-right.Value, right.CurrencyCode);

        return left with { Value = left.Value - right.Value };
    }

    public static Price operator *(Price left, Price right)
    {
        if (right.Value == 0 || left.Value == 0)
            return Zero;

        return left with { Value = left.Value * right.Value };
    }

    public static Price operator /(Price left, Price right)
    {
        if (right.Value == 0)
            throw new DivideByZeroException();
        if (left.Value == 0)
            return Zero;

        return left with { Value = left.Value / right.Value };
    }

    public static bool operator ==(Price left, Price right) => right.Value == left.Value;

    public static bool operator !=(Price left, Price right) => !(left == right);

    private bool Equals(Price other) => this == other;

    private int CompareTo(Price other) => (int)(Value - other.Value);

    public static bool operator <(Price e1, Price e2) => e1.CompareTo(e2) < 0;

    public static bool operator >(Price e1, Price e2) => e1.CompareTo(e2) > 0;

    public static bool operator <=(Price e1, Price e2) => e1.CompareTo(e2) <= 0;

    public static bool operator >=(Price e1, Price e2) => e1.CompareTo(e2) >= 0;

    public override bool Equals(object obj) => obj is Price price && Equals(price);

    public override int GetHashCode() =>
        (Value.GetHashCode() * 397) ^ (CurrencyCode != null ? CurrencyCode.GetHashCode() : 0);

    public static Price Zero => new(0, "USD");
}
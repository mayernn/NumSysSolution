using System.Numerics;

namespace NumSysLib;

internal abstract class ConverterBase
{
    protected static string ToBase10(string value, int fromBase)
    {
        BigInteger number = 0;
        const string digits = "0123456789ABCDEF";
        foreach (char c in value)
            number = number * fromBase + digits.IndexOf(c);
        return number.ToString();
    }

    protected static string FromBase10(string value, int toBase)
    {
        BigInteger number = BigInteger.Parse(value);
        if (number == 0) return "0";
        const string digits = "0123456789ABCDEF";
        string result = "";
        while (number > 0)
        {
            result = digits[(int)(number % toBase)] + result;
            number /= toBase;
        }
        return result;
    }

    protected static void Check(string value, int numberBase)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Ошибка ввода данных: пустое число.");
        const string digits = "0123456789ABCDEF";
        foreach (char c in value)
            if (digits.IndexOf(c) < 0 || digits.IndexOf(c) >= numberBase)
                throw new FormatException("Ошибка ввода данных: неверная цифра.");
    }

    internal abstract string ConvertTo10(string value);
    internal abstract string ConvertFrom10(string value);
}

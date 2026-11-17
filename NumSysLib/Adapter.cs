namespace NumSysLib;

public static class Adapter
{
    public static string Convert(string value, int fromBase, int toBase)
    {
        if (!IsSupportedBase(fromBase) || !IsSupportedBase(toBase))
            throw new ArgumentException("Допустимые основания: 2, 8, 10, 16.");

        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Ошибка ввода данных: пустое число.");

        value = value.Trim().ToUpperInvariant();
        bool negative = value.StartsWith('-');
        if (negative || value.StartsWith('+')) value = value[1..];
        CheckInput(value, fromBase);

        string result;

        if (fromBase == toBase)
            result = value;
        else if (fromBase == 2 && toBase == 8)
            result = new Binary().ConvertTo8(value);
        else if (fromBase == 2 && toBase == 16)
            result = new Binary().ConvertTo16(value);
        else if (fromBase == 8 && toBase == 2)
            result = new Oct().ConvertTo2(value);
        else if (fromBase == 8 && toBase == 16)
            result = new Oct().ConvertTo16(value);
        else if (fromBase == 16 && toBase == 2)
            result = new Hex().ConvertTo2(value);
        else if (fromBase == 16 && toBase == 8)
            result = new Hex().ConvertTo8(value);
        else if (toBase == 10)
            result = Create(fromBase).ConvertTo10(value);
        else
            result = Create(toBase).ConvertFrom10(value);

        result = result.TrimStart('0');
        if (result.Length == 0) result = "0";
        return negative && result != "0" ? "-" + result : result;
    }

    private static void CheckInput(string value, int numberBase)
    {
        if (value.Length == 0) throw new FormatException("Ошибка ввода данных: нет цифр.");
        const string digits = "0123456789ABCDEF";
        foreach (char c in value)
            if (digits.IndexOf(c) < 0 || digits.IndexOf(c) >= numberBase)
                throw new FormatException("Ошибка ввода данных: неверная цифра.");
    }

    private static bool IsSupportedBase(int numberBase)
    {
        return numberBase == 2 || numberBase == 8 || numberBase == 10 || numberBase == 16;
    }

    private static ConverterBase Create(int numberBase) => numberBase switch
    {
        2 => new Binary(),
        8 => new Oct(),
        16 => new Hex(),
        _ => throw new ArgumentException("Нельзя создать конвертер.")
    };
}

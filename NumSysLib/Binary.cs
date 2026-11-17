namespace NumSysLib;

internal class Binary : ConverterBase
{
    private string _digit = "0";
    internal string Digit
    {
        get => _digit;
        set
        {
            Check(value, 2);
            _digit = value;
        }
    }

    internal override string ConvertTo10(string value)
    {
        Digit = value;
        return ToBase10(Digit, 2);
    }

    internal override string ConvertFrom10(string value)
    {
        Check(value, 10);
        return FromBase10(value, 2);
    }

    internal string ConvertTo8(string value)
    {
        Digit = value;
        return ConvertByGroups(Digit, 3);
    }

    internal string ConvertTo16(string value)
    {
        Digit = value;
        return ConvertByGroups(Digit, 4);
    }

    private static string ConvertByGroups(string value, int groupSize)
    {
        while (value.Length % groupSize != 0)
            value = "0" + value;

        const string digits = "0123456789ABCDEF";
        string result = "";

        for (int i = 0; i < value.Length; i += groupSize)
        {
            int number = 0;
            for (int j = 0; j < groupSize; j++)
                number = number * 2 + (value[i + j] - '0');

            result += digits[number];
        }

        return result;
    }
}

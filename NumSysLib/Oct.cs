namespace NumSysLib;

internal class Oct : ConverterBase
{
    private string _digit = "0";
    internal string Digit
    {
        get => _digit;
        set
        {
            Check(value, 8);
            _digit = value;
        }
    }

    internal override string ConvertTo10(string value)
    {
        Digit = value;
        return ToBase10(Digit, 8);
    }

    internal override string ConvertFrom10(string value)
    {
        Check(value, 10);
        return FromBase10(value, 8);
    }

    internal string ConvertTo2(string value)
    {
        Digit = value;
        string result = "";

        foreach (char digit in Digit)
        {
            result += digit switch
            {
                '0' => "000",
                '1' => "001",
                '2' => "010",
                '3' => "011",
                '4' => "100",
                '5' => "101",
                '6' => "110",
                _ => "111"
            };
        }

        return result;
    }

    internal string ConvertTo16(string value)
    {
        string binaryValue = ConvertTo2(value);
        return new Binary().ConvertTo16(binaryValue);
    }
}

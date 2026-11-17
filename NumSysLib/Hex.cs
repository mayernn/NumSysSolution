namespace NumSysLib;

internal class Hex : ConverterBase
{
    private string _digit = "0";
    internal string Digit
    {
        get => _digit;
        set
        {
            Check(value, 16);
            _digit = value;
        }
    }

    internal override string ConvertTo10(string value)
    {
        Digit = value;
        return ToBase10(Digit, 16);
    }

    internal override string ConvertFrom10(string value)
    {
        Check(value, 10);
        return FromBase10(value, 16);
    }

    internal string ConvertTo2(string value)
    {
        Digit = value;
        string result = "";

        foreach (char digit in Digit)
        {
            result += digit switch
            {
                '0' => "0000",
                '1' => "0001",
                '2' => "0010",
                '3' => "0011",
                '4' => "0100",
                '5' => "0101",
                '6' => "0110",
                '7' => "0111",
                '8' => "1000",
                '9' => "1001",
                'A' => "1010",
                'B' => "1011",
                'C' => "1100",
                'D' => "1101",
                'E' => "1110",
                _ => "1111"
            };
        }

        return result;
    }

    internal string ConvertTo8(string value)
    {
        string binaryValue = ConvertTo2(value);
        return new Binary().ConvertTo8(binaryValue);
    }
}

namespace UtilitiesLib;

public static class StringUtilities
{
    public static int ConvertStringToInteger(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str)) throw new Exception("String Empty");

        return int.TryParse(str, out int result) ? result : throw new Exception("Could not parse int");
    }
    public static int ConvertStringToInteger(this string? str, int min, int max)
    {
        int result = ConvertStringToInteger(str);

        return (min <= result && result <= max) ? result : throw new Exception("Integer outside of range");
    }
    public static decimal ConvertStringToDecimal(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str)) throw new Exception("String Empty");

        return decimal.TryParse(str, out decimal result) ? result : throw new Exception("Could not parse decimal");
    }
    public static int ConvertStringToDecimal(this string? str, decimal min, decimal max)
    {
        int result = ConvertStringToInteger(str);

        return (min <= result && result <= max) ? result : throw new Exception("Integer outside of range");
    }

    public static bool CheckStringIsValidURL(string str)
    {
        return true;
    }
}
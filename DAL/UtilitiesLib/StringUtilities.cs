namespace UtilitiesLib;

public class StringUtilities
{
    public static int ConvertStringToInteger(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) throw new Exception("String Empty");

        return int.TryParse(str, out int result) ? result : throw new Exception("Could not parse int");
    }
    public static int ConvertStringToInteger(string str, int min, int max)
    {
        int result = ConvertStringToInteger(str);

        return (min <= result && result<= max) ? result : throw new Exception("Integer outside of range");
    }
    public static decimal ConvertStringToDecimal(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) throw new Exception("String Empty");

        return decimal.TryParse(str, out decimal result) ? result : throw new Exception("Could not parse int");
    }
    public static int ConvertStringToDecimal(string str, decimal min, decimal max)
    {
        int result = ConvertStringToInteger(str);

        return (min <= result && result <= max) ? result : throw new Exception("Integer outside of range");
    }
}
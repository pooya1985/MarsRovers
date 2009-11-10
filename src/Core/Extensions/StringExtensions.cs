namespace MarsRovers.Core.Extensions
{
    public static class StringExtensions
    {
        public static string FixLineBreak(this string s)
        {
            if(s.LastIndexOf('\n') == s.Length -1)
                return s.Substring(0, s.Length - 2).Replace("\r", "");
            return s.Replace("\r", "");
        }
    }
}
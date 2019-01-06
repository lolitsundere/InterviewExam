using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

public class HelperMethods
{
    /// <summary>
    /// 将输入算式分割为符号和数字
    /// 如输入"1.5+(34-52.2/2)"
    /// 将输出["1.5","+","(","34","-","52.2","/","2"，")"]
    /// </summary>
    /// <param name="formula"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetTokens(String formula)
    {
        String lpPattern = @"\(";
        String rpPattern = @"\)";
        String opPattern = @"[\+\-*/]";
        String doublePattern = @"(?: \d+\.\d* | \d*\.\d+ | \d+ ) (?: [eE][\+-]?\d+)?";
        String spacePattern = @"\s+";

        String pattern = String.Format("({0}) | ({1}) | ({2}) | ({3}) | ({4})",
                                        lpPattern, rpPattern, opPattern, doublePattern, spacePattern);

        foreach (String s in Regex.Split(formula, pattern, RegexOptions.IgnorePatternWhitespace))
        {
            if (!Regex.IsMatch(s, @"^\s*$", RegexOptions.Singleline))
            {
                yield return s;
            }
        }
    }
}

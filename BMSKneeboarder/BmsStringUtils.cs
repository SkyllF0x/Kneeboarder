using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace BMSKneeboarder
{
    public class BmsStringUtils
    {
        // Token: 0x06000162 RID: 354 RVA: 0x002035A4 File Offset: 0x002017A4
        public static string GetValueFromLine(string Line)
        {
            Line = Strings.Trim(Line);
            string text2;
            if (Versioned.IsNumeric(Line))
            {
                string text = Line;
                text2 = text;
            }
            else
            {
                int num = FirstSharp(Line);
                Line = Strings.Mid(Line, 1, checked(num - 1));
                Line = Strings.Trim(Line);
                string text;
                if (Versioned.IsNumeric(Line))
                {
                    text = Line;
                }
                else
                {
                    text = Conversions.ToString(0);
                }
                text2 = text;
            }
            return text2;
        }

        // Token: 0x06000163 RID: 355 RVA: 0x002035FC File Offset: 0x002017FC
        public static float GetFirstFloat(string Line)
        {
            float num = 0f;
            Line = Line.Replace("\t", " ");
            Line = Line.Replace(",", " ");
            Line = Line.Replace("#", " ");
            Line = Strings.Trim(Line);
            string[] array = Strings.Split(Line, " ", -1, CompareMethod.Binary);
            if (array.Length >= 1 && Versioned.IsNumeric(array[0]))
            {
                num = Conversions.ToSingle(array[0]);
            }
            return num;
        }

        // Token: 0x06000164 RID: 356 RVA: 0x00203678 File Offset: 0x00201878
        public static float GetSecondFloat(string Line)
        {
            float num = 0f;
            Line = Line.Replace("\t", " ");
            Line = Line.Replace(",", " ");
            Line = Line.Replace("#", " ");
            Line = Strings.Trim(Line);
            string[] array = Strings.Split(Line, " ", -1, CompareMethod.Binary);
            if (array.Length >= 2 && Versioned.IsNumeric(array[1]))
            {
                num = Conversions.ToSingle(array[1]);
            }
            return num;
        }

        // Token: 0x06000165 RID: 357 RVA: 0x002036F4 File Offset: 0x002018F4
        public static float GetThirdFloat(string Line)
        {
            float num = 0f;
            Line = Line.Replace("\t", " ");
            Line = Line.Replace(",", " ");
            Line = Line.Replace("#", " ");
            Line = Strings.Trim(Line);
            string[] array = Strings.Split(Line, " ", -1, CompareMethod.Binary);
            if (array.Length >= 3 && Versioned.IsNumeric(array[2]))
            {
                num = Conversions.ToSingle(array[2]);
            }
            return num;
        }

        // Token: 0x06000166 RID: 358 RVA: 0x00203770 File Offset: 0x00201970
        public static float GetFourthFloat(string Line)
        {
            float num = 0f;
            Line = Line.Replace("\t", " ");
            Line = Line.Replace(",", " ");
            Line = Line.Replace("#", " ");
            Line = Strings.Trim(Line);
            string[] array = Strings.Split(Line, " ", -1, CompareMethod.Binary);
            if (array.Length >= 4 && Versioned.IsNumeric(array[3]))
            {
                num = Conversions.ToSingle(array[3]);
            }
            return num;
        }

        // Token: 0x06000167 RID: 359 RVA: 0x002037EC File Offset: 0x002019EC
        public static int GetFirstInteger(string Line)
        {
            int num = 0;
            Operators.CompareString(Strings.Mid(Line, 1, 1), "#", false);
            string text = Firstword(Line);
            if (Versioned.IsNumeric(text))
            {
                num = Conversions.ToInteger(text);
            }
            return num;
        }

        // Token: 0x06000168 RID: 360 RVA: 0x00203827 File Offset: 0x00201A27
        public static string Firstword(string Line)
        {
            Line = Strings.Replace(Line, "\t", " ", 1, -1, CompareMethod.Binary);
            Line = Strings.Trim(Line);
            return Strings.Split(Line, " ", -1, CompareMethod.Binary)[0];
        }

        // Token: 0x06000169 RID: 361 RVA: 0x00203858 File Offset: 0x00201A58
        public static string FirstWordCsv(string Line)
        {
            Line = Strings.Trim(Line);
            int num = checked(FirstComma(Line) - 1);
            string text;
            if (num < 1)
            {
                text = Strings.Trim(Line);
            }
            else
            {
                text = Strings.Mid(Line, 1, num);
                text = Strings.Trim(text);
            }
            return text;
        }

        // Token: 0x0600016A RID: 362 RVA: 0x0020389C File Offset: 0x00201A9C
        public static string FirstWordSpace(string Line)
        {
            Line = Strings.Trim(Line);
            int num = FirstSpace(Line);
            string text;
            if (num < 1)
            {
                text = Strings.Trim(Line);
            }
            else
            {
                text = Strings.Mid(Line, 1, num);
                text = Strings.Trim(text);
            }
            return text;
        }

        // Token: 0x0600016B RID: 363 RVA: 0x002038E0 File Offset: 0x00201AE0
        public static string FirstWordSlash(string Line)
        {
            int num = Line.IndexOf("/");
            string text;
            if (num == -1)
            {
                text = Strings.Trim(Line);
            }
            else
            {
                text = Strings.Mid(Line, 1, num);
                text = Strings.Trim(text);
            }
            return text;
        }

        // Token: 0x0600016C RID: 364 RVA: 0x0020391C File Offset: 0x00201B1C
        public static string CutFirstWord(string Line)
        {
            string text;
            if (Line.Length <= 1)
            {
                text = "";
            }
            else
            {
                Line = Strings.Replace(Line, "\t", " ", 1, -1, CompareMethod.Binary);
                Line = Strings.Trim(Line);
                int num = FirstSpace(Line);
                string text2;
                if (num < 1)
                {
                    text2 = "";
                }
                else
                {
                    text2 = Strings.Mid(Line, num, Line.Length);
                    text2 = Strings.Trim(text2);
                }
                text = text2;
            }
            return text;
        }

        // Token: 0x0600016D RID: 365 RVA: 0x00203984 File Offset: 0x00201B84
        public static string CutFirstWordCsv(string Line)
        {
            string text;
            if (Line.Length <= 1)
            {
                text = "";
            }
            else
            {
                Line = Strings.Replace(Line, "\t", " ", 1, -1, CompareMethod.Binary);
                Line = Strings.Trim(Line);
                int num = FirstComma(Line);
                string text2;
                if (num < 1)
                {
                    text2 = "";
                }
                else
                {
                    text2 = Strings.Mid(Line, checked(num + 1), Line.Length);
                    text2 = Strings.Trim(text2);
                }
                text = text2;
            }
            return text;
        }

        // Token: 0x0600016E RID: 366 RVA: 0x002039F0 File Offset: 0x00201BF0
        public static string CutFirstWordSpace(string Line)
        {
            string text;
            if (Line.Length <= 1)
            {
                text = "";
            }
            else
            {
                Line = Strings.Replace(Line, "\t", " ", 1, -1, CompareMethod.Binary);
                Line = Strings.Trim(Line);
                int num = FirstSpace(Line);
                string text2;
                if (num < 1)
                {
                    text2 = "";
                }
                else
                {
                    text2 = Strings.Mid(Line, num, Line.Length);
                    text2 = Strings.Trim(text2);
                }
                text = text2;
            }
            return text;
        }

        // Token: 0x0600016F RID: 367 RVA: 0x00203A58 File Offset: 0x00201C58
        public static string CutFirstWordSlash(string Line)
        {
            string text;
            if (Line.Length <= 1)
            {
                text = "";
            }
            else
            {
                Line = Strings.Replace(Line, "\t", " ", 1, -1, CompareMethod.Binary);
                Line = Strings.Trim(Line);
                int num = Line.IndexOf("/");
                string text2;
                if (num < 1)
                {
                    text2 = "";
                }
                else
                {
                    text2 = Strings.Mid(Line, checked(num + 2), Line.Length);
                    text2 = Strings.Trim(text2);
                }
                text = text2;
            }
            return text;
        }

        // Token: 0x06000170 RID: 368 RVA: 0x00203AC8 File Offset: 0x00201CC8
        public static string WordFromComma(string Line, int Comma)
        {
            string text = "";
            checked
            {
                int num = Line.Length - 1;
                int num2 = 0;
                for (int i = 1; i <= num; i++)
                {
                    if (Operators.CompareString(Conversions.ToString(Conversions.ToChar(Strings.Mid(Line, i, 1))), ",", false) == 0)
                    {
                        num2++;
                    }
                }
                string text2;
                if (Comma > num2)
                {
                    text2 = text;
                }
                else if (Comma == 0)
                {
                    text2 = FirstWordCsv(Line);
                }
                else
                {
                    int num3 = Line.Length - 1;
                    int num5 = 0;
                    for (int j = 1; j <= num3; j++)
                    {
                        int num4 = 0;
                        if (Operators.CompareString(Conversions.ToString(Conversions.ToChar(Strings.Mid(Line, j, 1))), ",", false) == 0)
                        {
                            num4++;
                        }
                        if (num4 == Comma)
                        {
                            num5 = j;
                            break;
                        }
                    }
                    if (Comma == num2)
                    {
                        Line = Strings.Mid(Line, num5 + 1, Line.Length);
                        text = Strings.Trim(Line);
                    }
                    else
                    {
                        Line = Strings.Mid(Line, num5 + 1, Line.Length);
                        text = FirstWordCsv(Line);
                    }
                    text2 = text;
                }
                return text2;
            }
        }

        // Token: 0x06000171 RID: 369 RVA: 0x00203BBC File Offset: 0x00201DBC
        public static int FirstComma(string Line)
        {
            int num;
            if (Line == null)
            {
                num = -1;
            }
            else if (Line.Length == 0)
            {
                num = -1;
            }
            else
            {
                Line = Strings.Trim(Line);
                num = checked(Line.IndexOf(",") + 1);
            }
            return num;
        }

        // Token: 0x06000172 RID: 370 RVA: 0x00203BF4 File Offset: 0x00201DF4
        public static int FirstSpace(string Line)
        {
            int num;
            if (Line.Length == 0)
            {
                num = -1;
            }
            else
            {
                Line = Strings.Trim(Line);
                num = checked(Line.IndexOf(" ") + 1);
            }
            return num;
        }

        // Token: 0x06000173 RID: 371 RVA: 0x00203C24 File Offset: 0x00201E24
        public static int FirstSharp(string Line)
        {
            int num;
            if (Line.Length == 0)
            {
                num = -1;
            }
            else
            {
                Line = Strings.Trim(Line);
                num = checked(Line.IndexOf("#") + 1);
            }
            return num;
        }

        // Token: 0x06000174 RID: 372 RVA: 0x00203C54 File Offset: 0x00201E54
        public static int CountWords(string value)
        {
            return Regex.Matches(value, "\\S+").Count;
        }

        // Token: 0x06000175 RID: 373 RVA: 0x00203C68 File Offset: 0x00201E68
        public static bool CheckForSlash(string Val)
        {
            return Operators.CompareString(Strings.Mid(Val, Val.Length, Val.Length), "\\", false) == 0;
        }

        // Token: 0x06000176 RID: 374 RVA: 0x00203C9C File Offset: 0x00201E9C
        public static bool IsComment(string Line)
        {
            bool flag = false;
            string text = Strings.Mid(Line, 1, 1);
            string text2 = Strings.Mid(Line, 1, 2);
            if (Operators.CompareString(text2, "//", false) == 0)
            {
                flag = true;
            }
            if (Operators.CompareString(text2, "\\\\", false) == 0)
            {
                flag = true;
            }
            if (Operators.CompareString(text2, "# ", false) == 0)
            {
                flag = true;
            }
            if (Operators.CompareString(text, "#", false) == 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}

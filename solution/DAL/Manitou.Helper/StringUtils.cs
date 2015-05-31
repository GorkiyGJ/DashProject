using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Manitou.Helper
{
    public static class StringUtils
    {
        public static bool IsFixText(string value, bool isNonEmpty)
        {
            if (isNonEmpty && string.IsNullOrEmpty(value))
                return false;

            if (value.ToLower().IndexOf("frame") > -1)
                return false;

            if (value.ToLower().IndexOf("script") > -1)
                return false;

            if (value.ToLower().IndexOf("src=") > -1)
                return false;

            return true;
        }

        public static bool IsFixText(string value)
        {
            return IsFixText(value, true);
        }

        public static string ToAloneUpper(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length == 1)
                return value;

            return string.Format("{0}{1}", value[0].ToString().ToUpper(), value.Substring(1));
        }

        public static string GetTemperature(object value)
        {
            int convert = Converter.ToInt32(value, true);
            if (convert == 0)
                return "0";

            return convert > 0 ? string.Format("+{0}", value) : string.Format("{0}", value);
        }

        public static string TrimHtml(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return Regex.Replace(value, "<[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
            return "";
        }

        public static string SetLength(string value, short size)
        {
            return SetLength(value, (int)size);
        }

        public static string SetLength(string value, int size)
        {
            if (value != null && value.Length > size)
            {
                return value.Substring(0, size);
            }
            else
                return value;
        }

        public static string SetLengthDot(string value, short size)
        {
            if (value != null && value.Length - 1 > size && size > 0)
                return value.Substring(0, size) + "...";
            else
                return value;
        }

        public static string InsertText(string value, string insertText, int toInsert)
        {
            if (value.Length > toInsert)
            {
                int length = value.Length;
                int index = length;
                for (int i = toInsert; i != 0; i--)
                {
                    if (value[i] == '.'
                        || value[i] == '?' || value[i] == '!'
                        || value[i] == ':' || value[i] == ';')
                    {
                        index = i + 1;
                        break;
                    }
                }

                int j = value.IndexOf("</", index);
                if (j > -1)
                {
                    j--;
                    for (int i = j; i != 0; i--)
                    {
                        if (value[i] == '<')
                        {
                            j = i;
                            break;
                        }
                    }

                    if (j < index)
                    {
                        index = j;
                    }
                }

                return value.Insert(index, insertText);
            }

            return value;
        }

        public static string Spacer(string value, int maxLength)
        {
            if (String.IsNullOrEmpty(value) || maxLength <= 0)
                return value;

            int count = value.Length / maxLength;
            if (count > 0)
            {
                StringBuilder sb = new StringBuilder();
                int index = 0;
                for (int i = 0; i <= count; i++)
                {
                    if (index + maxLength < value.Length)
                    {
                        sb.Append(value.Substring(index, maxLength));
                        sb.Append(" ");
                    }
                    else
                    {
                        if (index >= value.Length)
                            break;
                        else
                            sb.Append(value.Substring(index, value.Length - index));
                    }

                    index += maxLength;
                }

                return sb.ToString();
            }
            else
                return value;
        }

        public static string GetSearchPhraze(string sPhraze)
        {
            string EndSearchPhraze = string.Empty;
            string[] strs = sPhraze.Replace("\"", " ").Replace("'", " ").Replace(";", " ").Replace(",", " ").Replace(".", " ").TrimStart().TrimEnd().Split(' ');
            if (strs != null && strs.Length > 0)
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    if (i == 0)
                    {
                        EndSearchPhraze = strs[i];
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(strs[i].Trim()))
                        {
                            EndSearchPhraze = string.Format("{0} {1}", EndSearchPhraze, strs[i]);
                        }
                    }
                }
            }
            return EndSearchPhraze;
        }
    }
}